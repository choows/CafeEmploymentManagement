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
	public class CafeServiceTests
	{
		[TestMethod()]
		public void GetCafeByLocationAsyncTest()
		{
			//Arrange
			var mock_return = getMockData();

			Mock<IMediator> mock = new Mock<IMediator>();
			mock.Setup(i => i.Send(It.IsAny<GetCafeByLocationQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((IEnumerable<Cafe>)mock_return));
			CafeService model = new CafeService(mock.Object);

			//Act
			var result = model.GetCafeByLocationAsync("location", CancellationToken.None).Result;

			//Assert 
			Assert.AreEqual(result.Count(), 1);
			Assert.AreEqual(result.First().Name, "name");
		}

		[TestMethod()]
		public void AddCafeAsyncTest()
		{
			//Arrange
			var mock_return = getMockData();

			Mock<IMediator> mock = new Mock<IMediator>();
			mock.Setup(i => i.Send(It.IsAny<CreateCafeCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(mock_return.First()));
			CafeService model = new CafeService(mock.Object);
			var request = mock_return.Select(x => new AddCafeRequest()
			{
				Description = x.Description,
				Location = x.Location,
				Name = x.Name
			}).First();

			//Act
			var result = model.AddCafeAsync(request, CancellationToken.None).Result;

			//Assert 
			Assert.IsNotNull(result);
			Assert.AreEqual(result.Description, "test");
		}

		[TestMethod()]
		public void UpdateCafeAsyncTest()
		{
			//Arrange
			var mock_return = getMockData();

			Mock<IMediator> mock = new Mock<IMediator>();
			mock.Setup(i => i.Send(It.IsAny<UpdateCafeCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(mock_return.First()));
			CafeService model = new CafeService(mock.Object);
			var request = mock_return.Select(x => new UpdateCafeRequest()
			{
				Description = x.Description,
				Location = x.Location,
				Name = x.Name
			}).First();

			//Act
			var result = model.UpdateCafeAsync(Guid.NewGuid(), request, CancellationToken.None).Result;

			//Assert 
			Assert.IsNotNull(result);
			Assert.AreEqual(result.Description, "test");
		}

		[TestMethod()]
		public void DeleteCafeAsyncTest()
		{
			//Arrange
			var mock_return = getMockData();

			Mock<IMediator> mock = new Mock<IMediator>();
			mock.Setup(i => i.Send(It.IsAny<RemoveCafeCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(mock_return.First()));
			CafeService model = new CafeService(mock.Object);

			//Act
			var result = model.RemoveCafeAsync(Guid.NewGuid(), CancellationToken.None).Result;

			//Assert 
			Assert.IsNotNull(result);
			Assert.AreEqual(result.Description, "test");
		}

		private List<Cafe> getMockData()
		{
			return new List<Cafe>()
			{
				new Cafe()
				{
					CreatedDateTime = DateTime.Now,
					Description = "test",
					Employees = new List<Employee>(),
					Id = Guid.NewGuid(),
					Location = "location",
					Name = "name",
					UpdatedDateTime = DateTime.Now
				}
			};
		}
	}
}