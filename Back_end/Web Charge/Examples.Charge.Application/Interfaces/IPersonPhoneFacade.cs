
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneResponse> FindAllAsync();
        PersonPhoneResponse GetPhoneByNumber(string phoneNumber);
        Task<PersonPhoneResponse> UpdatePhoneNumber(PersonPhoneRequest personPhoneRequest, string phoneNumber);
        Task<PersonPhoneResponse> DeletePersonPhoneNumber(string phoneNumber);
        Task<PersonPhoneResponse> CreatePersonPhoneNumber(PersonPhoneRequest personPhoneRequest);
    }
}
