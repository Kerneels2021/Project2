﻿
using ImageGallery.Data;
using ImageGallery.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.Services
{

    public class ImageService : IImage
    {
        private readonly ImageGalleryDbContext _ctx;

        public ImageService(ImageGalleryDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages.Include(img => img.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return GetAll().Where(img => img.Id == id).First();
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }

        IEnumerable<GalleryImage> IImage.GetWithTag(string tag)
        {
            throw new NotImplementedException();
        }

        public CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);
        }

        public async Task SetImage(string title, string geo,string tags, Uri uri)
        {
            var image = new GalleryImage
            {      
                Title = title,  
                Geolocation = geo,
                Tags = ParseTags(tags),
                Url = uri.AbsoluteUri,
                Created = DateTime.Now
                
            };

            _ctx.Add(image);
            await _ctx.SaveChangesAsync();
        }

        public List<ImageTag> ParseTags(string tags)
        {
            try
            {
                return tags.Split(",").Select(tag => new ImageTag
                {
                    Description = tag
                }).ToList();
            }
            catch
            {
                return tags.Split(",").Select(tag => new ImageTag
                {
                    Description = ""
                }).ToList();
            }
        }
    }
}
