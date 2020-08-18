﻿using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Moq;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class ObjectResultAssertions_Tests
    {
        private const string TestValue = "testValue";
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        [Fact]
        public void Value_GivenObjectResult_ShouldHaveTheSameValue()
        {
            var result = new ObjectResult(TestValue);
            result.Should().BeObjectResult().Value.Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenObjectResult_ShouldHaveTheSameValue()
        {
            var result = new ObjectResult(TestValue);

            result.Should().BeObjectResult().ValueAs<string>().Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new ObjectResult(TestValue);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "ObjectResult.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeObjectResult().ValueAs<int>().Should().Be(2);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new ObjectResult(null);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "ObjectResult.Value", typeof(object));

            Action a = () => result.Should().BeObjectResult().ValueAs<object>();

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsFormatter_GivenExpected_ShouldPass()
        {
            var formatterMock = new Mock<IOutputFormatter>();
            var result = new ObjectResult(TestValue)
            {
                Formatters = { formatterMock.Object }
            };

            result.Should().BeObjectResult().ContainsFormatter(formatter => ReferenceEquals(formatter, formatterMock.Object));
        }

        [Fact]
        public void ContainsFormatter_OnNullFormatters_ShouldFail()
        {
            var result = new ObjectResult(TestValue)
            {
                Formatters = null
            };
            string failureMessage = FailureMessageHelper.ExpectedToContainItemButFoundNull(
                "ObjectResult.Formatters",
                "(formatter == null)");

            Action a = () => result.Should().BeObjectResult().ContainsFormatter(formatter => formatter == null, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsFormatter_GivenUnexpected_ShouldFail()
        {
            var formatterMock = new Mock<IOutputFormatter>();
            var result = new ObjectResult(TestValue)
            {
                Formatters = { formatterMock.Object }
            };
            string failureMessage = FailureMessageHelper.ExpectedToHaveItemMatching(
                "ObjectResult.Formatters",
                result.Formatters, 
                "False");

            Action a = () => result.Should().BeObjectResult().ContainsFormatter(formatter => false, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

    }
}
