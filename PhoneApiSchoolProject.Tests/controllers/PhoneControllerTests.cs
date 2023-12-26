using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    private PhoneModel _phoneModel;

    private Mock<IPhoneService> _mock;
    private PhoneController _controller;

    [SetUp]
    public void Setup()
    {
        _mock = new Mock<IPhoneService>();

        _phones =
        [
            new(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"), "Apple", "GOLD", 8, 256,
                Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),


            new(Guid.Parse("6a742018-c647-4a82-b216-3a3465788823"), "Apple", "BLACK", 16, 512,
                Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),


            new(Guid.Parse("69c1f411-c766-4911-aae7-a434acbef698"), "OnePlus", "AQUA", 16, 256,
                Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),


            new(Guid.Parse("7c307e4e-5271-4ffb-bf04-10422e6ef539"), "Nothing", "BLACK", 16, 512,
                Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),


            new(Guid.Parse("1a0cf907-3880-4d6f-9219-7f7318a2cc3b"), "Windows", "BLACK", 16, 512,
                Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca")),


            new(Guid.Parse("d6478374-c67e-42a4-a319-c46eca5146f7"), "Linux", "BLACK", 16, 512,
                Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646"))
        ];

        _phoneModel = _phones[0];

        _mock.Setup(service => service.GetAllPhones()).Returns(_phones);
        
        _controller = new PhoneController(_mock.Object);
    }

    [Test]
    public void PhoneController_GetPhones_ReturnsListOfPhones()
    {
        var result = _controller.GetAllPhones();

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void PhoneController_GetPhoneById_ReturnsPhone()
    {
        _mock.Setup(service => service.GetPhoneById(It.IsAny<Guid>())).Returns(_phoneModel);

        var result = _controller.GetPhoneById(_phoneModel.Id);

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void PhoneController_GetPhoneById_ReturnsNotFound()
    {
        _mock.Setup(service => service.GetPhoneById(It.IsAny<Guid>())).Returns((PhoneModel)null);

        var result = _controller.GetPhoneById(Guid.NewGuid());

        Assert.That(result, Is.TypeOf<NotFoundResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void PhoneController_GetPhonesByBrand_ReturnsListOfPhones()
    {
        _mock.Setup(service => service.GetPhonesByBrand(It.IsAny<string>())).Returns(_phones);

        var result = _controller.GetPhonesByBrand("Apple");

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void PhoneController_CreatePhone_ReturnsPhone()
    {
        _mock.Setup(service => service.CreatePhone(It.IsAny<CreatePhoneView>())).Returns(_phoneModel);

        var result = _controller.CreatePhone(new CreatePhoneView()
        {
            Brand = "Apple",
            Color = "GOLD",
            Memory = 8,
            Storage = 256,
            OsId = Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")
        });

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void PhoneController_UpdatePhone_ReturnsPhone()
    {
        _mock.Setup(service => service.UpdatePhone(It.IsAny<UpdatePhoneView>())).Returns(_phoneModel);
        _mock.Setup(service => service.GetPhoneById(It.IsAny<Guid>())).Returns(_phoneModel);

        var result = _controller.UpdatePhone(new UpdatePhoneView()
        {
            Id = Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"),
            Brand = "Apple",
            Color = "GOLD",
            Memory = 8,
            Storage = 256,
            OsId = Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")
        });

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void PhoneController_DeletePhone_ReturnsOk()
    {
        _mock.Setup(service => service.DeletePhone(It.IsAny<Guid>()));

        var result = _controller.DeletePhone(Guid.NewGuid());

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OkResult>());
    }

    [Test]
    public void PhoneController_SearchPhones_ReturnsListOfPhones()
    {
        _mock.Setup(service => service.SearchPhones(It.IsAny<string>())).Returns(_phones);

        var result = _controller.SearchPhones("Apple");

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [TearDown]
    public void TearDown()
    {
        _phones = null;
        _mock = null;
        _controller = null;
        _phoneModel = null;
    }
}