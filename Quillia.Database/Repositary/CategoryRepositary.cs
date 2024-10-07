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
    public class CategoryRepositary : Repository<Categorycs>,ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepositary(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        
        public void Update(Categorycs obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
