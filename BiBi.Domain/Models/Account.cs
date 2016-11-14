using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBi.Domain.Models
{
    public class Account : IMongoEntity
    {
        public string ObjectID { get; set; }
        
        //public User AccountOwner { get; set; }
        public int AccountID { get; set; }
        public int Balance { get; set; }
    }
}
