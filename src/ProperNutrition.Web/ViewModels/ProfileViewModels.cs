using System;

namespace ProperNutrition.Web.ViewModels
{

    /// <summary>
    /// Profile View Models.
    /// </summary>
    public class ProfileViewModels
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

        /// <summary>
        /// ChatId.
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// SecretKey.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Date time created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Date time last edited.
        /// </summary>
        public DateTime LastEdited { get; set; }

        /// <summary>
        /// Avatar picture.
        /// </summary>
        public byte[] ProfilePicture { get; set; }
    }
}
