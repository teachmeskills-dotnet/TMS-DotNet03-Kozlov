using ProperNutrition.Common.Interfaces;
using System;

namespace ProperNutrition.DAL.Entities
{
    /// <summary>
    /// Description of profiles.
    /// </summary>
    public class Profile : IHasUserIdentity, IHasDbIdentity
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// UserId.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Navigation to Application User. 
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// MiddleName.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// BirthDate.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Telegram.
        /// </summary>
        public string Telegram { get; set; }

        /// <summary>
        /// SocialNetwork.
        /// </summary>
        public string SocialNetwork { get; set; }

    }
}
