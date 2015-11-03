using OrderEat.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEat.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
