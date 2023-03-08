using AutoMapper;
using DefaultAPI.Domain.Commands.Base;
using DefaultAPI.Domain.Commands.Default;
using DefaultAPI.Domain.Commands.Default.Queries;
using DefaultAPI.Domain.Entities;
using DefaultAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace DefaultAPI.Services.Handlers
{
    public class DefaultClassHandler :
      IRequestHandler<DefaultClassCreateCommand, string>,
      IRequestHandler<DefaultClassUpdateCommand, string>,
      IRequestHandler<DefaultClassDeleteCommand, string>,
      IRequestHandler<DefaultClassQueries.FindAsyncQuerie, DefaultClass>,
      IRequestHandler<DefaultClassQueries.GetAllAsyncQuerie, IEnumerable<DefaultClass>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IDefaultRepository _defaultRepository;

        public DefaultClassHandler(IMapper mapper, IDefaultRepository defaultRepository, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _defaultRepository = defaultRepository;
        }
        public async Task<string> Handle(DefaultClassCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DefaultClass>(request);
            await _defaultRepository.AddAsync(entity);
            var msg = "Registro adicionado com sucesso";
            await _mediator.Publish(new NotificationCommand<DefaultClassCreateCommand, string>(request, msg));
            return msg;
        }
        public async Task<string> Handle(DefaultClassUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DefaultClass>(request);
            await _defaultRepository.UpdateAsync(entity);
            var msg = "Registro alterado com sucesso";
            await _mediator.Publish(new NotificationCommand<DefaultClassUpdateCommand, string>(request, msg));
            return msg;

        }
        public async Task<string> Handle(DefaultClassDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _defaultRepository.FindAsync(request.Id);
            await _defaultRepository.RemoveAsync(entity);
            var msg = "Registro removido com sucesso";
            await _mediator.Publish(new NotificationCommand<DefaultClassDeleteCommand, string>(request, msg));
            return msg;

        }
        public async Task<DefaultClass> Handle(DefaultClassQueries.FindAsyncQuerie request, CancellationToken cancellationToken)
        {
            var response = await _defaultRepository.FindAsync(request.Id);
            await _mediator.Publish(new NotificationCommand<DefaultClassQueries.FindAsyncQuerie, DefaultClass>(request, response));
            return response;
        }
        public async Task<IEnumerable<DefaultClass>> Handle(DefaultClassQueries.GetAllAsyncQuerie request, CancellationToken cancellationToken)
        {
            var response = await _defaultRepository.GetAllAsync();
            await _mediator.Publish(new NotificationCommand<DefaultClassQueries.GetAllAsyncQuerie,IEnumerable<DefaultClass>>(request, response));
            return response;
        }
    }
}
