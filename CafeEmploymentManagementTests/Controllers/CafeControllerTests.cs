using CafeEmploymentManagement.Models;
using CafeEmploymentManagement.Models.DataContract;
using CafeEmploymentManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CafeEmploymentManagement.Controllers.Tests
{
	[TestClass()]
	public class CafeControllerTests
	{
		[TestMethod()]
		public void TestGetRequestSuccess()
		{
			//Arrange
			Mock<ICafeService> mock = new Mock<ICafeService>();
			List<Cafe> mock_request_response = new List<Cafe>()
			{
				new Cafe()
					{
						CreatedDateTime = DateTime.Now,
						Description = "description",
						Employees = null,
						Id = Guid.NewGuid(),
						Location = "Location",
						Name = "name",
						UpdatedDateTime = DateTime.Now
					}
			};
			mock.Setup(m => m.GetCafeByLocationAsync(It.IsAny<string?>(), CancellationToken.None)).Returns(Task.FromResult((IEnumerable<Cafe>)mock_request_response));
			CafeController model = new CafeController(mock.Object);

			//Act
			var result = model.Get("test", CancellationToken.None).Result as OkObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(200, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestGetRequestEmptySuccess()
		{
			//Arrange
			Mock<ICafeService> mock = new Mock<ICafeService>();
			List<Cafe> mock_request_response = new List<Cafe>()
			{
				new Cafe()
					{
						CreatedDateTime = DateTime.Now,
						Description = "description",
						Employees = null,
						Id = Guid.NewGuid(),
						Location = "Location",
						Name = "name",
						UpdatedDateTime = DateTime.Now
					}
			};
			mock.Setup(m => m.GetCafeByLocationAsync(It.IsAny<string?>(), CancellationToken.None)).Returns(Task.FromResult((IEnumerable<Cafe>)mock_request_response));
			CafeController model = new CafeController(mock.Object);

			//Act
			var result = model.Get(null, CancellationToken.None).Result as OkObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(200, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestGetRequestFail()
		{
			//Arrange
			Mock<ICafeService> mock = new Mock<ICafeService>();
			mock.Setup(m => m.GetCafeByLocationAsync(It.IsAny<string?>(), CancellationToken.None)).Throws(new Exception("Test Exception"));
			CafeController model = new CafeController(mock.Object);

			//Act
			var result = model.Get("test", CancellationToken.None).Result as BadRequestObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(400, result.StatusCode);
		}

		[TestMethod()]
		public void TestPostRequestSuccess()
		{
			//Arrange
			Mock<ICafeService> mock = new Mock<ICafeService>();
			var request = new AddCafeRequest()
			{
				Description = "test",
				Location = "location test",
				Name = "test"
			};
			mock.Setup(m => m.AddCafeAsync(request, CancellationToken.None)).Returns(Task.FromResult(new Cafe()));
			CafeController model = new CafeController(mock.Object);

			//Act
			var result = model.Post(request, CancellationToken.None).Result as OkObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(200, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestPostRequestFail()
		{
			//Arrange
			Mock<ICafeService> mock = new Mock<ICafeService>();
			var request = new AddCafeRequest()
			{
				Description = "test",
				Location = "location test",
				Name = "test"
			};
			mock.Setup(m => m.AddCafeAsync(request, CancellationToken.None)).Throws(new Exception("test"));
			CafeController model = new CafeController(mock.Object);

			//Act
			var result = model.Post(request, CancellationToken.None).Result as BadRequestObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(400, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestPutRequestSuccess()
		{
			//Arrange
			Mock<ICafeService> mock = new Mock<ICafeService>();
			var request = new UpdateCafeRequest()
			{
				Description = "test",
				Location = "location test",
				Name = "test"
			};
			mock.Setup(m => m.UpdateCafeAsync(It.IsAny<Guid>(), request, CancellationToken.None)).Returns(Task.FromResult(new Cafe()));
			CafeController model = new CafeController(mock.Object);

			//Act
			var result = model.Update(Guid.NewGuid(), request, CancellationToken.None).Result as OkObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(200, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestPutRequestFail()
		{
			//Arrange
			Mock<ICafeService> mock = new Mock<ICafeService>();
			var request = new UpdateCafeRequest()
			{
				Description = "test",
				Location = "location test",
				Name = "test"
			};
			mock.Setup(m => m.UpdateCafeAsync(It.IsAny<Guid>(), request, CancellationToken.None)).Throws(new Exception("test exception"));
			CafeController model = new CafeController(mock.Object);

			//Act
			var result = model.Update(Guid.NewGuid(), request, CancellationToken.None).Result as BadRequestObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(400, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestDeleteRequestSuccess()
		{
			//Arrange
			Mock<ICafeService> mock = new Mock<ICafeService>();
			mock.Setup(m => m.RemoveCafeAsync(It.IsAny<Guid>(), CancellationToken.None)).Returns(Task.FromResult(new Cafe()));
			CafeController model = new CafeController(mock.Object);

			//Act
			var result = model.Delete(Guid.NewGuid(), CancellationToken.None).Result as OkObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(200, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestDeleteRequestFail()
		{
			//Arrange
			Mock<ICafeService> mock = new Mock<ICafeService>();
			mock.Setup(m => m.RemoveCafeAsync(It.IsAny<Guid>(), CancellationToken.None)).Throws(new Exception("test exception"));
			CafeController model = new CafeController(mock.Object);

			//Act
			var result = model.Delete(Guid.NewGuid(), CancellationToken.None).Result as BadRequestObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(400, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

	}
}