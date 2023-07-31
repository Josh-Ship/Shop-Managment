using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_Manager.Tests.Models.Records;

[TestFixture]
public class ShopModelRecordsTests
{
    private Shop_Manager.Models.Records _record;
    private Shop_Manager.Models.Records _recordWrongDate;
    private Shop_Manager.Models.Records _recordWrongDollar;
    private Shop_Manager.Models.Records _recordWrongCents;


    [SetUp]
    public void SetUp()
    {
        _record = new Shop_Manager.Models.Records(){
                record_id = 0,
                date = "01/01/1990",
                name = "Delivery",
                dollars = 50,
                cents = 90,
            };

        _recordWrongDate = new Shop_Manager.Models.Records(){
                record_id = 0,
                date = "gshgoisrgh",
                name = "Delivery",
                dollars = 50,
                cents = 90,
            };

        _recordWrongDollar = new Shop_Manager.Models.Records(){
                record_id = 0,
                date = "01/01/1990",
                name = "Delivery",
                dollars = -50,
                cents = 90,
            };

        _recordWrongCents = new Shop_Manager.Models.Records(){
                record_id = 0,
                date = "gshgoisrgh",
                name = "Delivery",
                dollars = 50,
                cents = 900,
            };
        
    }

    [Test]
    public void RecordsModelDate()
    {
        var validationContext = new ValidationContext(_recordWrongDate, null, null);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(_recordWrongDate, validationContext, validationResults, true);
        Assert.IsFalse(isValid, "The date should be in the format dd/mm/yyyy");

        validationContext = new ValidationContext(_record, null, null);
        validationResults = new List<ValidationResult>();

        isValid = Validator.TryValidateObject(_record, validationContext, validationResults, true);
        Assert.IsTrue(isValid);
    }

    [Test]
    public void RecordsModelDollar()
    {
        var validationContext = new ValidationContext(_recordWrongDollar, null, null);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(_recordWrongDollar, validationContext, validationResults, true);
        Assert.IsFalse(isValid, "The dollar should not be negative and should not have decimals.");

        validationContext = new ValidationContext(_record, null, null);
        validationResults = new List<ValidationResult>();

        isValid = Validator.TryValidateObject(_record, validationContext, validationResults, true);
        Assert.IsTrue(isValid);
    }

    [Test]
    public void RecordsModelCents()
    {
        var validationContext = new ValidationContext(_recordWrongCents, null, null);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(_recordWrongCents, validationContext, validationResults, true);
        Assert.IsFalse(isValid, "The cents should not be negative and range is from 0 to 99");

        validationContext = new ValidationContext(_record, null, null);
        validationResults = new List<ValidationResult>();

        isValid = Validator.TryValidateObject(_record, validationContext, validationResults, true);
        Assert.IsTrue(isValid);
    }
}