using PetStoreApiFramework.Dto;
using PetStoreApiFramework.Requests;
using System.Collections.Generic;
using System.Net;

namespace PetStoreApiFramework.Utils.Pet
{
    public class Pet
    {
        // Id of pet
        public int? Id { get; set; }
        // Object containing pet category informations
        public PetCategoryDto Category { get; set; }
        // Pet name
        public string Name { get; set; }
        // List of photo urls
        public IList<string> PhotoUrls { get; set; }
        // List of tag objects
        public IList<TagDto> Tags { get; set; }
        // Status of pet
        public string Status { get; set; }

        public Pet GetDeafult()
        {
            var defaultPet = TestData.Read<PetDto>("DefaultPet");
            Id = defaultPet.Id;
            Category = defaultPet.Category;
            Name = defaultPet.Name;
            PhotoUrls = defaultPet.PhotoUrls;
            Tags = defaultPet.Tags;
            Status = defaultPet.Status;
            return this;
        }

        public Pet SetPetData(string name,  string status = "active")
        {
            Name = name;
            Status = status;
            return this;
        }

        public Pet SetCategory(string name, int? id = null)
        {
            Category.Name = name;
            Category.Id = id;
            return this;
        }

        public Pet AddTag(string name, int? id = null)
        {
            Tags.Add(new TagDto { 
                Name = name, 
                Id = id 
            });
            return this;
        }

        public Pet AddPhotoUrl(string url)
        {
            PhotoUrls.Add(url);
            return this;
        }

        public Pet Create(int? id = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Id = id;
            var response = RequestsPet.CreatePet(this, statusCode).Deserialize<PetDto>();
            Id = response.Id;
            return this;
        }

        public Pet Get(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            RequestsPet.GetPetById(Id.GetValueOrDefault(), statusCode);
            return this;
        }

        public Pet Update(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = RequestsPet.UpdatePet(this, statusCode).Deserialize<PetDto>();
            Id = response.Id;
            return this;
        }

        public Pet Delete(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            RequestsPet.DeletePet(Id.GetValueOrDefault(), statusCode);
            return this;
        }
    }
}
