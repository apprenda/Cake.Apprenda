using System.IO;
using System.ServiceModel.Web;
using System.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace CalculatorService
{
    public class Calculator : ICalculator, ISilverlightClientAccessPolicy
    {

        public Stream GetClientAccessPolicy()
        {
            const string result =
            @"<?xml version=""1.0"" encoding=""utf-8""?>
<access-policy>
<cross-domain-access>
<policy>
<allow-from http-request-headers=""*"">
<domain uri=""*""/>
</allow-from>
<grant-to>
<resource path=""/"" include-subpaths=""true""/>
</grant-to>
</policy>
</cross-domain-access>
</access-policy>";

            if (WebOperationContext.Current != null)
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            }

            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }

        public Calculation Add(Calculation data)
        {
            data.Result = data.Operand1 + data.Operand2;
            AuditCalculation(data, "+");
            return data;

        }

        public Calculation Subtract(Calculation data)
        {
            data.Result = data.Operand1 - data.Operand2;
            AuditCalculation(data, "-");
            return data;

        }

        public Calculation Multiply(Calculation data)
        {
            data.Result = data.Operand1 * data.Operand2;
            AuditCalculation(data, "*");
            return data;

        }

        public Calculation Divide(Calculation data)
        {
            data.Result = data.Operand1 / data.Operand2;
            AuditCalculation(data, "/");
            return data;

        }

        public Calculation SquareRoot(Calculation data)
        {
            data.Result = Math.Sqrt(data.Operand1);
            AuditCalculation(data, "R");
            return data;

        }

        public string[] GetCalculationAudits()
        {
            List<string> results = new List<string>();
            DbProviderFactory providerFactory =
            DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["CalculatorDB"].ProviderName);

            using (DbConnection conn = providerFactory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager
                .ConnectionStrings["CalculatorDB"]
                .ConnectionString;
                DbCommand command = conn.CreateCommand();
                command.CommandText =
                "select operand1, operand2, " +
                "operator, result from calculationaudit";
                conn.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string mathOperator = (string)reader["operator"];
                        if ("R".Equals(mathOperator))
                        {
                            results.Add(string.Format("sqrt({0}) = {1}",
                            reader["operand1"],
                            reader["result"]));
                        }
                        else
                        {
                            results.Add(string.Format("{0} {1} {2} = {3}",
                            reader["operand1"],
                            reader["operator"],
                            reader["operand2"],
                            reader["result"]));
                        }
                    }
                }
            }
            return results.ToArray();

        }

        private static void AuditCalculation(Calculation data,
     string mathOperatorString)
        {
            DbProviderFactory providerFactory =
                        DbProviderFactories.GetFactory(
            ConfigurationManager.ConnectionStrings["CalculatorDB"]
                                                   .ProviderName);
            using (DbConnection conn = providerFactory.CreateConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["CalculatorDB"]
                                   .ConnectionString;

                DbCommand command = conn.CreateCommand();
                command.CommandText =
                    "INSERT INTO CALCULATIONAUDIT" +
                    "(operand1,operand2,operator,result) " +
                    "VALUES(@operand1,@operand2,@operator,@result)";
                DbParameter operand1 = command.CreateParameter();
                operand1.ParameterName = "@operand1";
                operand1.Value = data.Operand1;
                DbParameter operand2 = command.CreateParameter();
                operand2.ParameterName = "@operand2";
                operand2.Value = data.Operand2;
                DbParameter mathOperator = command.CreateParameter();
                mathOperator.ParameterName = "@operator";
                mathOperator.Value = mathOperatorString;
                DbParameter result = command.CreateParameter();
                result.ParameterName = "@result";
                result.Value = data.Result;
                command.Parameters.Add(operand1);
                command.Parameters.Add(operand2);
                command.Parameters.Add(mathOperator);
                command.Parameters.Add(result);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
