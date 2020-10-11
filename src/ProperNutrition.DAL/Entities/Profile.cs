using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using ProperNutrition.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        
        /// UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User. 
        /// </summary>
        //[ForeignKey(nameof(UserId))]
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
    }
}
