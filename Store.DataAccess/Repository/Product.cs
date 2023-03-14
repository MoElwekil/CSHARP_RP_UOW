using Store.DataAccess.DbContexts;
using Store.DataAccess.Repository.IRepository;

namespace Store.DataAccess.Repository
{
    public class Product : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public Product(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}
