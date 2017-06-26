using Interface.Contracts;
using System.ServiceModel;

namespace Interface.Proxies
{
    internal class CalculatorServiceProxy : ClientBase<ICalculator>, ICalculator
    {
        public Calculation Add(Calculation data)
        {
            return base.Channel.Add(data);
        }

        public Calculation Subtract(Calculation data)
        {
            return base.Channel.Subtract(data);
        }

        public Calculation Multiply(Calculation data)
        {
            return base.Channel.Multiply(data);
        }

        public Calculation Divide(Calculation data)
        {
            return base.Channel.Divide(data);
        }

        public Calculation SquareRoot(Calculation data)
        {
            return base.Channel.SquareRoot(data);
        }

        public string[] GetCalculationAudits()
        {
            return base.Channel.GetCalculationAudits();
        }

    }
}
