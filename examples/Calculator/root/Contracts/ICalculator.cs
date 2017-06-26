using System.ServiceModel;

namespace Interface.Contracts
{
    [ServiceContract(Namespace = "CalculatorService", Name = "Calculator")]
    public interface ICalculator
    {
        [OperationContract]
        Calculation Add(Calculation data);

        [OperationContract]
        Calculation Subtract(Calculation data);

        [OperationContract]
        Calculation Multiply(Calculation data);

        [OperationContract]
        Calculation Divide(Calculation data);

        [OperationContract]
        Calculation SquareRoot(Calculation data);

        [OperationContract]
        string[] GetCalculationAudits();

    }
}
