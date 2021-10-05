using System.Collections.Generic;
using System.Linq;

namespace ex1_the_debt_book.Models
{
    public class Debtor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Debt> Debts { get; private set; } = new List<Debt>();

        public int TotalDebt
        {
            get { return Debts.Sum(item => item.DebtAmount); }
        }

        public Debtor(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddDebt(int counterpartId, int debtAmount)
        {
            Debt debtEntry = Debts.Find(item => item.CounterpartId == counterpartId);
            if (debtEntry == null)
            {
                Debts.Add(new Debt(counterpartId, debtAmount));
            }
            else
            {
                debtEntry.DebtAmount += debtAmount;
                if (debtEntry.DebtAmount == 0)
                {
                    Debts.Remove(debtEntry);
                }
            }
        }
    }
}