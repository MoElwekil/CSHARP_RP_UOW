using Microsoft.AspNetCore.Mvc;
using Store.Web.DbContexts;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products;

            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                Product p = _context.Products.FirstOrDefault(u => u.Name == product.Name);
                
                if(p.ID > 0)
                {
                    return RedirectToAction($"Update/{p.ID}");
                }

                return RedirectToAction("Index");
            }
            else 
            {
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Update(int ID) 
        {

            Product product = _context.Products.FirstOrDefault(u => u.ID == ID);

            if(product != null)
            {
                return View(product);
            }

            return NotFound();
        
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if(ModelState.IsValid & product != null)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Product product = _context.Products.FirstOrDefault(u => u.ID == ID);

            if(product != null)
            {
                return View(product);
            }

            return NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return View(product);
        }
    }
}
