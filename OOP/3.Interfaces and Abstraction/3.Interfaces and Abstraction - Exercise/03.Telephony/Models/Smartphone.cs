using Telephony.Models.Interfaces;

//Smartphone implementation
namespace Telephony.Models
{
    public class Smartphone : IBrowsable,ICallable
    {
        public string Browse(string url)
        {
            if (!ValidateUrl(url))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {   
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {phoneNumber}";
        }

        private bool ValidateUrl(string url) => url.All(c => !char.IsDigit(c));
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
