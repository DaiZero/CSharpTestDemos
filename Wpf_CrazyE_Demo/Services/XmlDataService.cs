using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Wpf_CrazyE_Demo.Models;

namespace Wpf_CrazyE_Demo.Services
{
    class XmlDataService : IDataService
    {
        public List<Dish> GetAllDish()
        {
            throw new NotImplementedException();
        }

        public List<Dish> GetAllDishes()
        {
            List<Dish> dishList = new List<Dish>();
            string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
            XDocument xDoc = XDocument.Load(xmlFileName);
            var dishes = xDoc.Descendants("Dish");
            foreach (var d in dishes)
            {
                Dish dish = new Dish();
                dish.Name = d.Element("Name").Value;
                dish.Category = d.Element("Category").Value;
                dish.Comment = d.Element("Comment").Value;
                dish.Score = double.Parse(d.Element("Score").Value);
                dishList.Add(dish);
            }

            return dishList;
        }
    }
}
