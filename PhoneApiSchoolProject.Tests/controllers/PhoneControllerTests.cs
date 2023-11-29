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
public class PhoneControllerTests
{
    private List<PhoneModel> _phones;
    private Mock<IPhoneService> _mockPhoneService;
    private IMapper _mapper;
    
    private void InitializePhoneList()
    {
        _phones = new List<PhoneModel>
        {
            // Apple1
            new(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"), "Apple", "GOLD", 8, 256,
                Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            // Apple2
            new(Guid.Parse("6a742018-c647-4a82-b216-3a3465788823"), "Apple", "BLACK", 16, 512,
                Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            // OnePlus1
            new(Guid.Parse("69c1f411-c766-4911-aae7-a434acbef698"), "OnePlus", "AQUA", 16, 256,
                Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            // Nothing1
            new(Guid.Parse("7c307e4e-5271-4ffb-bf04-10422e6ef539"), "Nothing", "BLACK", 16, 512,
                Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            // Windows1
            new(Guid.Parse("1a0cf907-3880-4d6f-9219-7f7318a2cc3b"), "Windows", "BLACK", 16, 512,
                Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca")),
            // Linux1
            new(Guid.Parse("d6478374-c67e-42a4-a319-c46eca5146f7"), "Linux", "BLACK", 16, 512,
                Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646"))
        };
    }

    [SetUp]
    public void Setup()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<PhoneProfile>();
            cfg.AddProfile<OsProfile>();
            cfg.AddProfile<AppProfile>();
        });


        InitializePhoneList();

        _mockPhoneService = new Mock<IPhoneService>();

        _mapper = configuration.CreateMapper();
    }

    [Test]
    public void PhoneController_GetPhones_ReturnsListOfPhones()
    {
        
        // Reset
        InitializePhoneList();
        
        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        var controller = new PhoneController(mockPhoneService.Object, _mapper);
        mockPhoneService.Setup(service => service.GetAllPhones()).Returns(_phones);

        // Act
        var result = controller.GetAllPhones() as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<List<PhoneModel>>(result.Value);
    }

    [Test]
    public void PhoneController_GetPhoneById_ReturnsPhone()
    {
        
        // Reset
        InitializePhoneList();
        
        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.GetPhoneById(It.IsAny<Guid>())).Returns(new PhoneModel(
            Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"),
            "Apple",
            "GOLD",
            8,
            256,
            Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")
        ));

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.GetPhoneById(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<PhoneModel>(result.Value);
    }

    [Test]
    public void PhoneController_GetPhoneById_ReturnsNotFound()
    {
        // Reset
        InitializePhoneList();
        
        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.GetPhoneById(It.IsAny<Guid>())).Returns((PhoneModel)null);

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.GetPhoneById(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")) as NotFoundResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public void PhoneController_GetPhonesByBrand_ReturnsListOfPhones()
    {
        // Reset
        InitializePhoneList();

        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.GetPhonesByBrand(It.IsAny<string>())).Returns(_phones);

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.GetPhonesByBrand("Apple") as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<List<PhoneModel>>(result.Value);
    }

    [Test]
    public void PhoneController_GetPhonesByBrand_ReturnsNotFound()
    {
        // Reset
        InitializePhoneList();

        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.GetPhonesByBrand(It.IsAny<string>())).Returns((List<PhoneModel>)null);

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.GetPhonesByBrand("Apple") as NotFoundResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public void PhoneController_CreatePhone_ReturnsPhone()
    {
        // Reset
        InitializePhoneList();

        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.CreatePhone(It.IsAny<PhoneModel>())).Returns(new PhoneModel
        (
            Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"),
            "Apple",
            "GOLD",
            8,
            256,
            Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")
        ));

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.CreatePhone(new CreatePhoneView()
        {
            Brand = "Apple",
            Color = "GOLD",
            Memory = 8,
            Storage = 256,
            OsId = Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")
        }) as OkObjectResult;
        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<PhoneModel>(result.Value);
    }

    [Test]
    public void PhoneController_UpdatePhone_ReturnsPhone()
    {
        // Reset
        InitializePhoneList();

        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.UpdatePhone(It.IsAny<PhoneModel>())).Returns(new PhoneModel
        (
            Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"),
            "Apple",
            "GOLD",
            8,
            256,
            Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")
        ));

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.UpdatePhone(new UpdatePhoneView()
        {
            Id = Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"),
            Brand = "Apple",
            Color = "GOLD",
            Memory = 8,
            Storage = 256,
            OsId = Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")
        }) as OkObjectResult;
        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<PhoneModel>(result.Value);
    }

    [Test]
    public void PhoneController_UpdatePhone_ReturnsBadRequest()
    {
        // Reset
        InitializePhoneList();

        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.UpdatePhone(It.IsAny<PhoneModel>())).Returns(new PhoneModel
        (
            Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"),
            "Apple",
            "GOLD",
            8,
            256,
            Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")
        ));

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.UpdatePhone(new UpdatePhoneView()
        {
            Id = Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"),
            Brand = "Apple",
            Color = "GOLD",
            Memory = 8,
            Storage = 256,
            OsId = Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")
        }) as BadRequestResult;
        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<BadRequestResult>(result);
    }

    [Test]
    public void PhoneController_DeletePhone_ReturnsOk()
    {
        // Reset
        InitializePhoneList();

        // Reset
        _mockPhoneService.Reset();


        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.DeletePhone(It.IsAny<Guid>()));

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.DeletePhone(
            Guid.Parse("69c1f411-c766-4911-aae7-a434acbef698")
        ) as OkResult;
        
        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<OkResult>(result);
    }

    [Test]
    public void PhoneController_DeletePhone_ReturnsNotFound()
    {
        // Reset
        InitializePhoneList();

        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.DeletePhone(It.IsAny<Guid>()));

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.DeletePhone(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")) as NotFoundResult;
        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public void PhoneController_SearchPhones_ReturnsListOfPhones()
    {
        // Reset
        InitializePhoneList();

        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.SearchPhones(It.IsAny<string>())).Returns(_phones);

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.SearchPhones("Apple") as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<List<PhoneModel>>(result.Value);
    }

    [Test]
    public void PhoneController_SearchPhones_ReturnsNotFound()
    {
        // Reset
        InitializePhoneList();

        // Arrange
        var mockPhoneService = new Mock<IPhoneService>();
        mockPhoneService.Setup(service => service.SearchPhones(It.IsAny<string>())).Returns((List<PhoneModel>)null);

        var controller = new PhoneController(mockPhoneService.Object, _mapper);

        // Act
        var result = controller.SearchPhones("Apple") as NotFoundResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [TearDown]
    public void TearDown()
    {
        _phones = null;
        _mockPhoneService = null;
        _mapper = null;
    }
}