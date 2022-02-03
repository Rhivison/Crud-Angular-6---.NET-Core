
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPhoneNumberTypeFacade
    {
        Task<PhoneNumberTypeResponse> FindAllAsync();
        //PersonPhoneResponse GetPhoneByNumber(string phoneNumber);
        //Task<PersonPhoneResponse> UpdatePhoneNumber(PersonPhoneRequest personPhoneRequest, string phoneNumber);
    }
}
