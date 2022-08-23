using API.Entities;
using API.Validators;
using System.ComponentModel.DataAnnotations;

namespace API.Tests.Validators
{
    public class AlbumValidatorTests
    {
        private readonly AlbumValidator validator = new AlbumValidator();

        [Fact]
        public void ValidateNew_IdShouldBeDefault()
        {
            var album = new Album
            {
                AlbumId = 1
            };

            Assert.Throws<ValidationException>(() => validator.ValidateNew(album));
        }

        [Fact]
        public void ValidateNew_IdShouldNotBeEmpty()
        {
            var album = new Album { AlbumId = 0 };

            Assert.Throws<ValidationException>(() => validator.ValidateNew(album));
        }

        [Fact]
        public void ValidateNew_PassesAlbumWithRequiredFieldsOnly()
        {
            var album = new Album { AlbumId = 0, Title = "Test Title" };
            var exception = Record.Exception(() => validator.ValidateNew(album));

            Assert.Null(exception);
        }
    }
}
