using Application.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsernameService: IUniqueUsername
    {
        public async Task<string> GenerateUniqueUsername()
        {

            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            int minLength = 4, maxLength = 15;
            // Use a random number generator
            Random random = new Random();

            // Generate a random length for the username within the specified range
            int usernameLength = random.Next(minLength, maxLength + 1);

            // Generate the username by randomly selecting characters from the allowed set
            char[] usernameChars = new char[usernameLength];
            for (int i = 0; i < usernameLength; i++)
            {
                usernameChars[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }

            return new string(usernameChars);

        }

        Task<bool> IUniqueUsername.UsernameIsValid(string username)
        {
            throw new NotImplementedException();
        }
    }
}
