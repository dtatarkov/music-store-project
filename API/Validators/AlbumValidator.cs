using API.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Validators
{
    public class AlbumValidator : IAlbumValidator
    {
        public void ValidateNew(Album album)
        {
            if (album.AlbumId != default)
                throw new ValidationException("AlbumId should be empty");

            if (album.Title.Trim().Length == 0)
                throw new ValidationException("Title can't be empty");
        }
    }
}
