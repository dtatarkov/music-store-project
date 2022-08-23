using API.Context;
using API.DTO;
using API.Entities;
using API.Extensions;
using API.Validators;

namespace API.Services
{
    public class AlbumsService: IAlbumsService
    {
        private readonly IApplicationContext dbContext;
        private readonly IAlbumValidator albumValidator;

        public AlbumsService(IApplicationContext dbContext, IAlbumValidator albumValidator)
        {
            this.dbContext = dbContext;
            this.albumValidator = albumValidator;
        }

        public IQueryable<Album> GetAlbums()
        {
            return dbContext.Albums.AsQueryable();
        }

        public Album? GetAlbumById(int albumId)
        {
            return dbContext.Albums.FirstOrDefault(album => album.AlbumId == albumId);
        }

        public Album AddAlbum(NewAlbumDTO data)
        {
            var album = data.ToAlbum();
            albumValidator.ValidateNew(album);

            dbContext.Add(album);

            return album;
        }
    }
}
