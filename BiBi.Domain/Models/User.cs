using System.ComponentModel.DataAnnotations;

namespace BiBi.Domain.Models
{
    public class User : IMongoEntity
    {
        //*** [Key]
        public string ObjectID { get; set; }
        public string UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

