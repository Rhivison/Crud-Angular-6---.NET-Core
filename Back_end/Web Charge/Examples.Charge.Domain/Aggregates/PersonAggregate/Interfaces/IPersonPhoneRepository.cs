using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
        PersonPhone GetPhoneByNumber(string phoneNumer);
        Task<PersonPhone> UpdatePhoneNumber(PersonPhone personPhone, string phoneNumber, PhoneNumberType newPhoneNumberType, Person newPerson);
        Task<PersonPhone> DeletePersonPhoneNumber(string phoneNumber);
        Task<PersonPhone> CreatePersonPhoneNumber(PersonPhone personPhone);
    }
}
