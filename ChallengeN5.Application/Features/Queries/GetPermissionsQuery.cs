using System;
using AutoMapper;
using ChallengeN5.Application.Contracts;
using ChallengeN5.Application.Responses;
using ChallengeN5.Domain;
using MediatR;

namespace ChallengeN5.Application.Features.Queries
{
	public class GetPermissionsQuery : IRequest<CustomMultipleResponse<PermissionResponse>>
	{
		public GetPermissionsQuery()
		{
		}
	}

    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, CustomMultipleResponse<PermissionResponse>>
    {
        private readonly IRepositoryBase<Permissions> _repository;
        private readonly IMapper _mapper;

        public GetPermissionsQueryHandler(IRepositoryBase<Permissions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomMultipleResponse<PermissionResponse>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _repository.GetAll();
            return new CustomMultipleResponse<PermissionResponse>
            {
                IsSuccess = true,
                ResponseCode = 200,
                Message = "",
                Data = _mapper.Map<List<PermissionResponse>>(permissions)
            };
        }
    }
}

