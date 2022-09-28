using API.DTO;
using API.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Validators
{
    public class AlbumValidator : IAlbumValidator
    {
        public void ValidateNew(AlbumUpdateDTO album)
        {
            if (album.Title.Trim().Length == 0)
                throw new ValidationException("Title can't be empty");
        }

        public void ValidateUpdate(UpdatedAlbumDTO album)
        {
            if (album.Title.Trim().Length == 0)
                throw new ValidationException("Title can't be empty");
        }
    }
}
