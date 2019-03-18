using BookStore.Mvc.Data.Repositories;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;

namespace BookStore.Mvc.Services
{
    public class ImageService : IImageService
    {
        IRepository<Image> images;

        public ImageService(IRepository<Image> images)
        {
            this.images = images;
        }

        public Image GetById(int? id)
        {
            return this.images
                .GetById(id);
        }

      
    }
}
