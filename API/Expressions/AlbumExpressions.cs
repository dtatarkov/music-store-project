using API.DTO;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.Expressions
{
    public static class AlbumExpressions
    {
        public static readonly Expression<Func<Album, AlbumDTO>> ToDTO = album => new AlbumDTO
        {
            AlbumId = album.AlbumId,
            Title = album.Title,
            Description = album.Description,
            CreatedDate = album.CreatedDate,    
            UpdatedDate = album.UpdatedDate
        };
    }
}
