using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBi.Domain
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity Add(TEntity entity);
    }
}
