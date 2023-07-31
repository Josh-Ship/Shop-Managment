using Moq;
using NUnit.Framework;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Shop_Manager.Tests.Services.Records;

[TestFixture]
public class ShopServiceRecordsTests
{
        private Mock<Shop_Manager.DbContext.IRecordsDbContext> _mockDbContext;
        private Shop_Manager.Services.RecordsServices _recordsServices;

    [SetUp]
    public void SetUp()
    {
        var data = new List<Shop_Manager.Models.Records>
        {
            new Shop_Manager.Models.Records{record_id = 0, date = "01/01/2001", name = "MenuLog", dollars = 100, cents = 50},
            new Shop_Manager.Models.Records{record_id = 1, date = "01/01/2001", name = "Cash", dollars = 100, cents = 50},
            new Shop_Manager.Models.Records{record_id = 2, date = "01/01/2001", name = "Card", dollars = 100, cents = 50},
            new Shop_Manager.Models.Records{record_id = 3, date = "01/01/2001", name = "Local4U", dollars = 100, cents = 50},
        }.AsQueryable();

        _mockDbContext = new Mock<Shop_Manager.DbContext.IRecordsDbContext>();
        _mockDbContext.Setup(c => c.Records).Returns(MockDbSet(data));
        _mockDbContext.Setup(c => c.SaveChanges()).Returns(1); // Assuming SaveChanges returns 1 for success.
        _recordsServices = new Shop_Manager.Services.RecordsServices(_mockDbContext.Object);
        
    }

    private static DbSet<T> MockDbSet<T>(IQueryable<T> data) where T : class
    {
        var mockDbSet = new Mock<DbSet<T>>();
        mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
        mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        mockDbSet.Setup(d => d.ToList()).Returns(data.ToList());
        return mockDbSet.Object;
    }

    [Test]
    public void add_Should_AddRecordToDbContext()
    {
        var record = new Shop_Manager.Models.Records()
        {
            record_id = 4, 
            date = "01/01/2001", 
            name = "MenuLog",
            dollars = 100,
            cents = 50
        };

        var result = _recordsServices.add(record);

        _mockDbContext.Verify(db => db.Records.Add(record), Times.Once);
        _mockDbContext.Verify(db => db.SaveChanges(), Times.Once);

        Assert.AreSame(record, result);
    }

    [Test]
    public void findById_Should_ReturnRecordFromRecordDbContext()
    {
        int targetId = 5;
        var record = new Shop_Manager.Models.Records()
        {
            record_id = targetId, 
            date = "01/01/2001", 
            name = "MenuLog",
            dollars = 100,
            cents = 50
        };

        _mockDbContext.Setup(db => db.Records.Find(targetId)).Returns(record);

        var result = _recordsServices.find(targetId);
        var expected = JsonSerializer.Serialize(record);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void find_Should_ReturnSerializedRecordList()
    {
        var result = _recordsServices.find();
        var expectedJson = JsonSerializer.Serialize(_mockDbContext.Object.Records.ToList());
        Assert.AreEqual(expectedJson, result);        
    }
}