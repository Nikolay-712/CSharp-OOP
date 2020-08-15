using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Telephony
{
    interface ICalling
    {
        public void AddPhoneNumbers(string phoneNumber);

        public string ShowPhoneNumbersList();

        public string CheckPhoneNumber(string phoneNumber);

    }
}
