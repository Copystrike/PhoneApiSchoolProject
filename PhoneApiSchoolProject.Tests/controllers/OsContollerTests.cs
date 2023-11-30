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
    private Mock<IOsService> _mock;
    private IMapper _mapper;

    // void Setup();
    // void PhoneController_GetPhones_ReturnsListOfPhones();
    // void PhoneController_GetPhoneById_ReturnsPhone();
    // void PhoneController_GetPhoneById_ReturnsNotFound();
    // void PhoneController_GetPhonesByBrand_ReturnsListOfPhones();
    // void PhoneController_GetPhonesByBrand_ReturnsNotFound();
    // void PhoneController_CreatePhone_ReturnsPhone();
    // void PhoneController_UpdatePhone_ReturnsPhone();
    // void PhoneController_UpdatePhone_ReturnsNotFound();
    // void PhoneController_DeletePhone_ReturnsOk();
    // void PhoneController_SearchPhones_ReturnsListOfPhones();
    // void PhoneController_SearchPhones_ReturnsNotFound();
    // void TearDown();

    [SetUp]
    public void Setup()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<OsProfile>());

        _mock = new Mock<IOsService>();

        _osModels = new List<OsModel>()
        {
            new(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"), "Android", "v11", "Google",
                new DateTime(2008, 9, 23), true),
            new(Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e"), "iOS", "v14", "Apple", new DateTime(2007, 6, 29),
                false),
            new(Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca"), "Windows", "v10", "Microsoft",
                new DateTime(2000, 1, 1), false),
            new(Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646"), "Linux", "v5.10", "Linux Foundation",
                new DateTime(1991, 8, 25), true),
        };
        
        _mock.Setup(service => service.GetAllOs()).Returns(_osModels);

        _mapper = configuration.CreateMapper();
    }

    [Test]
    public void OsController_GetOs_ReturnsListOfOs()
    {
        // Arrange
        var controller = new OsController(_mock.Object, _mapper);

        // Act
        var result = controller.GetAllOs();

        // Assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_GetOsById_ReturnsOs()
    {
        // Arrange
        var osModel = _osModels[0];
        _mock.Setup(service => service.GetOsById(osModel.Id)).Returns(osModel);
        var controller = new OsController(_mock.Object, _mapper);

        // Act
        var result = controller.GetOsById(osModel.Id);

        // Assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_GetOsById_ReturnsNotFound()
    {
        // Arrange
        var osModel = _osModels[0];
        _mock.Setup(service => service.GetOsById(osModel.Id)).Returns(osModel);
        var controller = new OsController(_mock.Object, _mapper);

        // Act
        var result = controller.GetOsById(Guid.NewGuid());

        // Assert
        Assert.That(result, Is.TypeOf<NotFoundResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_CreateOs_ReturnsOs()
    {
        // Arrange
        var osModel = _osModels[0];
        _mock.Setup(service => service.CreateOs(osModel)).Returns(osModel);
        var controller = new OsController(_mock.Object, _mapper);

        // Act
        var result = controller.CreateOs(new CreateOsView()
        {
            Name = osModel.Name,
            Version = osModel.Version,
            Manufacturer = osModel.Manufacturer,
            ReleaseDate = osModel.ReleaseDate,
            IsOpenSource = osModel.IsOpenSource
        });

        // Assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_UpdateOs_ReturnsOs()
    {
        // Arrange
        var osModel = _osModels[0];
        _mock.Setup(service => service.UpdateOs(It.IsAny<OsModel>())).Returns(osModel);
        var controller = new OsController(_mock.Object, _mapper);
        
        // Act
        var result = controller.UpdateOs(new UpdateOsView()
        {
            Id = osModel.Id,
            Name = osModel.Name
        });

        // Assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_UpdateOs_ReturnsNotFound()
    {
        // Arrange
        var osModel = _osModels[0];
        _mock.Setup(service => service.UpdateOs(osModel));
        var controller = new OsController(_mock.Object, _mapper);

        // Act
        var result = controller.UpdateOs(new UpdateOsView()
        {
            Id = Guid.NewGuid(),
            Name = osModel.Name,
            Version = osModel.Version,
            Manufacturer = osModel.Manufacturer,
            ReleaseDate = osModel.ReleaseDate,
            IsOpenSource = osModel.IsOpenSource
        });

        // Assert
        Assert.That(result, Is.TypeOf<NotFoundResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_DeleteOs_ReturnsOk()
    {
        // Arrange
        var osModel = _osModels[0];
        _mock.Setup(service => service.DeleteOs(osModel.Id));
        var controller = new OsController(_mock.Object, _mapper);

        // Act
        var result = controller.DeleteOs(osModel.Id);

        // Assert
        Assert.That(result, Is.TypeOf<OkResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void OsController_SearchOs_ReturnsListOfOs()
    {
        // Arrange
        var osModel = _osModels[0];
        _mock.Setup(service => service.SearchOs(osModel.Name)).Returns(_osModels);
        var controller = new OsController(_mock.Object, _mapper);

        // Act
        var result = controller.SearchOs(osModel.Name);

        // Assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [TearDown]
    public void TearDown()
    {
        _osModels = null;
        _mock = null;
        _mapper = null;
    }
}