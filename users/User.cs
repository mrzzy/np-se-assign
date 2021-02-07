using System.Text;
using System.Security.Cryptography;

namespace NP.SE.Assignment
{
    /*
     * Represents an abstract User in the Parking System.
    */
    public abstract class User
    {
        public string UserId { get; protected set; }
        public string Name { get; protected set; }
        public string PasswordHash { get; protected set; }
        public string MobileNumber { get; protected set; }

        // hash the given input using SHA512 and return the hash
        protected static string Hash(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            SHA512 sha512 = new SHA512Managed();
            byte[] hashedBytes =  sha512.ComputeHash(inputBytes);
            string generatedHash = Encoding.UTF8.GetString(hashedBytes);

            return generatedHash;
        }

        // Login as this User using the given password.
        public bool Login(string password)
        {
            // convert password to hash string using SHA512 hash
            string givenHash = Hash(password);
            // login if the hash matches User's recorded password hash
            return givenHash.Equals(this.PasswordHash);
        }
    }
}
