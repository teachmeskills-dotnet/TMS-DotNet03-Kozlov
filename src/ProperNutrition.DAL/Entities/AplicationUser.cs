﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProperNutrition.DAL.Entities
{
    /// <summary>
    /// User by IdentityUser.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Navigation to profile.
        /// </summary>
        public Profile Profile { get; set; }

        /// <summary>
        /// Navigatio to Ingridient.
        /// </summary>
        public ICollection<Ingridient> Ingridients { get; set; }
    }
}
