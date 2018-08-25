namespace Vic.SportsStore.WebApp.Controllers
{
    using global::Vic.SportsStore.Domain.Abstract;
    using System.Web.Mvc;

    public class ProductController : Controller
    {
        // GET: Product
        private IProductsRepository repository;

        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ActionResult List()
        {
            return View(repository.Products);
        }
    }
}
