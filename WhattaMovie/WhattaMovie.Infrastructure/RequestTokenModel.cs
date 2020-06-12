namespace WhattaMovie.Infrastructure
{
    public class RequestTokenModel
    {
        public string ApiKey { get; set; }
        public string Secret { get; set; }

        public RequestTokenModel() { }

        public RequestTokenModel(string apiKey, string secret)
        {
            this.ApiKey = apiKey;
            this.Secret = secret;
        }
    }
}
