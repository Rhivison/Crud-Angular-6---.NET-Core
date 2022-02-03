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
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private IPersonPhoneService _personPhoneService;
        private IMapper _mapper;
        private IPhoneNumberTypeService _phoneNumberTypeService;
        private IPersonService _personService;


        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper, IPhoneNumberTypeService phoneNumberTypeService, IPersonService personService)
        {
            _personPhoneService = personPhoneService;
            _phoneNumberTypeService = phoneNumberTypeService;
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneResponse> FindAllAsync()
        {
           var result = await _personPhoneService.FindAllAsync();
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            return response;
        }

        public PersonPhoneResponse GetPhoneByNumber(string phoneNumber)
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

            var phoneNumberTypeList = await _phoneNumberTypeService.FindAllAsync();
            var responsePhoneNumberTypeList = new PhoneNumberTypeResponse();
            responsePhoneNumberTypeList.PhoneNumberTypeObjects = new List<PhoneNumberTypeDto>();
            responsePhoneNumberTypeList.PhoneNumberTypeObjects.AddRange(phoneNumberTypeList.Select(x => _mapper.Map<PhoneNumberTypeDto>(x)));
            var newPhoneNumberType = responsePhoneNumberTypeList.PhoneNumberTypeObjects.Where(x => x.PhoneNumberTypeID == personPhoneRequest.PhoneNumberTypeID)
                                     .FirstOrDefault();

            var personList = await _personService.FindAllAsync();
            var responsePersonService = new PersonResponse();
            responsePersonService.PersonObjects = new List<PersonDto>();
            responsePersonService.PersonObjects.AddRange(personList.Select(x => _mapper.Map<PersonDto>(x)));
            var newPerson = responsePersonService.PersonObjects.Where(x => x.BusinessEntityID == personPhoneRequest.BusinessEntityID).FirstOrDefault();

            var result = await _personPhoneService.UpdatePhoneNumber(personPhone,  phoneNumber, _mapper.Map<PhoneNumberType>(newPhoneNumberType),
                                                                     _mapper.Map<Person>(newPerson
                                                                     ));
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));
            return response;
        }

        public async Task<PersonPhoneResponse> DeletePersonPhoneNumber(string phoneNumber)
        {   
            var result = await _personPhoneService.DeletePersonPhoneNumber(phoneNumber);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));
            return response;

        }

        public async Task<PersonPhoneResponse> CreatePersonPhoneNumber(PersonPhoneRequest personPhoneRequest)
        {
            var personPhone = _mapper.Map<PersonPhone>(personPhoneRequest);
            var result = await _personPhoneService.CreatePersonPhoneNumber(personPhone);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));
            return response;
        }
    }
}
