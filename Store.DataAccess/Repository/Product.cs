using Store.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Repository
{
    internal class Product : Repository<Product>, IProductRepository
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
