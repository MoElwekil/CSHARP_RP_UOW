using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.DbContexts;
using Store.DataAccess.Repository.IRepository;
using Store.Models;

namespace Store.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _context;

        public ProductController(IProductRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.GetAll();

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
                _context.Add(product);
                _context.Save();

                Product p = _context.GetFirstOrDefault(u => u.Name == product.Name);
                
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

            Product product = _context.GetFirstOrDefault(u => u.ID == ID);

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
                _context.Update(product);
                _context.Save();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Product product = _context.GetFirstOrDefault(u => u.ID == ID);

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
                _context.Delete(product);
                _context.Save();
            }

            return View(product);
        }
    }
}
