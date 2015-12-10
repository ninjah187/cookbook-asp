using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cookbook.Models;
using Ninject;

namespace Cookbook.Services.EFRepositories
{
    public class EFUserRepository : EFBaseRepository<User>, IUserRepository
    {
        [Inject]
        public EFUserRepository(IDbContextService dbContextService)
            : base(dbContextService)
        {
        }

        public override void Add(dynamic itemInfo)
        {
            throw new NotImplementedException();
        }

        public override void Update(int id, User newItem)
        {
            throw new NotImplementedException();
        }

        public override void Update(User item, User newItem)
        {
            throw new NotImplementedException();
        }

        public User GetByLogin(string login)
        {
            var user = DbContextService.Users.SingleOrDefault(u => u.Login == login);
            return user;
        }
    }
}