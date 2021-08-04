﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Linq;


namespace task3
{

    //json tests
    public class Value3
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public List<Value> values { get; set; }
    }

    public class Test
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public List<Value3> values { get; set; }
    }

    public class Root
    {
        public List<Test> tests { get; set; }
    }

    //json values
    public class Value
    {
        public int id { get; set; }
        public string value { get; set; }
    }

    public class Root1
    {
        public List<Value> values { get; set; }
    }

    //json report
        class Report
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public List<Value3> values { get; set; }
    }



    class Program
    {
        static async Task Main(string[] args)
        {
            string testre = Console.ReadLine();
            string valure = Console.ReadLine();

            var test = JsonConvert.DeserializeObject<Root>(File.ReadAllText(testre));
            var value = JsonConvert.DeserializeObject<Root1>(File.ReadAllText(valure));
            var reports = File.Exists("report.json");


            string tes = "";
            string idzap = "";
            string idzap1 = "";
            bool valuzap = false;
            string idz = "";

            JsonTextReader reader = new JsonTextReader(new StringReader(File.ReadAllText("tests.json")));
            while (reader.Read())
            {
                if (valuzap != true)
                {
                    if (reader.Value != null)
                    {
                        if (reader.Value.ToString() != "value")
                        {
                            if (idzap1 == idzap)
                            {
                                if (reader.Value.ToString() == "id")
                                {
                                    tes += "{"+reader.Value.ToString() + ":";

                                    idzap = reader.Value.ToString();

                                }
                                else if (reader.Value.ToString() == "title")
                                {
                                    tes += reader.Value.ToString() + ":";
                                }
                                else if (reader.Value.ToString() == "values")
                                {
                                    tes += reader.Value.ToString() + ":";
                                }
                                else if(reader.Value.ToString() !="tests")
                                {
                                    tes += reader.Value.ToString() + ",";
                                }
                                else
                                {
                                    tes += "{[";
                                }
                            }
                            else
                            {
                                if (reader.Value.ToString() != "tests")
                                {
                                    tes += reader.Value.ToString() + ",";
                                }
                                idz = reader.Value.ToString();
                                idzap = "";

                            }
                        }
                        else
                        {
                            tes += reader.Value.ToString() + ":";
                            valuzap = true;
                        }
                    }
                    
                }
                else
                {
                    for (int i = 0; i < value.values.Count; i++)
                    {
                        if (Convert.ToInt32(idz) == value.values[i].id)
                        {
                            tes += value.values[i].value.ToString() + "} ]";
                            valuzap = false;
                        }
                    }
                }

            }

            tes += "}";
            string json = JsonConvert.SerializeObject(tes);

            File.WriteAllText("report.json", JsonConvert.SerializeObject(json));

        }

    }

}

