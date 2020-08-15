using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Telephony
{
    public class SmartPhone : ICalling, IBrowsing
    {


        private List<string> PhoneNumbersList;
        private List<string> URL_Histori;

        public SmartPhone()
        {
            this.PhoneNumbersList = new List<string>();
            this.URL_Histori = new List<string>();
        }

        public void AddPhoneNumbers(string phoneNumber)
        {
            this.PhoneNumbersList.Add(phoneNumber);
        }

        public void AddURL(string URL)
        {
            this.URL_Histori.Add(URL);
        }

        public string CheckPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.All(x => char.IsDigit(x)))
            {
                return phoneNumber;
            }

            return "Invalid number!";
        }

        public string CheckURL(string URL)
        {
            if (URL.Any(x => char.IsDigit(x)))
            {
                return "Invalid URL!";
            }

            return URL;
        }

        public string ShowPhoneNumbersList()
        {
            StringBuilder builder = new StringBuilder();

            foreach (string phonNumber in this.PhoneNumbersList)
            {
                string validPhoneNumber = this.CheckPhoneNumber(phonNumber);

                if (validPhoneNumber != "Invalid number!")
                {
                    builder.AppendLine($"Calling... {validPhoneNumber}");
                }
                else
                {
                    builder.AppendLine(validPhoneNumber);
                }

            }
            return builder.ToString().TrimEnd();
        }

        public string ShowURLHistori()
        {
            StringBuilder builder = new StringBuilder();

            foreach (string URL in URL_Histori)
            {
                string validURL = this.CheckURL(URL);

                if (validURL != "Invalid URL!")
                {
                    builder.AppendLine($"Browsing: {validURL}!");
                }
                else
                {
                    builder.AppendLine(validURL);
                }

            }

            return builder.ToString().TrimEnd();
        }

    }
}
