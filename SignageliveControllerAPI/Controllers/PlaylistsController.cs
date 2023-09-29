using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        string networkId;
        string networkUrl;

        public PlaylistsController()
        {
            IParameters p = new Parameters();
            Parameters pp = p.GetParameters();
            networkId = pp.NetworkId;
            networkUrl = pp.NetWorkUrl;
        }

        // GET: api/<PlaylistController>
        [HttpGet]
        public string Get([FromHeader] string authorization, string? limit = null, string? search = null)
        {
            int notNullCount = 0;
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}", networkId, "playlists");

            if (limit != null)
            {
                notNullCount++;
                if (notNullCount == 1)
                    request_resource += string.Format("?limit={0}", limit);
                else
                    request_resource += string.Format("&limit={0}", limit);
            }
            if (search != null)
            {
                notNullCount++;
                if (notNullCount == 1)
                    request_resource += string.Format("?search={0}", search);
                else
                    request_resource += string.Format("&search={0}", search);
            }

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

        // GET api/<PlaylistController>/5
        [HttpGet("{id}")]
        public string Get(int id, [FromQuery] string token)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}/{2}", networkId, "playlists", id);

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

        // POST api/<PlaylistController>
        [HttpPost]
        public string Post([FromBody] string playlistName, [FromQuery] string token)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}", networkId, "playlists");

            RestRequest restRequest = new RestRequest(request_resource, Method.Post);
            restRequest.AddHeader("Authorization", string.Concat("bearer", " ", token));
            restRequest.AddHeader("Content-Type", "application/json");

            string json = string.Format(@"{{ ""name"": ""{0}"" }}", playlistName);
            restRequest.AddJsonBody<string>(json);

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                return response.Content;
            }
            return "{}";
        }

        // PUT api/<PlaylistController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlaylistController>/5
        [HttpDelete("{id}")]
        public string Delete(int id, [FromQuery] string token)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}/{2}", networkId, "playlists", id);

            RestRequest restRequest = new RestRequest(request_resource, Method.Delete);
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
