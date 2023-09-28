using Microsoft.AspNetCore.Mvc;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaAssetsController : ControllerBase
    {
        // GET: api/<MediaAssetsController>
        [HttpGet]
        public string Get([FromQuery] string token)
        {
            string networkId = "14178";
            string networkUrl = "https://networkapi.signagelive.com";

            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}?limit=1000000", networkId, "mediaassets");

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

        // GET api/<MediaAssetController>/5
        [HttpGet("{id}")]
        public string Get([FromQuery] string token, int id)
        {
            string networkId = "14178";
            string networkUrl = "https://networkapi.signagelive.com";

            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}/{2}", networkId, "mediaassets", id);

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

        // POST api/<MediaAssetController>
        [HttpPost]
        public string Post([FromBody] object content, [FromQuery] string token)
        {
            string networkId = "14178";
            string networkUrl = "https://networkapi.signagelive.com";

            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}", networkId, "mediaassets/add");

            RestRequest restRequest = new RestRequest(request_resource, Method.Post);
            restRequest.AddHeader("Authorization", string.Concat("bearer", " ", token));
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
