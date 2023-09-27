using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // GET: api/<TokenController>
        [HttpGet]
        public string Get()
        {

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
    }
}
