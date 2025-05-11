using CafeEmploymentManagement.Models;
using CafeEmploymentManagement.Models.DataContract;
using CafeEmploymentManagement.Resources.Commands.Create;
using CafeEmploymentManagement.Resources.Commands.Remove;
using CafeEmploymentManagement.Resources.Commands.Update;
using CafeEmploymentManagement.Resources.Queries;
using MediatR;
using Moq;

namespace CafeEmploymentManagement.Services.Tests
{
	[TestClass()]
	public class EmployeeServiceTests
	{
		[TestMethod()]
		public void GetEmployeeAsyncTest()
		{
			//Arrange
			var mock_return = getMockData();
			var mock_cafe_return = getMockCafeData();

			Mock<IMediator> mock = new Mock<IMediator>();
			mock.Setup(i => i.Send(It.IsAny<GetCafeByIdQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Cafe)mock_cafe_return.First()));
			EmployeeService model = new EmployeeService(mock.Object);

			//Act
			var result = model.GetEmployees(Guid.NewGuid(), CancellationToken.None).Result;

			//Assert 
			Assert.AreEqual(result.Count(), 1);
			Assert.AreEqual(result.First().name, "test name");
		}

		[TestMethod()]
		public void GetEmployeeNullIdAsyncTest()
		{
			//Arrange
			var mock_return = getMockData();

			Mock<IMediator> mock = new Mock<IMediator>();
			mock.Setup(i => i.Send(It.IsAny<GetAllEmployeeQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((IEnumerable<Employee>)mock_return));
			EmployeeService model = new EmployeeService(mock.Object);

			//Act
			var result = model.GetEmployees(null, CancellationToken.None).Result;

			//Assert 
			Assert.AreEqual(result.Count(), 1);
			Assert.AreEqual(result.First().name, "test name");
		}

		[TestMethod()]
		public void AddEmployeeAsyncTest()
		{
			//Arrange
			var mock_return = getMockData();

			Mock<IMediator> mock = new Mock<IMediator>();
			mock.Setup(i => i.Send(It.IsAny<CreateEmployeeCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(mock_return.First()));
			EmployeeService model = new EmployeeService(mock.Object);
			var request = mock_return.Select(x => new AddEmployeeRequest()
			{
				email_address = x.email_address,
				cafeId = x.cafe?.Id,
				gender = x.gender,
				name = x.name,
				phone_number = x.phone_number,
				startDate = x.StartDate
			}).First();

			//Act
			var result = model.AddEmployeeAsync(request, CancellationToken.None).Result;

			//Assert 
			Assert.IsNotNull(result);
			Assert.AreEqual(result.name, "test name");
		}

		[TestMethod()]
		public void UpdateEmployeeAsyncTest()
		{
			//Arrange
			var mock_return = getMockData();

			Mock<IMediator> mock = new Mock<IMediator>();
			mock.Setup(i => i.Send(It.IsAny<UpdateEmployeeCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(mock_return.First()));
			EmployeeService model = new EmployeeService(mock.Object);
			var request = mock_return.Select(x => new UpdateEmployeeRequest()
			{
				email_address = x.email_address,
				cafeId = x.cafe?.Id,
				gender = x.gender,
				name = x.name,
				phone_number = x.phone_number,
				startDate = x.StartDate
			}).First();

			//Act
			var result = model.UpdateEmployeeAsync("test", request, CancellationToken.None).Result;

			//Assert 
			Assert.IsNotNull(result);
			Assert.AreEqual(result.name, "test name");
		}

		[TestMethod()]
		public void DeleteCafeAsyncTest()
		{
			//Arrange
			var mock_return = getMockData();

			Mock<IMediator> mock = new Mock<IMediator>();
			mock.Setup(i => i.Send(It.IsAny<RemoveEmployeeCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(mock_return.First()));
			EmployeeService model = new EmployeeService(mock.Object);

			//Act
			var result = model.RemoveEmployee("test", CancellationToken.None).Result;

			//Assert 
			Assert.IsNotNull(result);
			Assert.IsNotNull(result);
			Assert.AreEqual(result.name, "test name");
		}


		private List<Employee> getMockData()
		{
			return new List<Employee>()
			{
				new Employee()
				{
					name = "test name",
					email_address = "asd@gmail.com",
					cafe = null,
					CreatedDateTime = DateTime.Now,
					gender = "Male",
					Id = "Test",
					LastUpdatedDateTime = DateTime.Now,
					phone_number = "1234567890",
					StartDate = DateTime.Now
				}
			};
		}

		private List<Cafe> getMockCafeData()
		{
			return new List<Cafe>()
			{
				new Cafe()
				{
					CreatedDateTime = DateTime.Now,
					Description = "test",
					Employees = getMockData(),
					Id = Guid.NewGuid(),
					Location = "location",
					Name = "name",
					UpdatedDateTime = DateTime.Now
				}
			};
		}
	}
}