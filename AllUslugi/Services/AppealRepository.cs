using AllUslugi.Models;
namespace AllUslugi.Services

{
    public class AppealRepository:IAppealRepository
    {
        private static List<Apeal> appeals = new();
        private static int nextId = 1;

        private static readonly string[] RatingCycle = { "OK", "еле-еле", "позор" };

        public List<Apeal> GetAll()
        {
        return appeals;
        }

       public Apeal? GetById(int id){
         
       return   appeals.FirstOrDefault(a => a.Id == id);
       }
        public void Add(Apeal appeal)
        {
            appeal.Id = nextId++;
            if (string.IsNullOrEmpty(appeal.Rating))
                appeal.Rating = "OK";
            appeals.Add(appeal);
        }

        public void Update(Apeal appeal)
        {
            var existing = GetById(appeal.Id);
            if (existing != null)
            {
                existing.Title = appeal.Title;
                existing.Text = appeal.Text;
                existing.Date = appeal.Date;
                existing.Status = appeal.Status; 
            }
        }

        public void ChangeRating(int id)
        {
            var appeal = GetById(id);
            if (appeal != null)
            {
                int currentIndex = Array.IndexOf(RatingCycle, appeal.Rating);//zametka
                int nextIndex = (currentIndex + 1) % RatingCycle.Length;
                appeal.Rating = RatingCycle[nextIndex];
            }
        }

        public void Delete(int id)
        {
            var appeal = GetById(id);
            if (appeal != null)
                appeals.Remove(appeal);
        }
    }
}
