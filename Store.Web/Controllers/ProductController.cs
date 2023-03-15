using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.DbContexts;
using Store.DataAccess.Repository.IRepository;
using Store.Models;

namespace Store.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfwork.ProductRepository.GetAll();

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
                _unitOfwork.ProductRepository.Add(product);
                _unitOfwork.Save();

                Product p = _unitOfwork.ProductRepository.GetFirstOrDefault(u => u.Name == product.Name);
                
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

            Product product = _unitOfwork.ProductRepository.GetFirstOrDefault(u => u.ID == ID);

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
                _unitOfwork.ProductRepository.Update(product);
                _unitOfwork.Save();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Product product = _unitOfwork.ProductRepository.GetFirstOrDefault(u => u.ID == ID);

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
                _unitOfwork.ProductRepository.Delete(product);
                _unitOfwork.Save();
            }

            return View(product);
        }
    }
}
