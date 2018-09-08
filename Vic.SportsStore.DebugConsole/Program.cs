using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFDbContext())
            {
                var product = new Product()
                {
                    Name = "Coffee",
                    Description = "Made in Comlunbia",
                    Price = 124.5m,
                    Category = "Drinks", 
                };
                var products = ctx.Products;
                ctx.Products.Add(product);
                ctx.SaveChanges();
            }
        }
    }
}
