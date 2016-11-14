using BiBi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiBi.Domain.Repository;
using BiBi.DataAccess.Repository;

namespace BiBi.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository
        {
            get {   return new UserRepository();    }
        }
    }
}
