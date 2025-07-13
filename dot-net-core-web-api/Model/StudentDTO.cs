using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace dot_net_core_web_api.Model
{
    public class StudentDTO
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required(ErrorMessage ="Student name is required.")]
        public string StudentName { get; set; }
        [EmailAddress(ErrorMessage ="Please enter valid email address.")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
