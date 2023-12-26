using System.ComponentModel.DataAnnotations;

namespace superhero.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public int PhoneNumber { get; set; }

    }
}
