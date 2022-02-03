using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using System;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberTypeController : BaseController
    {
        private IPhoneNumberTypeFacade _facade;

        public PhoneNumberTypeController(IPhoneNumberTypeFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PhoneNumberTypeResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{phoneNumber}")]
        public ActionResult<string> Get(string phoneNumber)
        {
            return null;
            /*try
            {
                return Response(_facade.GetPhoneByNumber(phoneNumber));
            }
            catch(Exception ex)
            {
                return BadRequest("Erro:" + ex.Message);
            }*/
        }

        [HttpPut("{phoneNumber}")]
        public async Task<IActionResult> Put([FromBody] PersonPhoneRequest request, string phoneNumber)
        {
            return null;
            /*try
            {
                return Response(null, await _facade.UpdatePhoneNumber(request, phoneNumber));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro:" + ex.Message);
            }*/
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExampleRequest request)
        {
            //return Response(0, null);
            return null;
        }
    }
}
