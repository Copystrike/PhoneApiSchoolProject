using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneApiSchoolProject.Controllers;
using PhoneApiSchoolProject.Mapper;
using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.Services;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Tests.controllers;

[TestFixture]
public class OsControllerTests
{
    private List<OsModel> _osModels;
    private OsModel _osModel;
    private Mock<IOsService> _mock;
    private OsController _controller;

    [SetUp]
    public void Setup()
    {
        _mock = new Mock<IOsService>();

        _osModels =
        [
            new(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"), "Android", "v11", "Google",
                new DateTime(2008, 9, 23), true),

            new(Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e"), "iOS", "v14", "Apple", new DateTime(2007, 6, 29),
                false),

            new(Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca"), "Windows", "v10", "Microsoft",
                new DateTime(2000, 1, 1), false),

            new(Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646"), "Linux", "v5.10", "Linux Foundation",
                new DateTime(1991, 8, 25), true)
        ];
        
        _osModel = _osModels[0];

        _mock.Setup(service => service.GetAllOs()).Returns(_osModels);
        
        _controller = new OsController(_mock.Object);
    }

    [Test]
    public void OsController_GetOs_ReturnsListOfOs()
    {
        
        var result = _controller.GetAllOs();

        
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_GetOsById_ReturnsOs()
    {
        _mock.Setup(service => service.GetOsById(It.IsAny<Guid>())).Returns(_osModel);
        
        var result = _controller.GetOsById(_osModel.Id);
        
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_GetOsById_ReturnsNotFound()
    {
        _mock.Setup(service => service.GetOsById(It.IsAny<Guid>())).Returns((OsModel) null);
        
        var result = _controller.GetOsById(Guid.NewGuid());

        Assert.That(result, Is.TypeOf<NotFoundResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_CreateOs_ReturnsOs()
    {
        _mock.Setup(service => service.CreateOs(It.IsAny<CreateOsView>())).Returns(_osModel);
        
        var result = _controller.CreateOs(new CreateOsView()
        {
            Name = _osModel.Name,
            Version = _osModel.Version,
            Manufacturer = _osModel.Manufacturer,
            ReleaseDate = _osModel.ReleaseDate,
            IsOpenSource = _osModel.IsOpenSource
        });

        
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_UpdateOs_ReturnsOs()
    {
        _mock.Setup(service => service.UpdateOs(It.IsAny<UpdateOsView>())).Returns(_osModel);
        
        var result = _controller.UpdateOs(new UpdateOsView()
        {
            Id = _osModel.Id,
            Name = _osModel.Name
        });
        
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_DeleteOs_ReturnsOk()
    {
        _mock.Setup(service => service.DeleteOs(It.IsAny<Guid>()));
        
        var result = _controller.DeleteOs(_osModel.Id);
        
        Assert.That(result, Is.TypeOf<OkResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_SearchOs_ReturnsListOfOs()
    {
        _mock.Setup(service => service.SearchOs(It.IsAny<string>())).Returns(_osModels);
        
        var result = _controller.SearchOs(_osModel.Name);
        
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [TearDown]
    public void TearDown()
    {
        _osModels = null;
        _osModel = null;
        _mock = null;
        _controller = null;
    }
}