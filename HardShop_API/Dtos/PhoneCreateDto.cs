using System;

namespace HardShop_API.Dtos
{
    public class PhoneCreateDto
    {
        public string CountryCode { get; set; }
        public string DialCode { get; set; }
        public string e164Number { get; set; }
        public string IntlNumber { get; set; }
        public string NatlNumber { get; set; }
        public string Number { get; set; }
        public DateTime Created { get; set; }

        public PhoneCreateDto()
        {
            Created = DateTime.Now;
        }
    }
}