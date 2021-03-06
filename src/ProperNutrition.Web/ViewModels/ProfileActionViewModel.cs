﻿using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProperNutrition.Web.ViewModels
{
    public class ProfileActionViewModel
    {
        [Required]
        /// <summary>
        /// FirstName.
        /// </summary>
        public string FirstName { get; set; }

        [Required]
        /// <summary>
        /// LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// MiddleName.
        /// </summary>
        public string MiddleName { get; set; }

        [Required]
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
        /// Avatar picture.
        /// </summary>
        public byte[] ProfilePicture { get; set; }

        /// <summary>
        /// Avatar.
        /// </summary>
        public IFormFile Avatar { get; set; }
    }
}