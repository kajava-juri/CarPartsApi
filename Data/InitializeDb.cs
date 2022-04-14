using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaruosadApi.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace VaruosadApi.Data
{
    public class InitializeDb
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if(context.CarParts.Any())
            {
                return;
            }
            var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.NumberDecimalSeparator = ",";
            string path = "C:/Users/opilane/Desktop/varuosadApiClone/LE.csv";

            string[] lines = System.IO.File.ReadAllLines(path);

            //for testing
            //for (int i = 0; i < 100; i++)
            //{
            //    string[] columns = lines[i].Replace("\"", "").Split('\t');
            //    if (columns.Length <= 1)
            //    {
            //        continue;
            //    }
            //    var carpart = CreateFromData(columns, ci);
            //    context.CarParts.Add(carpart);
            //}

            foreach (var line in lines)
            {
                string[] columns = line.Replace("\"", "").Split('\t');
                if (columns.Length <= 1)
                {
                    continue;
                }
                var carpart = CreateFromData(columns, ci);
                context.CarParts.Add(carpart);
            }


            context.SaveChanges();
        }

        public static CarPart CreateFromData(string[] data, CultureInfo ci)
        {
            return new CarPart
            {
                Code = data[0],
                Name = data[1],
                Price = float.Parse(data[10], ci)
            };
        }
    }
}
