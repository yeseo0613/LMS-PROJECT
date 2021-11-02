using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LMS_Project
{
    class DataManager
    {
        public static List<Stud> Studs = new List<Stud>();
        public static List<Sub> Subs = new List<Sub>();

        static DataManager()
        {
            Load();
        }

        public static void Load()
        {
            try
            {
                string studsOutput = File.ReadAllText(@"./Student.xml");
                XElement studXElement = XElement.Parse(studsOutput);

                Studs = (from item in studXElement.Descendants("stud")
                         select new Stud()
                         {
                             Id = int.Parse(item.Element("id").Value),
                             Passwd = item.Element("passwd").Value,
                             Sub1 = item.Element("sub1").Value,
                             Sub1Day = item.Element("sub1Day").Value,
                             Sub1Time = item.Element("sub1Time").Value,
                             Sub2 = item.Element("sub2").Value,
                             Sub2Day = item.Element("sub2Day").Value,
                             Sub2Time = item.Element("sub2Time").Value,
                             Sub3 = item.Element("sub3").Value,
                             Sub3Day = item.Element("sub3Day").Value,
                             Sub3Time = item.Element("sub3Time").Value,
                         }).ToList<Stud>();

                string subsOutput = File.ReadAllText(@"./Sub.xml");
                XElement subXElement = XElement.Parse(subsOutput);

                Subs = (from item in subXElement.Descendants("sub")
                        select new Sub()
                        {
                            subNum = int.Parse(item.Element("subNum").Value),
                            subName = item.Element("subName").Value,
                            prof = item.Element("prof").Value,
                            day = item.Element("day").Value,
                            time = item.Element("time").Value,
                            maxNum = int.Parse(item.Element("maxNum").Value),
                            curNum = int.Parse(item.Element("curNum").Value)
                        }).ToList<Sub>();
            }
            catch (FileNotFoundException e)
            {
                Save();
            }
        }
        public static void Save()
        {
            string studsOutput = "";
            studsOutput += "<studs>\n";
            foreach (var item in Studs)
            {
                studsOutput += "<stud>\n";
                studsOutput += "<id>" + item.Id + "</id>\n";
                studsOutput += "<passwd>" + item.Passwd + "</passwd>\n";
                studsOutput += "<sub1>" + item.Sub1 + "</sub1>\n";
                studsOutput += "<sub1Day>" + item.Sub1Day + "</sub1Day>\n";
                studsOutput += "<sub1Time>" + item.Sub1Time + "</sub1Time>\n";
                studsOutput += "<sub2>" + item.Sub2 + "</sub2>\n";
                studsOutput += "<sub2Day>" + item.Sub2Day + "</sub2Day>\n";
                studsOutput += "<sub2Time>" + item.Sub2Time + "</sub2Time>\n";
                studsOutput += "<sub3>" + item.Sub3 + "</sub3>\n";
                studsOutput += "<sub3Day>" + item.Sub3Day + "</sub3Day>\n";
                studsOutput += "<sub3Time>" + item.Sub3Time + "</sub3Time>\n";
                studsOutput += "</stud>\n";
            }
            studsOutput += "</studs>\n";
            File.WriteAllText(@"./Student.xml", studsOutput);

            string subsOutput = "";
            subsOutput += "<subs>\n";
            foreach (var item in Subs)
            {
                subsOutput += "<sub>\n";
                subsOutput += "<subNum>" + item.subNum + "</subNum>\n";
                subsOutput += "<subName>" + item.subName + "</subName>\n";
                subsOutput += "<prof>" + item.prof + "</prof>\n";
                subsOutput += "<day>" + item.day + "</day>\n";
                subsOutput += "<time>" + item.time + "</time>\n";
                subsOutput += "<maxNum>" + item.maxNum + "</maxNum>\n";
                subsOutput += "<curNum>" + item.curNum + "</curNum>\n";
                subsOutput += "</sub>\n";
            }
            subsOutput += "</subs>\n";
            File.WriteAllText(@"./Sub.xml", subsOutput);
        }
    }
}
