using ProperNutrition.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProperNutrition.DAL.Entities
{
    /// <summary>
    /// Ingridents.
    /// </summary>
    public class Ingridients : IHasDbIdentity, IHasUserIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string UserId { get; set; }

        /// <summary>
        /// Name of ingridient
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of ingridient
        /// </summary>
        public string Type { get; set; }

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
        public DateTime IngridientDate { get; set; }

    }
}
