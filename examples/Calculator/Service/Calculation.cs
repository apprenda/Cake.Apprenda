using System.Runtime.Serialization;

namespace CalculatorService
{
    [DataContract(Namespace = "CalculatorService", Name = "Calculation")]
    public class Calculation
    {
        [DataMember]
        public double Result { get; set; }

        [DataMember]
        public double Operand1 { get; set; }

        [DataMember]
        public double Operand2 { get; set; }
    }
}
