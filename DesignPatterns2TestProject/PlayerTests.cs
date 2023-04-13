using DesignPatterns2;
using System.ComponentModel.DataAnnotations;

namespace DesignPatterns2TestProject
{
    public class PlayerTests
    {
        [Fact]
        void TestPlayerCreateInventory()
        {
            var player = new Player();

            Assert.True(player.Inventory != null);
        }
        

        [Fact]
        void TestPlayerValidationNameTooLong()
        {
            var player = new Player()
            {
                Name = "AAAAAAAAAAAAAAAAAAATestNameTooLongAAAAAAAAAAAAAAAAAAAAAAAA",
                UniformColor = new Uniform(),
                GemStone = "opal",
                Inventory = new List<Item>()
                {
                    new Item() { Name = "test", Description = "test" },
                    new Item() { Name = "test", Description = "test" },
                },
                TurnsRemaining = 15,

              
            };

            var context = new ValidationContext(player);
            var errors = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(player, context, errors, true));
        }

        [Fact]
        void TestPlayerValidationInventoryLength()
        {
            var player = new Player()
            {
                Name = "Test",
                UniformColor = new Uniform(),
                GemStone = "opal",
                Inventory = new List<Item>()
                {
                    new Item() { Name = "test", Description = "test" },
                    new Item() { Name = "test", Description = "test" },
                    new Item() { Name = "test", Description = "test" },
                    new Item() { Name = "test", Description = "test" }
                },
                TurnsRemaining = 15,


            };

            var context = new ValidationContext(player);
            var errors = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(player, context, errors, true));
        }

        [Fact]
        void TestPlayerValidationBadName()
        {
            var player = new Player()
            {
                Name = "Test!@",
                UniformColor = new Uniform(),
                GemStone = "opal",
                Inventory = new List<Item>()
                {
                    new Item() { Name = "test", Description = "test" },
                    new Item() { Name = "test", Description = "test" }
                },
                TurnsRemaining = 15,


            };

            var context = new ValidationContext(player);
            var errors = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(player, context, errors, true));
        }

        [Fact]
        void TestPlayerValidationTrue()
        {
            var player = new Player()
            {
                Name = "Test",
                UniformColor = new Uniform(),
                GemStone = "opal",
                Inventory = new List<Item>()
                {
                    new Item() { Name = "test", Description = "test" },
                    new Item() { Name = "test", Description = "test" }
                },
                TurnsRemaining = 15,


            };

            var context = new ValidationContext(player);
            var errors = new List<ValidationResult>();

            Assert.True(Validator.TryValidateObject(player, context, errors, true));

        }
    }
}
