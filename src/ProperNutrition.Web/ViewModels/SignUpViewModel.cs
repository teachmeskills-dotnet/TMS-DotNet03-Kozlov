﻿using System.ComponentModel.DataAnnotations;

namespace ProperNutrition.Web.ViewModels
{
    /// <summary>
    /// Sing up view model.
    /// </summary>
    public class SignUpViewModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [Display(Name = nameof(Email))]
        public string Email { get; set; }

        /// <summary>
        /// ApplicationUserName.
        /// </summary>
        [Required]
        [Display(Name = "User Name")]
        public string Applicationusername { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Password))]
        public string Password { get; set; }

        /// <summary>
        /// Password confirm.
        /// </summary>
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords are different")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password")]
        public string PasswordConfirm { get; set; }
    }
}