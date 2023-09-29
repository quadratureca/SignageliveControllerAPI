using Microsoft.AspNetCore.Mvc;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaAssetsController : ControllerBase
    {
        string networkId;
        string networkUrl;

        public MediaAssetsController()
        {
            IParameters p = new Parameters();
            Parameters pp = p.GetParameters();
            networkId = pp.NetworkId;
            networkUrl = pp.NetWorkUrl;
        }
        // GET: api/<MediaAssetsController>
        [HttpGet]
        public string Get([FromHeader] string authorization, string? limit = null, string? types = null)
        {
            int notNullCount = 0;

            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}", networkId, "mediaassets");

            if (limit != null)
            {
                notNullCount++;
                if (notNullCount == 1)
                    request_resource += string.Format("?limit={0}", limit);
                else
                    request_resource += string.Format("&limit={0}", limit);
            }
            if (types != null)
            {
                notNullCount++;
                if (notNullCount == 1)
                    request_resource += string.Format("?types={0}", types);
                else
                    request_resource += string.Format("&types={0}", types);
            }

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

        // GET api/<MediaAssetController>/5
        [HttpGet("{id}")]
        public string Get([FromHeader] string authorization, int id)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}/{2}", networkId, "mediaassets", id);

            RestRequest restRequest = new RestRequest(request_resource, Method.Get);
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("Content-Type", "application/json");

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessful && response.Content != null)
            {
                return response.Content;
            }
            return "[]";
        }

        // POST api/<MediaAssetController>
        [HttpPost]
        public string Post([FromBody] object content, [FromHeader] string authorization)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}", networkId, "mediaassets/add");

            RestRequest restRequest = new RestRequest(request_resource, Method.Post);
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddBody(content);

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                return response.Content;
            }
            return "{}";
        }

        // PUT api/<MediaAssetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MediaAssetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
