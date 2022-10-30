using System.ComponentModel.DataAnnotations;

namespace TestProject.WebAPI.Models
{
    public class AccountDetail
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }


    }
}
