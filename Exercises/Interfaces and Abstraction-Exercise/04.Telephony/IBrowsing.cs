using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Telephony
{
    public interface IBrowsing
    {
        public void AddURL(string URL);

        public string CheckURL(string URL);

        public string ShowURLHistori();
    }
}
