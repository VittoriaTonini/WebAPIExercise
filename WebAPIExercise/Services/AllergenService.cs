using WebAPIExercise.Models;

namespace WebAPIExercise.Services
{
    public class AllergenService
    {
        private List<Allergen> _allergenList; //dichiarazione della lista
        public AllergenService() //istanziamo la lista nel costruttore
        {
            _allergenList = new List<Allergen>()
            {
                new Allergen { Id = 1, Name = "Milk"},
                new Allergen { Id = 2, Name = "Eggs"},
                new Allergen { Id = 3, Name = "Gluten"}
            };
        }

        public IEnumerable<Allergen> GetAll()
        {
            return _allergenList;
        }

        public Allergen? GetByName(string name)
        {
            var result = _allergenList.FirstOrDefault(a => a.Name == name);
            
            if (result == null)
                return null;

            return result;
        }

        public IEnumerable<Allergen> Add(Allergen newAllergen)
        {
            _allergenList.Add(newAllergen);
            return _allergenList;
        }

        public IEnumerable<Allergen> DeleteByName(string name)
        {
            var result = _allergenList.FirstOrDefault(a => a.Name == name);

            if (result != null)
                _allergenList.Remove(result);
            return _allergenList;
        }
    }
}
