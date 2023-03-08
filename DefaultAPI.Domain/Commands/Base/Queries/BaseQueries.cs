using DefaultAPI.Domain.Entities;
using MediatR;

namespace DefaultAPI.Domain.Commands.Base.Queries
{
    public record BaseQueries<T> : IRequest<T> where T : class
    {
        public record FindAsyncQuerie(int Id) : IRequest<T>;
        public record GetAllAsyncQuerie : IRequest<IEnumerable<T>>;
    }
}
