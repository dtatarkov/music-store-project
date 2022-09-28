using API.DTO;
using API.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Validators
{
    public class AlbumValidator : IAlbumValidator
    {
        public void ValidateNew(NewAlbumDTO album)
        {
            if (album.Title.Trim().Length == 0)
                throw new ValidationException("Title can't be empty");
        }

        public void ValidateUpdate(UpdatedAlbumDTO album)
        {
            if (album.AlbumId <= 0)
                throw new ValidationException("Invalid ID");

            if (album.Title.Trim().Length == 0)
                throw new ValidationException("Title can't be empty");
        }
    }
}
