using FluentAssertions;
using PetStoreApiFramework.Dto;
using PetStoreApiFramework.Requests;
using System;
using System.Collections.Generic;
using System.Net;

namespace PetStoreApiFramework.Utils.Pet
{
    public class PetObject
    {
        // Id of pet
        public Int64? Id { get; set; }
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

        public PetObject GetDeafult()
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

        public PetObject SetPetData(string name,  string status = "active")
        {
            Name = name;
            Status = status;
            return this;
        }

        public PetObject SetCategory(string name, int? id = null)
        {
            Category.Name = name;
            Category.Id = id;
            return this;
        }

        public PetObject AddTag(string name, int? id = null)
        {
            Tags.Add(new TagDto { 
                Name = name, 
                Id = id 
            });
            return this;
        }

        public PetObject AddPhotoUrl(string url)
        {
            PhotoUrls.Add(url);
            return this;
        }

        public PetObject Create(int? id = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Id = id;
            var response = RequestsPet.CreatePet(this, statusCode).Deserialize<PetDto>();
            Id = response.Id;
            return this;
        }

        public PetObject Get(HttpStatusCode statusCode = HttpStatusCode.OK, string errorMessage = null)
        {
            var response = RequestsPet.GetPetById(Id.GetValueOrDefault(), statusCode).Deserialize<ApiResponseDto>();
            if (statusCode != HttpStatusCode.OK)
            {
                response.Message.Should().Be(errorMessage);
            }
            return this;
        }

        public PetObject Update(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = RequestsPet.UpdatePet(this, statusCode).Deserialize<PetDto>();
            Id = response.Id;
            return this;
        }

        public PetObject Delete(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            RequestsPet.DeletePet(Id.GetValueOrDefault(), statusCode);
            return this;
        }
    }
}
