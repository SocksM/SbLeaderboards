using SbLeaderboards.Api.BLL.Services;
using SbLeaderboards.Resources.Exceptions;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;
using Moq;
using SbLeaderboards.Api.BLL.Services.DbServices;
using System.Diagnostics;

namespace BandManager.Tests.Services;

[TestFixture]
public class DirectDbServiceTests
{
	private Mock<IDirectDbRepository<Entity>> _mockDirectDbRepository;
	private DirectDbService<Entity> _directDbService;

	[SetUp]
	public void Setup()
	{
		_mockDirectDbRepository = new Mock<IDirectDbRepository<Entity>>();
		_directDbService = new DirectDbService<Entity>(_mockDirectDbRepository.Object);
	}

	[Test]
	public void Create_CallsRepositoryCreate()
	{
		//Arrange
		Entity entity = new Entity();

		//Act
		_directDbService.Create(entity);

		//Assert
		_mockDirectDbRepository.Verify(repo => repo.Create(entity), Times.Once);
	}

	[Test]
	public void Delete_CallsRepositoryDelete()
	{
		//Arrange
		Entity entity = new Entity();

		//Act
		_directDbService.Delete(entity);

		//Assert
		_mockDirectDbRepository.Verify(repo => repo.Delete(entity), Times.Once);
	}

	[Test]
	public void GetAll_ThrowsNoEntitiesFoundException()
	{
		//Arrange
		_mockDirectDbRepository.Setup(repo => repo.GetAll(false)).Returns([]);

		//Act & Assert
		Assert.Throws<KeyNotFoundException>(() => _directDbService.GetAll());
	}

	[Test]
	public void GetAll_ReturnsArrayOf100Entities()
	{
		//Arrange
		List<Entity> expectedEntities = new List<Entity>();
		for (var i = 0; i < 100; i++)
		{
			expectedEntities.Add(new Entity { Id = i });
		}

		_mockDirectDbRepository.Setup(repo => repo.GetAll(false)).Returns(expectedEntities);

		//Act
		List<Entity> entitiesResult = _directDbService.GetAll(false);

		//Assert
		Assert.That(entitiesResult, Is.EqualTo(expectedEntities));
	}

	[Test]
	public void GetById_ReturnsEntityWithId28()
	{
		//Arrange
		int expectedId = 28;
		Entity expectedEntity = new Entity { Id = expectedId };

		_mockDirectDbRepository.Setup(repo => repo.GetById(expectedId, false))
			.Returns(expectedEntity);

		//Act
		Entity entityResult = _directDbService.GetById(expectedId, false);

		//Assert
		Assert.That(entityResult, Is.EqualTo(expectedEntity));
	}

	[Test]
	public void GetById_ThrowsKeyNotFoundException()
	{
		//Arrange
		int expectedId = 28;
		Entity? expectedEntity = null;

		_mockDirectDbRepository.Setup(repo => repo.GetById(expectedId, false)).Returns(expectedEntity);

		//Act & Assert
		Assert.Throws<KeyNotFoundException>(() => _directDbService.GetById(expectedId));
	}

	[Test]
	public void GetWhere_ReturnsEntitiesWithIdGreaterThan50()
	{
		//Arrange
		List<Entity> expectedEntities = new List<Entity>();
		for (var i = 0; i < 100; i++)
		{
			expectedEntities.Add(new Entity { Id = i });
		}

		_mockDirectDbRepository.Setup(repo => repo.GetWhere(It.IsAny<Func<Entity, bool>>(), false))
			.Returns(expectedEntities.Where(e => e.Id > 50).ToList());

		//Act
		List<Entity> entitiesResult = _directDbService.GetWhere(e => e.Id > 50, false);

		//Assert
		Assert.That(entitiesResult, Is.EqualTo(expectedEntities.Where(e => e.Id > 50).ToList()));
	}

	[Test]
	public void GetWhere_ThrowsNoEntitiesFoundException()
	{
		//Arrange
		_mockDirectDbRepository.Setup(repo => repo.GetWhere(It.IsAny<Func<Entity, bool>>(), false)).Returns([]);

		//Act & Assert
		Assert.Throws<NoEntitiesFoundException>(() => _directDbService.GetWhere(e => e.Id > 50));
	}

	[Test]
	public void Update_CallsRepositoryUpdate()
	{
		//Arrange
		Entity entity = new Entity();

		//Act
		_directDbService.Update(entity);

		//Assert
		_mockDirectDbRepository.Verify(repo => repo.Update(entity), Times.Once);
	}
}