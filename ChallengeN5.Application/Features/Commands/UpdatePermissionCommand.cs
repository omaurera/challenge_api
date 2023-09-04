using System;
using AutoMapper;
using ChallengeN5.Application.Contracts;
using ChallengeN5.Application.Responses;
using ChallengeN5.Application.Services;
using ChallengeN5.Domain;
using MediatR;

namespace ChallengeN5.Application.Features.Commands
{
    public class UpdatePermissionCommand : IRequest<CustomResponse<PermissionResponse>>
    {
        public UpdatePermissionCommand(int id, string employeeName, string employeeLastName, int permissionType)
        {
            Id = id;
            EmployeeName = employeeName;
            EmployeeLastName = employeeLastName;
            PermissionType = permissionType;
        }

        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionType { get; set; }
    }

    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, CustomResponse<PermissionResponse>>
    {
        private readonly IRepositoryBase<Permissions> _repository;
        private readonly IRepositoryBase<PermissionTypes> _repositoryPermissionTypes;
        private readonly IMapper _mapper;
        private readonly IProduceMessage _produceMessage;

        public UpdatePermissionCommandHandler(IRepositoryBase<Permissions> repository, IMapper mapper, IRepositoryBase<PermissionTypes> repositoryPermissionTypes,
            IProduceMessage produceMessage)
        {
            _repository = repository;
            _repositoryPermissionTypes = repositoryPermissionTypes;
            _mapper = mapper;
            _produceMessage = produceMessage;
        }

        public async Task<CustomResponse<PermissionResponse>> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<PermissionResponse>(await _repository.UpdateEntity(_mapper.Map<Permissions>(request)));
            var permissionType = await _repositoryPermissionTypes.GetById(permission.IdPermissionType);
            permission.PermissionType = permissionType.Description;
            await _produceMessage.CreateMessage(new KafkaResponse
            {
                Id = Guid.NewGuid(),
                NameOperation = "Modify"
            });
            return new CustomResponse<PermissionResponse>
            {
                IsSuccess = true,
                ResponseCode = 200,
                Message = "",
                Data = permission
            };
        }
    }
}

