using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PetStoreApiFramework.Requests.Store;
using PetStoreApiFramework.Utils;
using PetStoreApiFramework.Utils.Pet;
using PetStoreApiFramework.Utils.Store;
using System;
using System.Collections.Generic;
using System.Net;

namespace PetStoreApiFramework.Tests
{
    [AllureNUnit]
    [AllureSuite("Pet Tests")]
    [Category ("Store Tests")]
    public class StoreTests : TestBase
    {
        OrderObject order = new OrderObject();
        PetObject pet = new PetObject();

        [TestCase]
        [Order(1)]
        public void CreateOrder()
        {
            // Create pet for further order
            pet.GetDeafult().Create();

            // Get default order and prepare data
            order.GetDefault();
            order.PetId = pet.Id;
            order.Quantity = 1;
            order.ShipDate = DateTime.UtcNow.ToString("o");

            // Create order
            order.Create();

            // Get order and verify data - BUG: 
            var placedOrder = RequestsStore.GetOrderById(order.Id.GetValueOrDefault()).Deserialize<OrderObject>();
            placedOrder.Should().Be(order);
        }

        [TestCase]
        [Order(2)]
        public void CreateOrderWrongDateFormat()
        {
            // Create pet for further order
            pet.GetDeafult().Create();

            // Prepare order
            order.GetDefault();
            order.ShipDate = DateTime.Now.ToString();

            // Create Order and verify response status code
            order.Create(HttpStatusCode.InternalServerError);
        }

        [TestCase]
        [Order(3)]
        public void DeleteOrder()
        {
            // Create pet for further order
            pet.GetDeafult().Create();

            // Prepare order
            order.PetId = pet.Id;
            order.Quantity = 1;
            order.ShipDate = DateTime.UtcNow.ToString("o");

            // Create Order and verify response status code
            order.Create();

            // Delete Order
            order.Delete();

            // Get deleted order and verify it's deletion
            RequestsStore.GetOrderById(order.Id.GetValueOrDefault(), HttpStatusCode.NotFound);
        }

        [TestCase]
        [Order(4)]
        public void GetInventory()
        {
            // Get current inventory
            var inventory = RequestsStore.GetInventory().Deserialize<Dictionary<string, string>>();
            inventory.Should().NotBeNull();

            // Create pets with different statuses
            pet.GetDeafult();
            pet.Status = "available";
            pet.Create();

            pet.Status = "pending";
            pet.Create();

            pet.Status = "sold";
            pet.Create();

            // Verify that inventory have been updated
            Convert.ToInt32(inventory["available"]).Should().Be(Convert.ToInt32(inventory["available"]) + 1);
            Convert.ToInt32(inventory["pending"]).Should().Be(Convert.ToInt32(inventory["pending"]) + 1);
            Convert.ToInt32(inventory["sold"]).Should().Be(Convert.ToInt32(inventory["sold"]) + 1);
        }
    }
}
