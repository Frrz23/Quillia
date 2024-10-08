using Quillia.Database.Data;
using Quillia.Database.Repositary.IRepository;
using Quillia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quillia.Database.Repositary
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepositary(_db);
            Product = new ProductRepositary(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
