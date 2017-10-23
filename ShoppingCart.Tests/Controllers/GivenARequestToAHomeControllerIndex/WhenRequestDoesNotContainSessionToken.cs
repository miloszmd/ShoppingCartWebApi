﻿using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using ShoppingCart.HomePage;
using ShoppingCart.PizzaPrice;
using ShoppingCart.Size;
using ShoppingCart.Topping;
using ShoppingCart.UserSession;

namespace ShoppingCart.Tests.Controllers.GivenARequestToAHomeControllerIndex
{
    [TestFixture]
    public class WhenRequestDoesNotContainSessionToken
    {
        private Mock<IPizzaSizeService> _pizzaService;
        private Mock<IUserSessionService> _userSessionService;
        private Mock<IToppingService> _toppingService;
        private Mock<ISizeService> _sizeService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _pizzaService = new Mock<IPizzaSizeService>();
            _pizzaService.Setup(x => x.GetAll()).Returns(new GetAllPizzaSizesResponse());

            _userSessionService = new Mock<IUserSessionService>();
            _userSessionService.Setup(x => x.NewUser()).Returns("SomeUserIdentifier");
            _userSessionService.Setup(x => x.GetBasketForUser(It.IsAny<string>())).Returns(new List<BasketItem>());

            _toppingService = new Mock<IToppingService>();
            _toppingService.Setup(x => x.GetAll()).Returns(new GetAllToppingsResponse());

            _sizeService = new Mock<ISizeService>();
            _sizeService.Setup(x => x.GetAll()).Returns(() => new GetAllSizesResponse());

            var subject = new HomeController(_pizzaService.Object, _toppingService.Object, _sizeService.Object, _userSessionService.Object);
            var context = new Mock<ControllerContext>();
            context.Setup(x => x.HttpContext.Session["UserId"]);
            subject.ControllerContext = context.Object;

            subject.Index();
        }

        [Test]
        public void ThenThePizzaServiceIsCalled()
        {
            _pizzaService.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ThenTheUserSessionServiceIsNeverCalled()
        {
            _userSessionService.Verify(x => x.NewUser(), Times.Once);
        }

        [Test]
        public void ThenTheGetUserPizzaServiceIsCalledWithCorrectUserToken()
        {
            _userSessionService.Verify(x => x.GetBasketForUser(It.IsAny<string>()), Times.Never);
        }
    }
}
