using Quillia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quillia.Database.Repositary.IRepository
{
    public interface IProductRepository : IRepositary<Product>
    {
        void Update(Product obj);

    }
}