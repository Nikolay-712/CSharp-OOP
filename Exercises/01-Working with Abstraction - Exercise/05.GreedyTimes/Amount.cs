using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Amount
    {
        private static List<Gold> GoldAmount { get; set; }
        private static List<Gem> GemAmount { get; set; }
        private static List<Cash> CashAmount { get; set; }

        private long maxCapacity;

        public Amount(long capacity)
        {
            this.MaxCapacity = capacity;

            GoldAmount = new List<Gold>();
            GemAmount = new List<Gem>();
            CashAmount = new List<Cash>();
        }

        public long MaxCapacity
        {
            get { return maxCapacity; }
            private set { maxCapacity = value; }
        }


        public void AddGold(Gold gold)
        {
            GoldAmount.Add(gold);

            if (CalculateTotallAmount() > MaxCapacity)
            {
                GoldAmount.Remove(gold);
            }

        }

        public long CalculateCurrentGoldAmount()
        {
            return GoldAmount.Select(x => x.Amount).Sum();
        }

        public void AddCash(Cash cash)
        {
            CashAmount.Add(cash);

            long cashAmont = cash.Amount;
            long gemAmount = CalculateCurrentGemAmount();

            if (cashAmont > gemAmount)
            {
                CashAmount.Remove(cash);
            }
            else if (CalculateCurrentCashAmount() > gemAmount)
            {
                CashAmount.Remove(cash);
            }
            else if (CalculateTotallAmount() > maxCapacity)
            {
                CashAmount.Remove(cash);
            }

        }

        public long CalculateCurrentCashAmount()
        {
            return CashAmount.Select(x => x.Amount).Sum();
        }

        public void AddGem(Gem gem)
        {
            GemAmount.Add(gem);

            long gemAmount = gem.Amount;
            long goldAmount = CalculateCurrentGoldAmount();

            if (gemAmount > goldAmount)
            {
                GemAmount.Remove(gem);
            }
            else if (CalculateCurrentGemAmount() > goldAmount)
            {
                GemAmount.Remove(gem);
            }
            else if (CalculateTotallAmount() > MaxCapacity)
            {
                GemAmount.Remove(gem);
            }
        }

        public long CalculateCurrentGemAmount()
        {
            return GemAmount.Select(x => x.Amount).Sum();
        }

        private long CalculateTotallAmount()
        {
            return
                CalculateCurrentCashAmount()
                + CalculateCurrentGemAmount()
                + CalculateCurrentGoldAmount();
        }

        public static List<Gold> Golds()
        {
            return GoldAmount;
        }

        public static List<Gem> Gems()
        {
            return GemAmount;
        }

        public static List<Cash> Cashes()
        {
            return CashAmount;
        }
    }
}
