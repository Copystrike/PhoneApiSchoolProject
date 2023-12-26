using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneApiSchoolProject.Controllers;
using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.Services;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Tests.controllers;

[TestFixture]
public class AppsControllerTests
{
    private List<AppsModel> _appsModels;
    private AppsModel _appModel;

    private Mock<IAppsService> _mockService;
    private AppsController _controller;

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<IAppsService>();

        _appsModels =
        [
            new(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"), "Slack", "v1.0", "Slack Technologies", "Business",
                0, new DateTime(2009, 8, 1), Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            new(Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e"), "Zoom", "v1.0", "Zoom Video Communications",
                "Business", 0, new DateTime(2011, 4, 21), Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            new(Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca"), "Google Meet", "v1.0", "Google", "Business", 0,
                new DateTime(2017, 3, 1), Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca")),
            new(Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646"), "Microsoft Teams", "v1.0", "Microsoft", "Business",
                0, new DateTime(2016, 11, 2), Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646")),
            new(Guid.Parse("e0f676f2-5a6a-4ea3-9d0e-d0b2f226029a"), "Trello", "v1.0", "Atlassian", "Business", 0,
                new DateTime(2011, 9, 13), Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            new(Guid.Parse("2ef34f95-b344-4ca4-97e3-3438b5fbe3db"), "ChatGPT", "v1.0", "OpenAI", "Social Media", 0,
                new DateTime(2015, 12, 11), Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            new(Guid.Parse("6651115a-d51b-443e-b0db-fe385216a669"), "Signal", "v1.0", "Signal Foundation",
                "Social Media", 0, new DateTime(2014, 7, 29), Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca")),
            new(Guid.Parse("6cb78e8f-c0c2-45c1-aa07-257a589a8b7e"), "Telegram", "v1.0", "Telegram FZ-LLC",
                "Social Media", 0, new DateTime(2013, 8, 14), Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646")),
            new(Guid.Parse("0eae0368-af5f-4f62-86da-bf2fa1657981"), "Discord", "v1.0", "Discord Inc.", "Social Media",
                0, new DateTime(2015, 5, 13), Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            new(Guid.Parse("596e0c09-4567-46fe-9f97-fb919197f2dc"), "Minecraft", "v1.0", "Mojang Studios", "Games", 10,
                new DateTime(2009, 5, 17), Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            new(Guid.Parse("0ab48281-ece6-4be7-91dc-f74eee15150b"), "Among Us", "v1.0", "InnerSloth", "Games", 5,
                new DateTime(2018, 6, 15), Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca")),
            new(Guid.Parse("e268ef12-24cd-4a42-812e-6f315825f5c1"), "GTA V", "v1.0", "Rockstar Games", "Games", 20,
                new DateTime(2013, 9, 17), Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646")),
            new(Guid.Parse("86009346-bdb9-4ee8-a166-9a6b3a399ac4"), "Cyberpunk 2077", "v1.0", "CD Projekt", "Games", 60,
                new DateTime(2020, 12, 10), Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"))
        ];

        _appModel = _appsModels[0];

        _mockService.Setup(service => service.GetAllApps()).Returns(_appsModels);

        _controller = new AppsController(_mockService.Object);
    }

    [Test]
    public void AppsController_GetApps_ReturnsListOfApps()
    {
        var result = _controller.GetAllApps();

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AppsController_GetAppById_ReturnsApp()
    {
        _mockService.Setup(service => service.GetAppById(_appModel.Id)).Returns(_appModel);

        var result = _controller.GetAppById(_appModel.Id);

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AppsController_GetAppsByIsPaid_ReturnsListOfApps()
    {
        _mockService.Setup(service => service.GetAppsByIsPaid(true)).Returns(It.IsAny<List<AppsModel>>());

        var result = _controller.GetAppsByIsPaid(true);

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AppsController_CreateApp_ReturnsApp()
    {
        _mockService.Setup(service => service.CreateApp(It.IsAny<CreateAppView>())).Returns(It.IsAny<AppsModel>());

        var result = _controller.CreateApp(new CreateAppView()
        {
            Name = "X (Formerly Twitter)",
            Developer = "Twitter Inc.",
            Description = "Social Media",
            Price = 0,
            ReleaseDate = new DateTime(2006, 3, 21),
            CompatibleOsId = Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"),
            Version = "v1.0",
        });

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AppsController_UpdateApp_ReturnsApp()
    {
        _mockService.Setup(service => service.UpdateApp(It.IsAny<UpdateAppView>())).Returns(_appModel);
        _mockService.Setup(service => service.GetAppById(It.IsAny<Guid>())).Returns(_appModel);

        var result = _controller.UpdateApp(new UpdateAppView()
        {
            Id = _appModel.Id,
            Name = "Slack",
            Developer = "Slack Technologies",
            Description = "Business",
            Price = 0,
            ReleaseDate = new DateTime(2009, 8, 1),
            Version = "v1.0",
            CompatibleOsId = Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")
        });

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AppsController_DeleteApp_ReturnsOk()
    {
        _mockService.Setup(service => service.DeleteApp(_appModel.Id));

        var result = _controller.DeleteApp(_appModel.Id);

        Assert.That(result, Is.TypeOf<OkResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AppsController_SearchApps_ReturnsListOfApps()
    {
        _mockService.Setup(service => service.SearchApps(It.IsAny<string>())).Returns(_appsModels);

        var result = _controller.SearchApps(_appModel.Name);

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AppsController_GetAppsByOsId_ReturnsListOfApps()
    {
        _mockService.Setup(service => service.GetAppsByOsId(It.IsAny<Guid>())).Returns(_appsModels);

        var result = _controller.GetAppsByOsId(_appModel.CompatibleOsId);

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.Not.Null);
    }

    [TearDown]
    public void TearDown()
    {
        _appsModels = null;
        _appModel = null;
        _mockService = null;
        _controller = null;
    }
}