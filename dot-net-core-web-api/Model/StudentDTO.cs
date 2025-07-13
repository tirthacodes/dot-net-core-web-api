using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace dot_net_core_web_api.Model
{
    public class StudentDTO
    {
        [ValidateNever]
        public int Id { get; set; }
        [StringLength(30)] 
        [Required(ErrorMessage ="Student name is required.")]
        public string StudentName { get; set; }
        [EmailAddress(ErrorMessage ="Please enter valid email address.")]
        public string Email { get; set; }

        [Range(10,20)]
        public int Age {  get; set; }
        [Required]
        public string Address { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
