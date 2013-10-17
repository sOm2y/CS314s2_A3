using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS314s2_A3
{
    class Program
    {
        int totalRequest = 0;
        long totalData = 0;
        int reposeCode_200 = 0;
        int reposeCode_304 = 0;
        int reposeCode_302 = 0;
        int reposeCode_404 = 0;
        int reposeCode_403 = 0;
        int reposeCode_401 = 0;
        int reposeCode_400 = 0;
        int reposeCode_501 = 0;
        int reposeCode_500 = 0;
        int local = 0;
        int remote = 0;
        long localData = 0;
        long remoteData = 0;

        int htmls = 0;
        long htmlsData = 0;

        int images = 0;
        long imagesData = 0;
        int sounds = 0;
        long soundsData = 0;

        int videos = 0;
        long videosData = 0;

        int formatteds = 0;
        long formattedsData = 0;

        int dynamics = 0;
        long dynamicsData = 0;

        int others = 0;
        long othersData = 0;

        int once = 0;
        long onceData = 0;
        long totalD;

        int checkInt = 0;

        DateTime firstDay;
        DateTime lastDay;

        string s;
        static void Main(string[] args)
        {

            var log = new Program();
            log.readLog();
            Console.ReadLine();
        }
        /*************** TASK 1**************/
        // Read Each line from the log and process output

        // Skip to the next line if this line has an empty string

        // Split the line into each element   

        // Skip to the next line if this line contains not equal to 10
        // elements

        // Prepare and parse the request

        // If this line is the first or the last line, store date
        // information

        // Parse the date information

        // Parse requested file information
        // System.out.println(line);

        // If response code is 200, increment host type counter and size
        // of each host type



        // calculate distributions etc

        private void readLog()
        {

            StreamReader sr = new StreamReader(@"..\..\..\..\access_log");
            StreamWriter sw = new StreamWriter(@"..\..\..\..\result.txt", false, System.Text.Encoding.Default);
            Dictionary<string, long> d = new Dictionary<string, long>();
            Dictionary<string, int> dCheck = new Dictionary<string, int>();
          

            lastDay = date(File.ReadLines(@"..\..\..\..\access_log").Last().Split(' ')[3].Replace("[", ""));
            firstDay = date(File.ReadLines(@"..\..\..\..\access_log").First().Split(' ')[3].Replace("[", ""));
            // Console.WriteLine(lastDay.ToString());
            try
            {
                while (!String.IsNullOrEmpty(s = sr.ReadLine()))
                {

                    //for (int i = 0; i < 100; i++)
                    //{
                    string readFromFile = s;



                    if (readFromFile != null)
                    {

                        string[] line = readFromFile.Split(' ');


                        if (line.Length == 10)
                        {
                            totalRequest++;

                            if (line[8].Trim() == "200")
                            {
                                reposeCode_200++;
                                totalData += Convert.ToInt32(line[9].Trim());
                                if (line[0].Trim() == "local")
                                {
                                    local++;

                                    localData += Convert.ToInt32(line[9].Trim());


                                }
                                if (line[0].Trim() == "remote")
                                {
                                    remote++;

                                    remoteData += Convert.ToInt32(line[9].Trim());

                                }



                                if (line[6].Contains(".html") || line[6].Contains(".htm") || line[6].Contains(".shtml") || line[6].Contains(".map"))
                                {

                                    htmls++;
                                 //   Console.WriteLine(htmls);
                                    htmlsData += Convert.ToInt32(line[9].Trim());

                                }
                                else if (line[6].Contains(".gif") || line[6].Contains(".jpeg") || line[6].Contains(".jpg") || line[6].Contains(".xbm")
                                    || line[6].Contains(".bmp") || line[6].Contains(".rgb") || line[6].Contains(".xpm"))
                                {
                                    images++;
                                    imagesData += Convert.ToInt32(line[9].Trim());
                                }
                                else if (line[6].Contains(".au") || line[6].Contains(".snd") || line[6].Contains(".wav") || line[6].Contains(".mid") || line[6].Contains(".midi") || line[6].Contains(".lha") || line[6].Contains(".aif")
                                   || line[6].Contains(".aiff"))
                                {
                                    sounds++;
                                    soundsData += Convert.ToInt32(line[9].Trim());
                                }
                                else if (line[6].Contains(".mov") || line[6].Contains(".movie") || line[6].Contains(".avi") || line[6].Contains(".qt") || line[6].Contains(".mpeg") || line[6].Contains(".mpg"))
                                {
                                    videos++;
                                    videosData += Convert.ToInt32(line[9].Trim());
                                }
                                else if (line[6].Contains(".ps") || line[6].Contains(".eps") || line[6].Contains(".doc") || line[6].Contains(".dvi") || line[6].Contains(".txt"))
                                {
                                    formatteds++;
                                    formattedsData += Convert.ToInt32(line[9].Trim());
                                }
                                else if (line[6].Contains(".cgi") || line[6].Contains(".pl") || line[6].Contains(".cgi-bin"))
                                {
                                    dynamics++;
                                    dynamicsData += Convert.ToInt32(line[9].Trim());
                                }
                                else
                                {
                                    others++;
                                    othersData += Convert.ToInt32(line[9].Trim());
                                }
                                if (!dCheck.ContainsKey(line[6]))
                                {
                                    d.Add(line[6], Convert.ToInt64(line[9].ToString()));
                                    dCheck.Add(line[6], 1);
                                  //  totalD += Convert.ToInt64(line[9].ToString());
                                }
                                else{
                                    dCheck[line[6]]++;
                                   
                                }
                                   
                            }
                            else if (line[8].Trim() == "304") { reposeCode_304++; }
                            else if (line[8].Trim() == "302") { reposeCode_302++; }
                            else if (line[8].Trim() == "404") { reposeCode_404++; }
                            else if (line[8].Trim() == "403") { reposeCode_403++; }
                            else if (line[8].Trim() == "401") { reposeCode_401++; }
                            else if (line[8].Trim() == "400") { reposeCode_400++; }
                            else if (line[8].Trim() == "501") { reposeCode_501++; }
                            else if (line[8].Trim() == "500") { reposeCode_500++; }


                        }

                    }




                }
                List<string> keyName=new List<string>();
                foreach (KeyValuePair<string, int> item in dCheck)
                {
                    if (item.Value <= 1)
                    {
                        once++;
                        keyName.Add(item.Key.ToString());
                        
                        
                    }
                   
                    // do something with entry.Value or entry.Key
                }
                
                foreach (string data in keyName) {
                    if (d.ContainsKey(data)) {
                        onceData += d[data];
                    }
                   
                }
                foreach (KeyValuePair<string, long> item in d) {

                    totalD += item.Value;
                }
                TimeSpan span = lastDay - firstDay;

                sw.WriteLine("Average Requests per day:" +Math.Round(totalRequest / Convert.ToDouble(span.TotalDays.ToString()),2));
                sw.WriteLine("TotalBytes Transferred(in MB): " + Math.Round((double)totalData / (1024 * 1024),2));
                sw.WriteLine("Average Bytes per day(in MB): " + Math.Round( totalData / (1024 * 1024) / Convert.ToDouble(span.TotalDays.ToString()),2));

                sw.WriteLine("Various Reponses Breakdown: ");
                sw.WriteLine("200 : " + Math.Round((float)reposeCode_200 / totalRequest * 100 ,2));
                sw.WriteLine("302 : " + Math.Round((float)reposeCode_302 / totalRequest * 100, 2));
                sw.WriteLine("304 : " + Math.Round((float)reposeCode_304 / totalRequest * 100, 2));
                sw.WriteLine("404 : " + Math.Round((float)reposeCode_404 / totalRequest * 100, 2));
                sw.WriteLine("403 : " + Math.Round((float)reposeCode_403 / totalRequest * 100, 2));
                sw.WriteLine("401 : " + Math.Round((float)reposeCode_401 / totalRequest * 100, 2));
                sw.WriteLine("400 : " + Math.Round((double)reposeCode_400 / (double)totalRequest * 100, 2));
                sw.WriteLine("501 : " + Math.Round((float)reposeCode_501 / totalRequest * 100, 2));
                sw.WriteLine("500 : " + Math.Round((float)reposeCode_500 / totalRequest * 100, 2));
                sw.WriteLine("Mean Transfer Size: " + Math.Round((float)totalData / reposeCode_200,2));

                sw.WriteLine("Host Wise Distribution of Requests and Bytes Transferred: ");

                sw.WriteLine("Number of Requests: ");
                sw.WriteLine("local : " + Math.Round((float)local/reposeCode_200*100,2));
                sw.WriteLine("remote : " + Math.Round((float)remote / reposeCode_200 * 100,2));

                sw.WriteLine("Bytes Transferred: ");
                sw.WriteLine("local : " + Math.Round((double)localData / (double)totalData * 100),4);
                sw.WriteLine("remote : " + Math.Round((float)remoteData / totalData * 100,2));

                sw.WriteLine("Mean Transfer Size: " + Math.Round((float)totalData / reposeCode_200,2));

                sw.WriteLine("File Category Wise Distribution : ");

                sw.WriteLine("Number of Request Distribution : ");

                sw.WriteLine("Video : " + Math.Round((float)videos / reposeCode_200 * 100, 2));
                sw.WriteLine("Sound : " + Math.Round((float)sounds / reposeCode_200 * 100, 2));
                sw.WriteLine("Other : " + Math.Round((float)others / reposeCode_200 * 100, 2));
                sw.WriteLine("Dynamic : " + Math.Round((float)dynamics / reposeCode_200 * 100, 2));
                sw.WriteLine("Formatted :" + Math.Round((float)formatteds / reposeCode_200 * 100, 2));
                sw.WriteLine("HTML : " + Math.Round((float)htmls / reposeCode_200 * 100, 2));
                sw.WriteLine("Images : " + Math.Round((float)images / reposeCode_200 * 100,2));

                sw.WriteLine("Bytes Transferred Distribution : ");
                sw.WriteLine("Video : " + Math.Round((double)videosData / (double)totalData * 100, 2));
                sw.WriteLine("Sound : " + Math.Round((double)soundsData / (double)totalData * 100, 2));
                sw.WriteLine("Other : " + Math.Round((double)othersData / (double)totalData * 100, 2));
                sw.WriteLine("Dynamic : " + Math.Round((double)dynamicsData / (double)totalData * 100, 2));
                sw.WriteLine("Formatted : " + Math.Round((double)formattedsData / (double)totalData * 100, 2));
                sw.WriteLine("HTML : " + Math.Round((double)htmlsData / (double)totalData * 100, 2));
                sw.WriteLine("Images : " + Math.Round((double)imagesData / (double)totalData * 100 ,2));

                sw.WriteLine("Average Size for Different Categories: ");
                sw.WriteLine("Video : " + Math.Round((double)videosData / (double)videos,2));
                sw.WriteLine("Sound : " + Math.Round((double)soundsData / (double)sounds,2));
                sw.WriteLine("Other : " + Math.Round((double)othersData / (double)others,2));
                sw.WriteLine("Dynamic : " + Math.Round((double)dynamicsData / (double)dynamics,2));
                sw.WriteLine("Formatted : " + Math.Round((double)formattedsData / (double)formatteds,2));
                sw.WriteLine("HTML : " + Math.Round((double)htmlsData  / (double)htmls,2));
                sw.WriteLine("Images : " + Math.Round((double)imagesData/ (double)images ,2));
               
                sw.WriteLine("Percentage of Distinct Files accessed once:"+Math.Round((float)once/dCheck.Count*100,2));
                sw.WriteLine("Percentage of Distinct Bytes accessed once:"+Math.Round((float)onceData/totalD*100,2));

                Console.WriteLine("Fnish");





            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace.ToString());

            }
            finally
            {
                sw.Close();
            }
        }

        private DateTime date(string tempDate)
        {
            DateTime MyDateTime;

            MyDateTime = new DateTime();
            MyDateTime = DateTime.ParseExact(tempDate, "dd/MMM/yyyy:HH:mm:ss", null);



            return MyDateTime;
        }
    }
}
