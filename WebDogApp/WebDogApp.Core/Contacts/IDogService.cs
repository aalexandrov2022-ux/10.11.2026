using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebDogApp.Infrastructure.Data.Domain;

namespace WebDogApp.Core.Contacts
{
    public interface IDogService
    {
        bool Create(string name, int age, int breedId, string picture, string description);

        bool UpdateDog(int dogId, string name, int age, int breedId, string picture, string description);

        List<Dog> GetDogs();
        Dog GetDogById(int dogId);
        bool RemoveById(int dogId);
        List<Dog> GetDogs(string searchStringBreed, string searchStringName, string searchSrtingAge);
    }
}
