using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase, IParameters
    {
        string clientId;
        string clientSecret;
        string authorizationCode;
        string networkId;
        string networkUrl;

        public TokenController()
        {
            IParameters p = new Parameters();
            Parameters pp = p.GetParameters();
            clientId = pp.ClientId;   
            clientSecret = pp.ClientSecret;
            authorizationCode = pp.AuthorizationCode;
            networkId = pp.NetworkId;
            networkUrl = pp.NetWorkUrl;
        }

        // GET: api/<TokenController>
        [HttpGet]
        public string Get()
        {
            //string clientId = "0e69f82c66e8";
            //string clientSecret = "d6b3e9f48518";
            //string authorizationCode = "fFR1vW/L10iSAEjoOfHMSYqcmiZcuspj";
            ////string networkId = "14178";
            //string networkUrl = "https://networkapi.signagelive.com";

            RestClient restClient = new RestClient(networkUrl);
            RestRequest restRequest = new RestRequest("token", Method.Post);
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            restRequest.AddParameter("grant_type", "authorization_code");
            restRequest.AddParameter("client_id", clientId);
            restRequest.AddParameter("client_secret", clientSecret);
            restRequest.AddParameter("code", authorizationCode);

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessful && response.Content != null)
            {
                return response.Content;
            }
            return "{}";
        }

        Parameters IParameters.GetParameters()
        {
            throw new NotImplementedException();
        }
    }
}
