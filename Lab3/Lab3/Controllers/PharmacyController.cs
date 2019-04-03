using Lab3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DStructures;
using System.Linq;

namespace Lab3.Controllers
{
    public class PharmacyController : Controller
    {
        private static Tree<string, DrugModel> MyTree;

        [HttpGet]
        public ActionResult LoadTree()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadTree(HttpPostedFileBase csvFile)
        {

            MyTree = new Tree<string, DrugModel>();
            ReadFile(csvFile);

            return View();

        }


        [HttpGet]
        public ActionResult Orders()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Refill()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }


        [HttpGet]
        public ActionResult TraverseTree()
        {
            return View();
        }

        private bool ReadFile(HttpPostedFileBase csvFile)
        {
            bool succeed = false;

            string path = string.Empty;

            if (csvFile != null)
            {
                if (".csv".Equals(Path.GetExtension(csvFile.FileName), StringComparison.OrdinalIgnoreCase))
                {
                    string fileName = Path.GetFileName(csvFile.FileName);
                    path = Path.Combine(Server.MapPath("~/App_Data/Files"), fileName);
                    csvFile.SaveAs(path);

                    string file = System.IO.File.ReadAllText(path);
                    foreach (string line in file.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] items = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                            try
                            {
                                DrugModel Drug = new DrugModel()
                                {
                                    Uid = int.Parse(items[0]),
                                    Name = items[1],
                                    Description = items[2],
                                    Producer = items[3],
                                    Price = float.Parse(items[4].Trim('$')),
                                    Stock = int.Parse(items[5])
                                };
                                MyTree.Insert(Drug.Name, Drug);
                                succeed = true;
                            }
                            catch (Exception)
                            {
                                MyTree.WipeOut();
                                return false;
                            }
                        }
                    }
                }
            }
            return succeed;
        }
    }
}