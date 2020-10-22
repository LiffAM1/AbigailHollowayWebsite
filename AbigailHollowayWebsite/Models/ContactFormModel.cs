using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbigailHollowayWebsite.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage="Please enter a valid name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage="Please enter a valid message")]
        public string Message { get; set; }
    }
}
