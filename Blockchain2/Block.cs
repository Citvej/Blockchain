using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Blockchain2
{
    class Block
    {
        public int index { get; set; }
        public string data { get; set; }
        public DateTime timestamp { get; set; }
        public string hash { get; set; }
        public string previousHash { get; set; }
        public int nonce { get; set; } = 0;

        public Block(DateTime now, string prevHash, string podatki)
        {
            index = 0;
            timestamp = now;
            previousHash = previousHash;
            data = podatki;
            hash = CalculateHash();
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.UTF8.GetBytes($"{timestamp}-{previousHash ?? ""}-{data}-{nonce}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        public void Mine(int difficulty)
        {
            var leadingZeros = new string('0', difficulty);
            while (this.hash == null || this.hash.Substring(0, difficulty) != leadingZeros)
            {
                this.nonce++;
                this.hash = this.CalculateHash();
            }
        }
    }
}
