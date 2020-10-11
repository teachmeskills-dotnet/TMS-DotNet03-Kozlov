using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProperNutrition.DAL.Entities
{
    /// <summary>
    /// User by IdentityUser .
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public Profile Profile { get; set; }
    }
}
