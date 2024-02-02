using GameGuide.Server.Data;
using GameGuide.Server.IRepository;
using GameGuide.Server.Models;
using GameGuide.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameGuide.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IGenericRepository<Category> _categories;
        private IGenericRepository<Game> _games;
        private IGenericRepository<Post> _posts;
        private IGenericRepository<Image> _images;
        private IGenericRepository<Suggestion> _suggestions;
        private IGenericRepository<PostTag> _postTags;
        private IGenericRepository<Tag> _tags;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Category> Categories 
            => _categories ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Game> Games 
            => _games ??= new GenericRepository<Game>(_context);
        public IGenericRepository<Post> Posts
            => _posts ??= new GenericRepository<Post>(_context);
        public IGenericRepository<Image> Images
            => _images ??= new GenericRepository<Image>(_context);
        public IGenericRepository<Suggestion> Suggestions
            => _suggestions ??= new GenericRepository<Suggestion>(_context);
        public IGenericRepository<Tag> Tags
            => _tags ??= new GenericRepository<Tag>(_context);
        public IGenericRepository<PostTag> PostTags
            => _postTags ??= new GenericRepository<PostTag>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).Created = DateTime.Now;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}