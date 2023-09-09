using ChallengeN5.Application.Contracts;
using ChallengeN5.Application.Responses;
using ChallengeN5.Domain;
using MediatR;

namespace ChallengeN5.Application.Features.Commands
{
	public class DeletePermissionCommand : IRequest<CustomResponse<bool>>
	{
        public DeletePermissionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, CustomResponse<bool>>
    {
        private readonly IRepositoryBase<Permissions> _repository;

        public DeletePermissionCommandHandler(IRepositoryBase<Permissions> repository)
        {
            _repository = repository;
        }

        public async Task<CustomResponse<bool>> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _repository.GetById(request.Id);
            return new CustomResponse<bool>
            {
                IsSuccess = true,
                ResponseCode = 200,
                Message = "",
                Data = await _repository.DeleteEntity(permission)
            };
        }
    }
}

