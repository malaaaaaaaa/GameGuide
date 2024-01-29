public class HttpAnonymousClientFactory : IHttpAnonymousClientFactory
{
    private readonly IHttpClientFactory httpClientFactory;

    public HttpAnonymousClientFactory(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public HttpClient HttpClient => httpClientFactory.CreateClient("GameGuide.ServerAPI.Anonymous");
}