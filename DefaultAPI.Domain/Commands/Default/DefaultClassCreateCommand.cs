using DefaultAPI.Domain.Commands.Base;
using DefaultAPI.Domain.Entities;
using DefaultAPI.Domain.Mappings;
using MediatR;

namespace DefaultAPI.Domain.Commands.Default
{
    public record DefaultClassCreateCommand : BaseCreateCommand, IRequest<string>, IMapFrom<DefaultClass>, INotification
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
