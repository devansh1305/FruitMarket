using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FruitMarket.API.Domain.Models;
using FruitMarket.API.Domain.Services;
using FruitMarket.API.Resources;

namespace FruitMarket.API.Controllers
{
    public class BracketsController : BaseApiController
    {
        private readonly IBracketService _categoryService;
        private readonly IMapper _mapper;

        public BracketsController(IBracketService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all Brackets.
        /// </summary>
        /// <returns>List os Brackets.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BracketResource>), 200)]
        public async Task<IEnumerable<BracketResource>> ListAsync()
        {
            var Brackets = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Bracket>, IEnumerable<BracketResource>>(Brackets);

            return resources;
        }

        /// <summary>
        /// Saves a new Bracket.
        /// </summary>
        /// <param name="resource">Bracket data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BracketResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveBracketResource resource)
        {
            var Bracket = _mapper.Map<SaveBracketResource, Bracket>(resource);
            var result = await _categoryService.SaveAsync(Bracket);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var BracketResource = _mapper.Map<Bracket, BracketResource>(result.Resource);
            return Ok(BracketResource);
        }

        /// <summary>
        /// Updates an existing Bracket according to an identifier.
        /// </summary>
        /// <param name="id">Bracket identifier.</param>
        /// <param name="resource">Updated Bracket data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BracketResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBracketResource resource)
        {
            var Bracket = _mapper.Map<SaveBracketResource, Bracket>(resource);
            var result = await _categoryService.UpdateAsync(id, Bracket);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var BracketResource = _mapper.Map<Bracket, BracketResource>(result.Resource);
            return Ok(BracketResource);
        }

        /// <summary>
        /// Deletes a given Bracket according to an identifier.
        /// </summary>
        /// <param name="id">Bracket identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BracketResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var BracketResource = _mapper.Map<Bracket, BracketResource>(result.Resource);
            return Ok(BracketResource);
        }
    }
}