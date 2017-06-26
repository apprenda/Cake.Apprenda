using System.Runtime.Serialization;

namespace Interface.Contracts
{
    [DataContract(Namespace = "CalculatorService", Name = "Calculation")]
    public class Calculation
    {
        public Calculation()
        {
        }

        [DataMember]
        public int Result { get; set; }

        [DataMember]
        public double Operand1 { get; set; }

        [DataMember]
        public double Operand2 { get; set; }
    }
}
