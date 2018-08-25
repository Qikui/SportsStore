namespace Vic.SportsStore.WebApp.Controllers
{
    using global::Vic.SportsStore.Domain.Abstract;
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
            return View(
                repository
                  .Products
                  .OrderBy(p => p.ProductId)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize));
        }
    }
}
