using Microsoft.AspNetCore.Mvc;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworksController : ControllerBase
    {
        string networkId;
        string networkUrl;

        public NetworksController()
        {
            IParameters p = new Parameters();
            Parameters pp = p.GetParameters();
            networkId = pp.NetworkId;
            networkUrl = pp.NetWorkUrl;
        }

        // GET: api/<NetworksController>
        [HttpGet]
        public string Get([FromHeader] string authorization)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}", networkId);

            RestRequest restRequest = new RestRequest(request_resource, Method.Get);
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("Content-Type", "application/json");

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessful && response.Content != null)
            {
                return response.Content;
            }
            return "{}";
        }

        // POST api/<NetworksController>
        [HttpPost]
        public string Post([FromHeader] string authorization, [FromBody] string networkRequestObject)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/");

            RestRequest restRequest = new RestRequest(request_resource, Method.Post);
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("Content-Type", "application/json");

            restRequest.AddJsonBody<string>(networkRequestObject);

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                return response.Content;
            }
            return "{}";
        }
    }
}
