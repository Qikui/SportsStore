namespace Vic.SportsStore.WebApp.Controllers
{
    using global::Vic.SportsStore.Domain.Abstract;
    using System.Web.Mvc;

    public class ProductController : Controller
    {
        // GET: Product
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ActionResult List()
        {
            return View(repository.Products);
        }
    }
}
