using Labb3_API.data;
using Labb3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IApp _application;
        public PersonController(IApp application)
        {
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> GetAllPerson()
        {
            try
            {
                return Ok(await _application.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database...");
            }
        }

        [HttpGet("GetPersonInterest/{id:int}")]
        public async Task<ActionResult<Person>> GetIntrestPersonID(int id)
        {
            try
            {
                var result = await _application.GetPersonInterest(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database...");
            }
        }


        [HttpGet("GetPersonLinks/{Id:int}")]
        public async Task<ActionResult<Person>> GetLinkPersonID(int Id)
        {
            try
            {
                var result = await _application.GetPersonLinks(Id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database...");
            }
        }

        [HttpPost("AddInterest")]
        public async Task<IActionResult> AddInterestToPerson(int personID, int interest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _application.AddInterestPerson(personID, interest);
                return Ok();
               
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to post data to Database...");
            }
        }

        [HttpPost("AddLink")]
        public async Task<IActionResult> AddLinkToPerson(int personID, int interestID, string url)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _application.AddLinkPerson(personID, interestID, url);
                return Ok();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to post data to Database...");
            }
        }
    }
}
