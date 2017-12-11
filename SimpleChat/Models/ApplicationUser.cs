using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using SimpleChat.Models.Chat;
using System.ComponentModel.DataAnnotations;

namespace SimpleChat.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Sign { get; set; }

        public List<Message> Messages { get; set; }
    }
}
