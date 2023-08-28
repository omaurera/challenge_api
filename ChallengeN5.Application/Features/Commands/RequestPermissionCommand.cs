using System;
using AutoMapper;
using ChallengeN5.Application.Contracts;
using ChallengeN5.Application.Responses;
using ChallengeN5.Domain;
using MediatR;

namespace ChallengeN5.Application.Features.Commands
{
	public class RequestPermissionCommand : IRequest<CustomResponse<PermissionResponse>>
	{
        public RequestPermissionCommand(string employeeName, string employeeLastName, int permissionType)
        {
            EmployeeName = employeeName;
            EmployeeLastName = employeeLastName;
            PermissionType = permissionType;
        }

        public string EmployeeName { get; set; }
		public string EmployeeLastName { get; set; }
		public int PermissionType { get; set; }
	}

    public class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand, CustomResponse<PermissionResponse>>
    {
        private readonly IRepositoryBase<Permissions> _repository;
        private readonly IMapper _mapper;

        public RequestPermissionCommandHandler(IRepositoryBase<Permissions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<PermissionResponse>> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _repository.AddEntity(_mapper.Map<Permissions>(request));
            return new CustomResponse<PermissionResponse>
            {
                IsSuccess = true,
                ResponseCode = 200,
                Message = "",
                Data = _mapper.Map<PermissionResponse>(permission)
            };
        }
    }
}

