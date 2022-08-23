using API.DTO;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class AlbumExtensions
    {
        public static Album ToAlbum(this NewAlbumDTO data)
        {
            return new Album
            {
                Title = data.Title,
                Description = data.Description
            };
        }
    }
}
