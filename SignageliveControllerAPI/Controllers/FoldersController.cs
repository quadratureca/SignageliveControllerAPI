using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        string networkId;
        string networkUrl;

        public FoldersController()
        {
            IParameters p = new Parameters();
            Parameters pp = p.GetParameters();
            networkId = pp.NetworkId;
            networkUrl = pp.NetWorkUrl;
        }

        // GET: api/<FoldersController>
        [HttpGet]
        public string Get([FromQuery] string token, string? limit = null, string? type = null)
        {
            int notNullCount = 0;

            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}", networkId, "folders");

            if (limit != null)
            {
                notNullCount++;
                if (notNullCount == 1)
                    request_resource += string.Format("?limit={0}", limit);
                else
                    request_resource += string.Format("&limit={0}", limit);
            }
            if (type != null)
            {
                notNullCount++;
                if (notNullCount == 1)
                    request_resource += string.Format("?types={0}", type);
                else
                    request_resource += string.Format("&types={0}", type);
            }

            RestRequest restRequest = new RestRequest(request_resource, Method.Get);
            restRequest.AddHeader("Authorization", string.Concat("bearer", " ", token));
            restRequest.AddHeader("Content-Type", "application/json");

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessful && response.Content != null)
            {
                return response.Content;
            }
            return "[]";
        }

        // GET api/<FoldersController>/5
        [HttpGet("{id}")]
        public string Get([FromQuery] string token, int id)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}/{2}", networkId, "folders", id);

            RestRequest restRequest = new RestRequest(request_resource, Method.Get);
            restRequest.AddHeader("Authorization", string.Concat("bearer", " ", token));
            restRequest.AddHeader("Content-Type", "application/json");

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessful && response.Content != null)
            {
                return response.Content;
            }
            return "{}";
        }
    }
}
