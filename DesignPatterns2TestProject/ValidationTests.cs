using DesignPatterns2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2TestProject
{
    public class ValidationTests
    {
        [Fact]
        void TestRequiredAttribute()
        {
            var validator = new CustomRequiredAttribute();
            var toValidate = new Uniform();

            var validationContext = new ValidationContext(toValidate);
            var validationResult = validator.GetValidationResult(toValidate, validationContext);

            Assert.Null(validationResult);
        }

        [Fact]
        void TestNonUniqueListValidation()
        {
            var item = new Item();
            var items = new List<Item>();

            items.Add(item);
            items.Add(item);

            var validator = new UniqueCollectionAttribute();
            var validationContext = new ValidationContext(items);

            var validationResult = validator.GetValidationResult(items, validationContext);

            Assert.NotNull(validationResult);
        }
    }
}
