using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private IPhoneNumberTypeService _phoneNumberTypeService;
        private IMapper _mapper;

        public PhoneNumberTypeFacade(IPhoneNumberTypeService phoneNumberTypeService, IMapper mapper)
        {
            _phoneNumberTypeService = phoneNumberTypeService;
            _mapper = mapper;
        }

        public async Task<PhoneNumberTypeResponse> FindAllAsync()
        {
            var result = await _phoneNumberTypeService.FindAllAsync();
            var response = new PhoneNumberTypeResponse();
            response.PhoneNumberTypeObjects = new List<PhoneNumberTypeDto>();
            response.PhoneNumberTypeObjects.AddRange(result.Select(x => _mapper.Map<PhoneNumberTypeDto>(x)));
            return response;
        }

        /*public PersonPhoneResponse GetPhoneByNumber(string phoneNumber)
        {
            var result = _personPhoneService.GetPhoneByNumber(phoneNumber);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));
            return response;
        }

        public async Task<PersonPhoneResponse> UpdatePhoneNumber(PersonPhoneRequest personPhoneRequest, string phoneNumber)
        {
            var personPhone = _mapper.Map<PersonPhone>(personPhoneRequest);
            var result = await _personPhoneService.UpdatePhoneNumber(personPhone,  phoneNumber);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));
            return response;
        }*/
    }
}
