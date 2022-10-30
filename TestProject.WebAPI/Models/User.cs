using System.ComponentModel.DataAnnotations;

namespace TestProject.WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailAddress { get; set; }

        public int Salary { get; set; }

        public int Expenses {get;set;}
    }
}
