﻿using System;
using NUnit.Framework;
using ShoppingCart.Services.UserSession;

namespace ShoppingCart.Tests.UserSession.GivenARequestToCreateANewUser
{
    [TestFixture]
    public class WhenTheNewUserMethodIsCalled
    {
        private string _result;
        private UserSessionService _subject;

        [OneTimeSetUp]
        public void SetUp()
        {
            _subject = new UserSessionService(null, null);
            _result = _subject.NewUser();
        }

        [Test]
        public void ThenTheNewUserIdentifierIsAValidGuid()
        {
            Assert.That(Guid.TryParse(_result, out _));
        }
    }
}