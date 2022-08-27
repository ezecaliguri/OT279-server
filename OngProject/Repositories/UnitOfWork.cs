using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OngDbContext _context;
        public IRepository<Role> RoleRepository { get; }


        public UnitOfWork(OngDbContext context, IRepository<Role> roleRepository)
        {
            _context = context;
            RoleRepository = roleRepository;
        }

        private IRepository<Members> _membersRepository;
        private IRepository<Organization> _organizationRepository;
        private IRepository<Category> _categoriesRepository;
        private IRepository<User> _usersRepository;
        private IRepository<Activities> _activitiesRepository;
        private IRepository<Comments> _commentsRepository;

        public IRepository<News> NewsRepository { get; private set; }
        private IRepository<Testimonials> _testimonialsRepository;

        public UnitOfWork(OngDbContext context)
        {
            _context = context;
            NewsRepository = new Repository<News>(context);
        }
        
        public IRepository<Organization> OrganizationRepository
        {
            get
            {
                if (_organizationRepository == null)
                {
                    _organizationRepository = new Repository<Organization>(_context);
                }
                return _organizationRepository;
            }
        }



        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IRepository<Category> CategoriesRepository
        {
            get
            {
                if (_categoriesRepository == null)
                {
                    _categoriesRepository = new Repository<Category>(_context);
                }
                return _categoriesRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new Repository<User>(_context);
                }
                return _usersRepository;
            }
        }


        public IRepository<Testimonials> TestiomonialsRepository
        {
            get
            {
                if (_testimonialsRepository == null)
                {
                    _testimonialsRepository = new Repository<Testimonials>(_context);
                }
                return _testimonialsRepository;
             }
            }

        public IRepository<Activities> ActivitiesRepository
        {
            get
            {
                if (_activitiesRepository == null)
                {
                    _activitiesRepository = new Repository<Activities>(_context);
                }
                return _activitiesRepository;
            }
        }

        public IRepository<Members> MembersRepository
        {
            get
            {
                if (_membersRepository == null)
                {
                    _membersRepository = new Repository<Members>(_context);
                }
                return _membersRepository;
            }
        }


        public IRepository<Comments> CommentsRepository
        {
            get
            {
                if (_commentsRepository == null)
                {
                    _commentsRepository = new Repository<Comments>(_context);
                }
                return _commentsRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
