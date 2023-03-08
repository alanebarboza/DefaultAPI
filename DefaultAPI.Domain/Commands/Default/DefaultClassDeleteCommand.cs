using MediatR;

namespace DefaultAPI.Domain.Commands.Default
{
    public record DefaultClassDeleteCommand(int Id) : IRequest<string>, INotification;
}
