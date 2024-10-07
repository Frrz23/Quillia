using Quillia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quillia.Database.Repositary.IRepository
{
    public interface ICategoryRepository : IRepositary<Categorycs>
    {
        void Update(Categorycs obj);

    }
}