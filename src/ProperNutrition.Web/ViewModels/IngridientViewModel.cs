﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProperNutrition.Web.ViewModels
{
    /// <summary>
    /// Prepairing model. 
    /// </summary>
    public class IngridientViewModel
    {
        /// <summary>
        /// Ingridient identity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of ingridient.
        /// </summary>
        public string NameIngridient { get; set; }

        /// <summary>
        /// Category of ingridient.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Description of ingridient.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Number of calories.
        /// </summary>
        public decimal Colories { get; set; }

        /// <summary>
        /// Recomend.
        /// </summary>
        public bool IsRecomended { get; set; }

        /// <summary>
        /// Reaction.
        /// </summary>
        public string Reaction { get; set; }

        /// <summary>
        /// Date of Ingridient.
        /// </summary>
        public DateTime? IngridientDate { get; set; }
    }
}