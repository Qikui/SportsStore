namespace Vic.SportsStore.WebApp.Controllers
{
    using global::Vic.SportsStore.Domain.Abstract;
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

        public ActionResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository
                           .Products
                           .OrderBy(p => p.ProductId)
                           .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            };
            return View(model);
        }
    }
}
