using API.DTO;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.MockData
{
    public static class AlbumsMockData
    {
        public static Album albumWithAllFieldsFilled = new Album { AlbumId = 3, Title = "Test Title", Description = "Test Description" };

        public static IQueryable<Album> albums = new List<Album>()
        {
            new Album { AlbumId = 1, Title = "Test Title" },
            new Album { AlbumId = 2, Description = "Test Description" },
            albumWithAllFieldsFilled
        }.AsQueryable();

        public static NewAlbumDTO newAlbumDTO = new NewAlbumDTO
        {
            Title = "Test Title",
            Description = "Test Description"
        };
    }
}
