using Scrypt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res2019.UserManager
{
    public class SCryptHashing : ISCryptHashing
    {
        private string Hash;

        public string Encode(string plainText)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            return Hash = encoder.Encode(plainText);
        }
        public bool Verify(string plainText, string hashText)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            if (encoder.Compare(plainText, hashText))
                return true;
            else
                return false;
        }


    }
}
