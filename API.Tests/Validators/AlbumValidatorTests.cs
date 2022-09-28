using API.DTO;
using API.Validators;

namespace API.Tests.Validators
{
    public class AlbumValidatorTests
    {
        private readonly AlbumValidator validator = new AlbumValidator();

        [Fact]
        public void ValidateNew_FailsWhenTitleIsMissing()
        {
            var album = new NewAlbumDTO { };
            var exception = Record.Exception(() => validator.ValidateNew(album));

            Assert.NotNull(exception);
        }

        [Fact]
        public void ValidateNew_PassesAlbumWithRequiredFieldsOnly()
        {
            var album = new NewAlbumDTO { Title = "Test Title" };
            var exception = Record.Exception(() => validator.ValidateNew(album));

            Assert.Null(exception);
        }

        [Fact]
        public void ValidateNew_PassesAlbumWithAllFields()
        {
            var album = new NewAlbumDTO { Title = "Test Title", Description = "Test Description" };
            var exception = Record.Exception(() => validator.ValidateNew(album));

            Assert.Null(exception);
        }

        [Fact]
        public void ValidateUpdate_FailsWhenDefaultIDIsProvided()
        {
            var album = new UpdatedAlbumDTO { Title = "Test Title" };
            var exception = Record.Exception(() => validator.ValidateUpdate(album));

            Assert.NotNull(exception);
        }

        [Fact]
        public void ValidateUpdate_FailsWhenInvalidIDIsProvided()
        {
            var album = new UpdatedAlbumDTO { AlbumId = -1, Title = "Test Title" };
            var exception = Record.Exception(() => validator.ValidateUpdate(album));

            Assert.NotNull(exception);
        }

        [Fact]
        public void ValidateUpdate_FailsWhenTitleIsMissing()
        {
            var album = new UpdatedAlbumDTO { AlbumId = 1 };
            var exception = Record.Exception(() => validator.ValidateUpdate(album));

            Assert.NotNull(exception);
        }

        [Fact]
        public void ValidateUpdate_PassesAlbumWithRequiredFieldsOnly()
        {
            var album = new UpdatedAlbumDTO { AlbumId = 1, Title = "Test Title" };
            var exception = Record.Exception(() => validator.ValidateUpdate(album));

            Assert.Null(exception);
        }

        [Fact]
        public void ValidateUpdate_PassesAlbumWithAllFields()
        {
            var album = new UpdatedAlbumDTO { AlbumId = 1, Title = "Test Title", Description = "Test Description" };
            var exception = Record.Exception(() => validator.ValidateUpdate(album));

            Assert.Null(exception);
        }
    }
}
