using BiBi.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBi.Domain
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        //void Commit()
    }
}
