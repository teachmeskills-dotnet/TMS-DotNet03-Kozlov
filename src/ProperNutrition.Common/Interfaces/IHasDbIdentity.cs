namespace ProperNutrition.Common.Interfaces
{
    /// <summary>
    /// Interface for implement Identity
    /// </summary>
    public interface IHasDbIdentity
    {
        /// <summary>
        /// Indifier
        /// </summary>
        public int Id { get; set; }
    }
}