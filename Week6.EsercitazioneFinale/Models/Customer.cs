using System.Collections.Generic;

namespace Week6.EsercitazioneFinale.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string TaxCode { get; set; }
        public string Address { get; set; }

        public float MonthlyExpense
        {
            get
            {
                float amount = 0.0f;
                foreach(var policy in Policies)
                {
                    amount += policy.MonthlyRate;
                }
                return amount;
            }
        }

        public ICollection<InsurancePolicy> Policies = new List<InsurancePolicy>();

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {TaxCode} - {Address} -> Monthly Expense: {MonthlyExpense}";
        }
    }
}