using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CalculatorService
{
    [ServiceContract]
    public interface ISilverlightClientAccessPolicy
    {
        [OperationContract, WebGet(UriTemplate = "/clientaccesspolicy.xml")]
        Stream GetClientAccessPolicy();
    }
}