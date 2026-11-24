using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebDogApp.Infrastructure.Data.Domain;

namespace WebDogApp.Core.Contacts
{
    public interface IBreedService
    {
        bool Create(string name);

        bool UpdateBreed(int breedId, string name);

        bool RemoveById(int breedId);

        List<Breed> GetBreeds();

        Breed GetBreedById(int breedId);

        List<Dog> GetDogsByBreed(int breedId);
    }
}
