using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Cors;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facade;

        public PersonPhoneController(IPersonPhoneFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{phoneNumber}")]
        public ActionResult<string> Get(string phoneNumber)
        {
            try
            {
                return Response(_facade.GetPhoneByNumber(phoneNumber));
            }
            catch(Exception ex)
            {
                return BadRequest("Erro:" + ex.Message);
            }
        }

        [HttpPut("{phoneNumber}")]
        public async Task<IActionResult> Put([FromBody] PersonPhoneRequest request, string phoneNumber)
        {
            try
            {
                return Response(null, await _facade.UpdatePhoneNumber(request, phoneNumber));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro:" + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonPhoneRequest request)
        {
            return ResponseExample(0, await _facade.CreatePersonPhoneNumber(request));
           
        }
        [DisableCors]
        [HttpDelete("{phoneNumber}")]
        public async Task<IActionResult> Delete(string phoneNumber)
        {
            try
            {
                return Response(null, await _facade.DeletePersonPhoneNumber(phoneNumber));
            }
            catch(Exception ex)
            {
                return BadRequest("Erro:" + ex.Message);
            }
        }
    }
}
