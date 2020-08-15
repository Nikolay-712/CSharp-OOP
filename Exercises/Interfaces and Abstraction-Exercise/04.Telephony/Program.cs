using System;

namespace _04.Telephony
{
    public class Program
    {
        static void Main()
        {
            SmartPhone smartPhone = new SmartPhone();

            var phones = Console.ReadLine().Split(" ");
            var url = Console.ReadLine().Split(" ");

            foreach (var item in phones)
            {
                smartPhone.AddPhoneNumbers(item);
            }

            foreach (var item in url)
            {
                smartPhone.AddURL(item);
            }

            Console.WriteLine(smartPhone.ShowPhoneNumbersList());
            Console.WriteLine(smartPhone.ShowURLHistori());

        }
    }
}
