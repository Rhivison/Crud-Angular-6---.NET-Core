using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;
        

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
           
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);

        public PersonPhone GetPhoneByNumber(string phoneNubmer)
        {
            return _context.Set<PersonPhone>().Where(x => x.PhoneNumber == phoneNubmer).FirstOrDefault();
        }

        public async Task<PersonPhone> UpdatePhoneNumber(PersonPhone personPhone, string phoneNumber, PhoneNumberType newPhoneNumberTtype, Person newPerson)
        {
            var _personPhone = _context.PersonPhone.SingleOrDefault(x => x.PhoneNumber == phoneNumber);
            _context.PersonPhone.Remove(_personPhone);
            await _context.SaveChangesAsync();

           
            _personPhone.PhoneNumber = personPhone.PhoneNumber;
            _personPhone.PhoneNumberTypeID = newPhoneNumberTtype.PhoneNumberTypeID;
            _personPhone.PhoneNumberType = newPhoneNumberTtype;
            _personPhone.BusinessEntityID = personPhone.BusinessEntityID;
            _personPhone.Person = newPerson;
           

            _context.PersonPhone.Add(_personPhone);

            

            await _context.SaveChangesAsync();

            return personPhone;
        }

        public async Task<PersonPhone> DeletePersonPhoneNumber(string phoneNumber)
        {
            var _personPhone = _context.PersonPhone.SingleOrDefault(x => x.PhoneNumber == phoneNumber);
            _context.PersonPhone.Remove(_personPhone);
            await _context.SaveChangesAsync();
            return _personPhone;
        }
        public async Task<PersonPhone> CreatePersonPhoneNumber(PersonPhone personPhone)
        {
            _context.PersonPhone.Add(personPhone);
            await _context.SaveChangesAsync();
            return personPhone;
        }
    }
}
