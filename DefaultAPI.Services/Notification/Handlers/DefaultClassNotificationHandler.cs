using DefaultAPI.Domain.Commands.Base;
using DefaultAPI.Domain.Commands.Default;
using DefaultAPI.Domain.Commands.Default.Queries;
using DefaultAPI.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace DefaultAPI.Services.Logs.Handlers
{
    public class DefaultClassNotificationHandler :
          INotificationHandler<NotificationCommand<DefaultClassCreateCommand, string>>,
          INotificationHandler<NotificationCommand<DefaultClassUpdateCommand, string>>,
          INotificationHandler<NotificationCommand<DefaultClassDeleteCommand, string>>,
          INotificationHandler<NotificationCommand<DefaultClassQueries.FindAsyncQuerie, DefaultClass>>,
          INotificationHandler<NotificationCommand<DefaultClassQueries.GetAllAsyncQuerie, IEnumerable<DefaultClass>>>
    {
        public Task Handle(NotificationCommand<DefaultClassCreateCommand, string> notification, CancellationToken cancellationToken)
                    => Task.Run(() => WriteObjectConsole(notification));
        public Task Handle(NotificationCommand<DefaultClassUpdateCommand, string> notification, CancellationToken cancellationToken)
                    => Task.Run(() => WriteObjectConsole(notification));
        public Task Handle(NotificationCommand<DefaultClassDeleteCommand, string> notification, CancellationToken cancellationToken)
                    => Task.Run(() => WriteObjectConsole(notification));
        public Task Handle(NotificationCommand<DefaultClassQueries.FindAsyncQuerie, DefaultClass> notification, CancellationToken cancellationToken)
                    => Task.Run(() => WriteObjectConsole(notification));
        public Task Handle(NotificationCommand<DefaultClassQueries.GetAllAsyncQuerie, IEnumerable<DefaultClass>> notification, CancellationToken cancellationToken)
                    => Task.Run(() => WriteObjectConsole(notification));

        private void WriteObjectConsole(object obj) => Console.WriteLine(JsonConvert.SerializeObject(obj));
    }
}