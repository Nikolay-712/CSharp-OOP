using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public interface IBuyer
    {
        public void BuyFood();

        public int Food { get; }
    }
}
