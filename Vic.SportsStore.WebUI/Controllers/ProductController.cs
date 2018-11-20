namespace Vic.SportsStore.WebApp.Controllers
{
    using global::Vic.SportsStore.Domain.Abstract;
    using global::Vic.SportsStore.Domain.Entities;
    using global::Vic.SportsStore.WebApp.Models;
    using System.Linq;
    using System.Web.Mvc;

    public class ProductController : Controller
    {
        // GET: Product
        private IProductRepository repository;
        public int PageSize = 3;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository
            .Products
            .FirstOrDefault(p => p.ProductId == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository
                .Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                    ? repository.Products.Count()
                    : repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
