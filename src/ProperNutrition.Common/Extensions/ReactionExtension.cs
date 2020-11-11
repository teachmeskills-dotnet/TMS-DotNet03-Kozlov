using ProperNutrition.Common.Enums;

namespace ProperNutrition.Common.Extensions
{
    public static class ReactionExtension
    {
        /// <summary>
        /// Convert enum to string.
        /// </summary>
        /// <param name="reactionType">Reaction type (enum).</param>
        /// <returns>String value.</returns>
        public static string ToLocal(this ReactionType reactionType)
        {
            return reactionType switch
            {
                ReactionType.NoReaction => "No reaction",
                ReactionType.Low => "Low",
                ReactionType.Medium => "Medium",
                ReactionType.High => "High",
                _ => "Unknown",
            };
        }
        /// <summary>
        /// Convert int to ReactionType.
        /// </summary>
        /// <param name="reactionType">Reaction type (int).</param>
        /// <returns>ReactionType value.</returns>
        public static ReactionType ToReactionType(int reactionType)
        {
            return reactionType switch
            {
                (int)ReactionType.NoReaction => ReactionType.NoReaction,
                (int)ReactionType.Low => ReactionType.Low,
                (int)ReactionType.Medium => ReactionType.Medium,
                (int)ReactionType.High => ReactionType.High,
                _ => ReactionType.Unknown,
            };
        }
        /// <summary>
        /// Validate ReactionType to CSS style.
        /// </summary>
        /// <param name="reactionType">Reaction type (enum).</param>
        /// <returns>CSS style.</returns>
        public static string ValidatePriorityType(this ReactionType reactionType)
        {
            return reactionType switch
            {
                ReactionType.NoReaction => string.Empty,
                ReactionType.Low => "todo__low",
                ReactionType.Medium => "todo__medium",
                ReactionType.High => "todo__high",
                _ => string.Empty,
            };
        }
    }
}
