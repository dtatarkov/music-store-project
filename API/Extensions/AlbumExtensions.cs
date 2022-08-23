using API.DTO;
using API.Entities;
using API.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class AlbumExtensions
    {
        private static readonly Func<Album, AlbumDTO> toDTO = AlbumExpressions.ToDTO.Compile();

        public static Album ToAlbum(this NewAlbumDTO data)
        {
            return new Album
            {
                Title = data.Title,
                Description = data.Description
            };
        }

        public static AlbumDTO ToDTO(this Album album) => toDTO(album);
    }
}
