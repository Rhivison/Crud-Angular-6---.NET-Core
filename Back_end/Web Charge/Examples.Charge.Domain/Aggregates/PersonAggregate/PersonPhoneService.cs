using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public PersonPhone GetPhoneByNumber(string phoneNumber)
        {
            return _personPhoneRepository.GetPhoneByNumber(phoneNumber);
        }

        public async Task<PersonPhone> UpdatePhoneNumber(PersonPhone personPhone, string phoneNumber, PhoneNumberType phoneNumberType, Person newPerson)
        {

            return await _personPhoneRepository.UpdatePhoneNumber(personPhone,  phoneNumber, phoneNumberType, newPerson);
        }

        public async Task<PersonPhone> DeletePersonPhoneNumber(string phoneNumber)
        {
            return await _personPhoneRepository.DeletePersonPhoneNumber(phoneNumber);
        }
        public async Task<PersonPhone> CreatePersonPhoneNumber(PersonPhone personPhone)
        {
            return await _personPhoneRepository.CreatePersonPhoneNumber(personPhone);
        }
    }
}
