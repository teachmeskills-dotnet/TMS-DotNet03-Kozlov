using System;
using System.Collections.Generic;
using System.Text;

namespace ProperNutrition.Common.Interfaces
{
    /// <summary>
    /// Interfase for implement User identity
    /// </summary>
    public interface IHasUserIdentity
    {
        /// <summary>
        /// User Indifier.
        /// </summary>
        public string UserId { get; set; }
    }
}
