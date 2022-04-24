using System;
using System.Threading.Tasks;
using Maypaper.Data.Abstract;
using Maypaper.Data.Concrete.EntityFramework.Contexts;
using Maypaper.Data.Concrete.EntityFramework.Repositories;
using Maypaper.Data.UnitOfWork.Abstract;

namespace Maypaper.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MaypaperContext _context;
        private ArticleRepository _articleRepository;
        private CategoryRepository _categoryRepository;
        private QuestionRepository _questionRepository;
        private RoleRepository _roleRepository;
        private UserRepository _userRepository;

        public UnitOfWork(MaypaperContext context)
        {
            _context = context;
        }

        public IArticleRepository Articles => _articleRepository ?? new ArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public IQuestionRepository Questions => _questionRepository ?? new QuestionRepository(_context);

        public IRoleRepository Roles => _roleRepository ?? new RoleRepository(_context);

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            // savechangesAsnyc integer sonuç dönüyor. Bu nedenle int olarak tanımlattık.
            // Şu kadar kayıt etkilendi şeklinde bir bildirim döndürebiliriz.
            return await _context.SaveChangesAsync();
        }
    }
}
