using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tumbleweed.Models
{
    
    public class SignupModel
    {
        [EmailAddress]
        [Required(ErrorMessage="Email address is required")]
        public string Email { get; set; }
    }
}