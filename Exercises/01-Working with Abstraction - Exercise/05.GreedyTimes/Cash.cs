﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Cash
    {
        private string type;
        private long amount;

        public Cash(string type,long amount)
        {
            this.Type = type;
            this.Amount = amount;
        }

        public long Amount
        {
            get { return this.amount; }
            private set { this.amount = value; }
        }


        public string Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }


    }
}
