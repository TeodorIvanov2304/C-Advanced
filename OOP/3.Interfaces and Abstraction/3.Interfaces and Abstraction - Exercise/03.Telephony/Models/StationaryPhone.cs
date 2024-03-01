using Telephony.Models.Interfaces;

//Phone implementation
namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }


            return $"Dialing... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            //Short alternative
            //return phoneNumber.All(c=>char.IsDigit(c));
            foreach (char symbol in phoneNumber)
            {
                if (!char.IsNumber(symbol))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
