using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.WebApp.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}