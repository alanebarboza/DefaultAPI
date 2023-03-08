
using DefaultAPI.Domain.Entities;
using DefaultAPI.Domain.Interfaces.Repositories;
using DefaultAPI.Infra.Context;
using DefaultAPI.Infra.Repositories.Base;

namespace DefaultAPI.Infra.Repositories
{
    public class DefaultReposotory : BaseRepository<DefaultClass>, IDefaultRepository
    {
        public DefaultReposotory(DefaultDbContext context) : base(context)
        {
        }
    }
}
