using BiBi.Domain.Models;
using BiBi.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBi.DataAccess.Repository
{
    public class UserRepository : RepositoryMongo<User>, IUserRepository
    {
    }
}
