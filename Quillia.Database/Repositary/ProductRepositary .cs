using Quillia.Database.Data;
using Quillia.Database.Repositary.IRepository;
using Quillia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quillia.Database.Repositary
{
    public class ProductRepositary : Repository<Product>,IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepositary(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        
        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
