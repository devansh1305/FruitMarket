using FruitMarket.API.Domain.Models;

namespace FruitMarket.API.Domain.Services.Communication
{
    public class BracketResponse : BaseResponse<Bracket>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="bracket">Saved Bracket.</param>
        /// <returns>Response.</returns>
        public BracketResponse(Bracket bracket) : base(bracket)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BracketResponse(string message) : base(message)
        { }
    }
}