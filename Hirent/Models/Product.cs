using Hirent.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hirent.Models
{
    public class Product
    {
        static ProductDAO DAO = new ProductDAO();
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public string ImageSource1 { get; set; }
        public string ImageSource2 { get; set; }

        public int CategoryId { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase File1 { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase File2 { get; set; }
        public void Save()
        {
            DAO.saveProduct(this);
        }

        public static List<Product> GetProduct(int? id, bool forAdmin)
        {
            return DAO.GetProducts(id, forAdmin);
        }

        public static List<Product> GetProductByCategoryId(int id, bool forAdmin)
        {
            return DAO.GetProductsByCategoryId(id, forAdmin);
        }

        public static void Delete(int id)
        {
            DAO.deleteProduct(id);
        }

        internal static object GetProductByQuery(string query, bool forAdmin)
        {
            return DAO.GetProductsByQuery(query, forAdmin);
        }
    }
}