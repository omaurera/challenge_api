using AutoMapper;
using ChallengeN5.Application.Contracts;
using ChallengeN5.Application.Features.Commands;
using ChallengeN5.Application.Features.Queries;
using ChallengeN5.Application.Responses;
using ChallengeN5.Application.Services;
using ChallengeN5.Domain;

namespace ChallengeN5.Test;

[TestClass]
public class UnitTest1
{
    private readonly IRepositoryBase<Permissions> _repository;
    private readonly IRepositoryBase<PermissionTypes> _repositoryPermissionTypes;
    private readonly IMapper _mapper;
    private readonly IProduceMessage _produceMessage;

    public UnitTest1(IRepositoryBase<Permissions> repository, IRepositoryBase<PermissionTypes> repositoryPermissionTypes, IMapper mapper, IProduceMessage produceMessage)
    {
        _repository = repository;
        _repositoryPermissionTypes = repositoryPermissionTypes;
        _mapper = mapper;
        _produceMessage = produceMessage;
    }

    [TestMethod]
    public async void TestGetPermissions()
    {
        var handler = new GetPermissionsQueryHandler(_repository, _mapper, _repositoryPermissionTypes, _produceMessage);
        var response = await handler.Handle(new GetPermissionsQuery(), CancellationToken.None);
        Assert.IsTrue(response.Data.Count() > 0);
    }

    [TestMethod]
    public async void TestRequestPermission()
    {
        var handler = new RequestPermissionCommandHandler(_repository, _mapper, _repositoryPermissionTypes, _produceMessage);
        var response = await handler.Handle(new RequestPermissionCommand("Jose", "Perez", 1), CancellationToken.None);
        Assert.IsTrue(response.Data != null);
    }

    [TestMethod]
    public async void TestUpdatePermission()
    {
        var handler = new UpdatePermissionCommandHandler(_repository, _mapper, _repositoryPermissionTypes, _produceMessage);
        var response = await handler.Handle(new UpdatePermissionCommand(1, "Jose", "Perez", 1), CancellationToken.None);
        Assert.IsTrue(response.Data != null);
    }
}
