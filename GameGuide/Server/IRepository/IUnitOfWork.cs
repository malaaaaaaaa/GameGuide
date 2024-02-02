using GameGuide.Shared.Domain;

namespace GameGuide.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Game> Games { get; }
        IGenericRepository<Post> Posts { get; }

        IGenericRepository<Image> Images { get; }

        IGenericRepository<Suggestion> Suggestions { get; }

        IGenericRepository<PostTag> PostTags { get; }
        IGenericRepository<Tag> Tags { get; }

    }
}