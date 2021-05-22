using AutoMapper;
using Capitals.API.ViewModels;
using Capitals.Core.Entities;
using Capitals.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capitals.API.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService,
                                 IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }


        /// <summary>
        /// Get all capitals of a country given a name
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     api/countries/Argentina/capitals
        /// </remarks>
        /// <param name="countryName"></param>
        /// <returns></returns>
        [HttpGet("{countryName}/capitals")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<CapitalViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CapitalViewModel>>> GetCapitals(string countryName)
        {
            var capitals = await _countryService.GetCapitalsByCountryName(countryName);
            return capitals is null || !capitals.Any() ? NotFound() : Ok(_mapper.Map<IEnumerable<CapitalViewModel>>(capitals));
        }
    }
}
