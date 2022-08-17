using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PetStoreApiFramework.Requests;
using PetStoreApiFramework.Utils;
using PetStoreApiFramework.Utils.Pet;
using System.Net;

namespace PetStoreApiFramework.Tests
{
    [AllureNUnit]
    [AllureSuite("Pet Tests")]
    [Category("Pet Tests")]
    public class PetTests : TestBase
    {
        PetObject pet = new PetObject();

        [TestCase]
        [Order (1)]
        public void CreatePet()
        {
            // Create pet object and get default data
            pet.GetDeafult();

            // Prepare pet data
            pet.SetPetData("Max");
            pet.SetCategory("Labrador", 1);
            pet.AddPhotoUrl("www.lab.com");

            // Create pet and verify that it exists
            pet.Create();
            var createdPet = RequestsPet.GetPetById(pet.Id.GetValueOrDefault()).Deserialize<PetObject>();
            createdPet.Name.Should().Be(pet.Name);
            createdPet.Id.Should().Be(pet.Id.GetValueOrDefault());
        }

        [TestCase]
        [Order(2)]
        public void UpdatePet()
        {
            // Prepare update data
            pet.SetPetData("John", "unactive");
            pet.AddTag("not active pet", 1);

            // Update pet and verify updated data
            pet.Update();
            var updatedPet = RequestsPet.GetPetById(pet.Id.GetValueOrDefault()).Deserialize<PetObject>();
            updatedPet.Name.Should().Be(pet.Name);
            updatedPet.Tags.Should().BeEquivalentTo(pet.Tags);
        }

        [TestCase]
        [Order(3)]
        public void DeletePet()
        {
            // Delete pet and verify that it no longer exists
            pet.Delete();
            pet.Get(HttpStatusCode.NotFound, "Pet not found");
        }

        [TestCase]
        [Order (4)]
        public void GetPetByNotProvidingId()
        {
            // Prepare data
            pet.Id = null;

            // Update pet and verify response
            pet.Get(HttpStatusCode.NotFound, "Pet not found");
        }
    }
}
