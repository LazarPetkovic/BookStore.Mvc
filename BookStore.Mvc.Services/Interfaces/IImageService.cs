using BookStore.Mvc.DataModel;

namespace BookStore.Mvc.Services.Interfaces
{
    public interface IImageService
    {
        Image GetById(int? id);
    }
}
