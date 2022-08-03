﻿using FluentAssertions;
using NUnit.Framework;
using PetStoreApiFramework.Dto;
using PetStoreApiFramework.Requests;
using PetStoreApiFramework.Utils;
using PetStoreApiFramework.Utils.Pet;
using System.Net;

namespace PetStoreApiFramework.Tests
{
    
    public class PetCurl : TestBase
    {
        [TestCase]
        public void CrudTest()
        {
            // Create pet object
            var pet = new Pet();

            // Get default pet data
            pet.GetDeafult();

            // Prepare data
            pet.SetPetData("Lucek");
            pet.SetCategory("Dog", 1);
            pet.AddTag("Duchhund", 1).AddTag("Black", 2);
            pet.AddPhotoUrl("www.google.pl");

            // Create pet
            pet.Create(12345);

            // Get pet
            pet.Get();

            // Change data and update pet
            pet.SetPetData("JAckie");
            pet.SetCategory("Labrador");
            pet.Update();

            // Get after update
            pet.Get();

            // Delete Pet
            pet.Delete();

            // Get after delete
            pet.Get(HttpStatusCode.NotFound);


        }
    }
}