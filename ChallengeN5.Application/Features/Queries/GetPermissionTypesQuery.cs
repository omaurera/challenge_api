using ChallengeN5.Application.Contracts;
using ChallengeN5.Application.Responses;
using ChallengeN5.Domain;
using MediatR;

namespace ChallengeN5.Application.Features.Queries
{
    public class GetPermissionTypesQuery : IRequest<CustomMultipleResponse<PermissionTypes>>
	{
	}

    public class GetPermissionTypesQueryHandler : IRequestHandler<GetPermissionTypesQuery, CustomMultipleResponse<PermissionTypes>>
    {
        private readonly IRepositoryBase<PermissionTypes> _repository;

        public GetPermissionTypesQueryHandler(IRepositoryBase<PermissionTypes> repository)
        {
            _repository = repository;
        }

        public async Task<CustomMultipleResponse<PermissionTypes>> Handle(GetPermissionTypesQuery request, CancellationToken cancellationToken)
        {
            var permissionTypes = await _repository.GetAll();
            return new CustomMultipleResponse<PermissionTypes>
            {
                IsSuccess = true,
                ResponseCode = 200,
                Message = "",
                Data = permissionTypes.ToList()
            };
        }
    }
}

