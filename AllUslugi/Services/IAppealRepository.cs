using AllUslugi.Models;

namespace AllUslugi.Services
{
    public interface IAppealRepository
    {
        List<Apeal> GetAll();
        Apeal? GetById(int id);
        void Add(Apeal appeal);
        void Update(Apeal appeal);
        void ChangeRating(int id); 
        void Delete(int id);
    }
}
