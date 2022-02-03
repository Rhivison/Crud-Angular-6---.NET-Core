namespace Examples.Charge.Application.Messages.Request
{
    public class PersonPhoneRequest
    {
        public int BusinessEntityID { get; set; }
        public string phoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
    }
}
