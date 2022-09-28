using API.Context;
using API.DTO;
using API.Entities;
using API.Exceptions;
using API.Extensions;
using API.Validators;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AlbumsService: IAlbumsService
    {
        private readonly IApplicationContext dbContext;
        private readonly IAlbumValidator albumValidator;

        public AlbumsService(
            IApplicationContext dbContext, 
            IAlbumValidator albumValidator)
        {
            this.dbContext = dbContext;
            this.albumValidator = albumValidator;            
        }

        public IQueryable<Album> GetAlbums()
        {
            return dbContext.Albums.AsQueryable();
        }

        public async Task<Album?> GetAlbumByIdAsync(long albumId)
        {
            return await dbContext.Albums.FirstOrDefaultAsync(album => album.AlbumId == albumId);
        }

        public Album AddAlbum(AlbumUpdateDTO data)
        {
            albumValidator.ValidateNew(data);

            var album = data.ToAlbum();
            dbContext.Add(album);

            return album;
        }

        public async Task<Album> UpdateAlbumAsync(long albumId, UpdatedAlbumDTO data)
        {
            var album = await GetAlbumByIdAsync(albumId);

            if (album == null)
                throw new EntityNotFoundException("Album not found");

            albumValidator.ValidateUpdate(data);

            album.Title = data.Title;
            album.Description = data.Description;

            return album;
        }

        public async Task<Album> RemoveAlbumAsync(long albumId)
        {
            var album = await GetAlbumByIdAsync(albumId);

            if (album == null)
                throw new EntityNotFoundException("Album not found");

            dbContext.Remove(album);

            return album;
        }
    }
}
