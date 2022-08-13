using System;

namespace PetStoreApiFramework.Dto.User
{
    public class UserDto
    {
        // Id of user
        public Int64? Id { get; set; }
        // Username
        public string Username { get; set; }
        // First name of user
        public string FirstName { get; set; }
        // Last name of user
        public string LastName { get; set; }
        // Email of user
        public string Email { get; set; }
        // User password
        public string Password { get; set; }
        // User phone number
        public string Phone { get; set; }
        // User status
        public int? UserStatus { get; set; }
    }
}
