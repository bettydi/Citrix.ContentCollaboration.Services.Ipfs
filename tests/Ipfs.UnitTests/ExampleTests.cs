using Ipfs.Controllers;
using Ipfs.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Ipfs.UnitTests
{
    /// <summary>
    /// Example Controller Unit Tests
    /// Provides unit tests for ExampleController class
    /// </summary>
    public class ExampleControllerTest
    {
        /// <summary>
        /// Unit test for Get method
        /// </summary>
        [Fact]
        public void Get_WhenCalled_ShouldReturnOk()
        {
            // Arrange
            var logger = A.Fake<ILogger<ExampleController>>();
            var exampleController = new ExampleController(logger);

            // Act
            var actionResult = exampleController.Get();

            // Assert
            var result = actionResult as OkObjectResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        /// <summary>
        /// Unit test for Get method when passed an id
        /// </summary>
        [Fact]
        public void GetWithId_WhenCalled_ShouldReturnOk()
        {
            // Arrange
            var logger = A.Fake<ILogger<ExampleController>>();
            var exampleController = new ExampleController(logger);

            // Act
            var actionResult = exampleController.Get(1);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        /// <summary>
        /// Unit test for Post method
        /// </summary>
        [Fact]
        public void Post_WhenCalled_ShouldReturnCreated()
        {
            // Arrange
            var urlHelper = A.Fake<IUrlHelper>();
            A.CallTo(() => urlHelper.RouteUrl(A<UrlRouteContext>.Ignored)).Returns("http://location/");
            var logger = A.Fake<ILogger<ExampleController>>();
            var exampleController = new ExampleController(logger);
            exampleController.Url = urlHelper;
            var model = new TestModel { Name = "Test " };

            // Act
            var actionResult = exampleController.Post(model);

            // Assert
            var result = actionResult as CreatedResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Unit test for Delete method
        /// </summary>
        [Fact]
        public void Delete_WhenCalled_ShouldReturnNoContent()
        {
            // Arrange
            var logger = A.Fake<ILogger<ExampleController>>();
            var exampleController = new ExampleController(logger);

            // Act
            var actionResult = exampleController.Delete(1);

            // Assert
            var result = actionResult as StatusCodeResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }
    }
}