using AutoMapper;
using ChallengeN5.Application.Contracts;
using ChallengeN5.Application.Responses;
using ChallengeN5.Application.Services;
using ChallengeN5.Domain;
using MediatR;

namespace ChallengeN5.Application.Features.Queries
{
	public class GetPermissionsQuery : IRequest<CustomMultipleResponse<PermissionResponse>>
	{
	}

    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, CustomMultipleResponse<PermissionResponse>>
    {
        private readonly IRepositoryBase<Permissions> _repository;
        private readonly IRepositoryBase<PermissionTypes> _repositoryPermissionTypes;
        private readonly IMapper _mapper;
        private readonly IProduceMessage _produceMessage;

        public GetPermissionsQueryHandler(IRepositoryBase<Permissions> repository, IMapper mapper, IRepositoryBase<PermissionTypes> repositoryPermissionTypes,
            IProduceMessage produceMessage)
        {
            _repository = repository;
            _repositoryPermissionTypes = repositoryPermissionTypes;
            _mapper = mapper;
            _produceMessage = produceMessage;
        }

        public async Task<CustomMultipleResponse<PermissionResponse>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = _mapper.Map<List<PermissionResponse>>(await _repository.GetAll());
            foreach (var permission in permissions)
            {
                var permissionType = await _repositoryPermissionTypes.GetById(permission.IdPermissionType);
                permission.PermissionType = permissionType.Description;
            }
            await _produceMessage.CreateMessage(new KafkaResponse
            {
                Id = Guid.NewGuid(),
                NameOperation = "Get"
            });
            return new CustomMultipleResponse<PermissionResponse>
            {
                IsSuccess = true,
                ResponseCode = 200,
                Message = "",
                Data = permissions
            };
        }
    }
}

