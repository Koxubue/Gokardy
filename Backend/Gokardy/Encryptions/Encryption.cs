using Gokardy.DTOs.Requests;
using Gokardy.DTOs.Responses;
using Gokardy.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gokardy.Encryptions
{
    public class Encryption : IEncryption
    {
        public string SzyfrujHaslo(string haslo)
        {
            // Create a SHA256   
            using SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(haslo));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public string GenerowanieSoli()
        {
            string salt;            
            salt = LosowanieLiczby().Next(0, 9).ToString();
            salt += LosowanieLiczby().Next(0, 9).ToString();
            salt += LosowanieLiczby().Next(0, 9).ToString();
            salt += LosowanieLiczby().Next(0, 9).ToString();
            return salt;
        }        

        public Random LosowanieLiczby()
        {
            DateTime dataTime = DateTime.Now;
            int parsowanie = dataTime.Second * 1000 + dataTime.Millisecond;
            Random rand = new Random(parsowanie);
            return rand;
        }
    }
}
