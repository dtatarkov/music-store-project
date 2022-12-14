using API.DTO;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators
{
    public interface IAlbumValidator
    {
        void ValidateNew(NewAlbumDTO album);
        void ValidateUpdate(AlbumUpdateDTO album);
    }
}
