using System;
using Apprenda.SaaSGrid;
using Interface.Contracts;
using Interface.Proxies;
using System.ServiceModel;

namespace root
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PopulateCalculationAudit();
        }

        protected void PopulateCalculationAudit()
        {
            ICalculator proxy = new CalculatorServiceProxy();
            calculationAudits.Items.Clear();

            string[] audits = proxy.GetCalculationAudits();
            Array.Reverse(audits);

            Array.ForEach(audits, text =>
            calculationAudits.Items.Add(text));
            if (calculationAudits.Items.Count == 0)
            {
                calculationAudits.Items.Add("<No Calculations Have Been Submitted Yet>");
            }
        }

        protected void Calculate(object sender, EventArgs e)
        {
            Calculation dto = new Calculation
            {
                Operand1 =
                    float.Parse(operand1.Text)
            };
            try
            {
                dto.Operand2 = float.Parse(operand2.Text);
            }
            catch (FormatException)
            {
                dto.Operand2 = 0;
            }

            Calculation resultDto;
            ICalculator proxy = new CalculatorServiceProxy();
            try
            {
                switch (operation.SelectedValue)
                {
                    case "Add":
                        resultDto = proxy.Add(dto);
                        break;
                    case "Subtract":
                        resultDto = proxy.Subtract(dto);
                        break;
                    case "Multiply":
                        resultDto = proxy.Multiply(dto);
                        break;
                    case "Divide":
                        resultDto = proxy.Divide(dto);
                        break;
                    case "SquareRoot":
                        resultDto = proxy.SquareRoot(dto);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                result.Text = resultDto.Result.ToString();
                PopulateCalculationAudit();
            }
            catch (Exception exception)
            {
                statusMessage.Text = exception.Message;
            }
        }


    }
}
