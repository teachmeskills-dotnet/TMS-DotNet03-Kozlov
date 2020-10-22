using System.ComponentModel.DataAnnotations;

namespace ProperNutrition.Web.ViewModels
{
    /// <summary>
    /// Sign in view model.
    /// </summary>
    public class SignInViewModels
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Password))]
        public string Password { get; set; }

        //ToDo: Resource file.

        /// <summary>
        /// RememberMe.
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Return Url.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
