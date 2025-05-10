using CafeEmploymentManagement.Models;
using CafeEmploymentManagement.Models.DataContract;
using CafeEmploymentManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CafeEmploymentManagement.Controllers.Tests
{
	[TestClass()]
	public class EmployeeControllerTests
	{
		[TestMethod()]
		public void TestGetRequestSuccess()
		{
			//Arrange
			Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
			List<Employee> mock_request_response = new List<Employee>()
			{
				new Employee()
				{
					email_address = "test@gmail.com",
					cafe = null,
					CreatedDateTime = DateTime.Now,
					gender = "Male",
					LastUpdatedDateTime = DateTime.Now,
					name = "name",
					phone_number = "1234567890",
					StartDate = DateTime.Now,
				}
			};
			mock.Setup(m => m.GetEmployees(It.IsAny<Guid?>(), CancellationToken.None)).Returns(Task.FromResult((IEnumerable<Employee>)mock_request_response));
			EmployeesController model = new EmployeesController(mock.Object);

			//Act
			var result = model.Get(Guid.NewGuid(), CancellationToken.None).Result as OkObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(200, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestGetRequestEmptySuccess()
		{
			//Arrange
			Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
			List<Employee> mock_request_response = new List<Employee>()
			{
				new Employee()
				{
					email_address = "test@gmail.com",
					cafe = null,
					CreatedDateTime = DateTime.Now,
					gender = "Male",
					LastUpdatedDateTime = DateTime.Now,
					name = "name",
					phone_number = "1234567890",
					StartDate = DateTime.Now,
				}
			};
			mock.Setup(m => m.GetEmployees(It.IsAny<Guid?>(), CancellationToken.None)).Returns(Task.FromResult((IEnumerable<Employee>)mock_request_response));
			EmployeesController model = new EmployeesController(mock.Object);

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
			Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
			mock.Setup(m => m.GetEmployees(It.IsAny<Guid?>(), CancellationToken.None)).Throws(new Exception("Test Exception"));
			EmployeesController model = new EmployeesController(mock.Object);

			//Act
			var result = model.Get(Guid.NewGuid(), CancellationToken.None).Result as BadRequestObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(400, result.StatusCode);
		}

		[TestMethod()]
		public void TestPostRequestSuccess()
		{
			//Arrange
			Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
			var request = new AddEmployeeRequest()
			{
				email_address = "test@gmail.com",
				cafeId = Guid.NewGuid(),
				gender = "Male",
				name = "name",
				phone_number = "2123331",
				startDate = DateTime.Now,
			};
			mock.Setup(m => m.AddEmployeeAsync(request, CancellationToken.None)).Returns(Task.FromResult(new Employee()));
			EmployeesController model = new EmployeesController(mock.Object);

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
			Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
			var request = new AddEmployeeRequest()
			{
				email_address = "test@gmail.com",
				cafeId = Guid.NewGuid(),
				gender = "Male",
				name = "name",
				phone_number = "2123331",
				startDate = DateTime.Now,
			};
			mock.Setup(m => m.AddEmployeeAsync(request, CancellationToken.None)).Throws(new Exception("test"));
			EmployeesController model = new EmployeesController(mock.Object);

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
			Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
			var request = new UpdateEmployeeRequest()
			{
				email_address = "test@gmail.com",
				cafeId = Guid.NewGuid(),
				gender = "Male",
				name = "name",
				phone_number = "2123331",
				startDate = DateTime.Now,
			};
			mock.Setup(m => m.UpdateEmployeeAsync(It.IsAny<string>(), request, CancellationToken.None)).Returns(Task.FromResult(new Employee()));
			EmployeesController model = new EmployeesController(mock.Object);

			//Act
			var result = model.Update("test", request, CancellationToken.None).Result as OkObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(200, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestPutRequestFail()
		{
			//Arrange
			Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
			var request = new UpdateEmployeeRequest()
			{
				email_address = "test@gmail.com",
				cafeId = Guid.NewGuid(),
				gender = "Male",
				name = "name",
				phone_number = "2123331",
				startDate = DateTime.Now,
			};
			mock.Setup(m => m.UpdateEmployeeAsync(It.IsAny<string>(), request, CancellationToken.None)).Throws(new Exception("test exception"));
			EmployeesController model = new EmployeesController(mock.Object);

			//Act
			var result = model.Update("test", request, CancellationToken.None).Result as BadRequestObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(400, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestDeleteRequestSuccess()
		{
			//Arrange
			Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
			mock.Setup(m => m.RemoveEmployee(It.IsAny<string>(), CancellationToken.None)).Returns(Task.FromResult(new Employee()));
			EmployeesController model = new EmployeesController(mock.Object);

			//Act
			var result = model.Delete("test", CancellationToken.None).Result as OkObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(200, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

		[TestMethod()]
		public void TestDeleteRequestFail()
		{
			//Arrange
			Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
			mock.Setup(m => m.RemoveEmployee(It.IsAny<string>(), CancellationToken.None)).Throws(new Exception("test exception"));
			EmployeesController model = new EmployeesController(mock.Object);

			//Act
			var result = model.Delete("test", CancellationToken.None).Result as BadRequestObjectResult;

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(400, result.StatusCode);
			Assert.IsNotNull(result.Value);
		}

	}
}