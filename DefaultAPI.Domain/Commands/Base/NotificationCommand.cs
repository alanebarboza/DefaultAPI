using MediatR;

namespace DefaultAPI.Domain.Commands.Base
{
    public record NotificationCommand<Tin, TOut>(Tin Request, TOut Response) : INotification;
}
