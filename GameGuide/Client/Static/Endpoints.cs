

namespace GameGuide.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string GamesEndpoint = $"{Prefix}/games";

        public static readonly string CategoriesEndpoint = $"{Prefix}/categories";

        public static readonly string PostsEndpoint = $"{Prefix}/posts";

        public static readonly string ImagesEndpoint = $"{Prefix}/images";
    }
}
