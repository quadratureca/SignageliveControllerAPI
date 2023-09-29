# SignageliveControllerAPI

This is a C# .Net Core proxy for the Signagelive API. 

You will need to provide a Parameters class which provides the following values: ClientId, ClientSecret, NetworkId, AuthorizationCode and NetworkUrl. Some code along the lines of the following will do the trick.

```
namespace SignageliveControllerAPI
{
    public interface IParameters
    {
        Parameters GetParameters();
    }

    public class Parameters : IParameters
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string NetworkId { get; set; }
        public string AuthorizationCode { get; set; }
        public string NetWorkUrl { get; set; }

        public Parameters GetParameters()
        {
            Parameters parameters = new Parameters
            {
                ClientId = "ClientId",
                ClientSecret = "ClientSecret",
                NetworkId = "NetworkId",
                AuthorizationCode = "AuthorizationCode",
                NetWorkUrl = "NetworkUrl"
            };

            return parameters;
        }
    }
}
```
