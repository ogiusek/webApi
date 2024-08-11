
// using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using WebApi.Core.Attributes;

namespace WebApi.Core.Services.Hasher;

[Service<IHasher>]
public class Hasher : IHasher
{
    private string _salt = Environment.GetEnvironmentVariable("HASH_SALT") ?? "My*5a7T";
    private int _depth = int.Parse(Environment.GetEnvironmentVariable("HASH_DEPTH") ?? "10");
    private int _stringLength = int.Parse(Environment.GetEnvironmentVariable("HASH_LENGTH") ?? "256");
    private int _numBytesRequested => _stringLength / 4 * 3; // 3 bytes per 4 characters

    public string Hash(string password)
    {
        Console.WriteLine(_salt + " " + _depth + " " + _stringLength);
        byte[] hash = KeyDerivation.Pbkdf2(
            password: password,
            salt: Encoding.ASCII.GetBytes(_salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: _depth,
            numBytesRequested: _numBytesRequested
        );
        return Convert.ToBase64String(hash);
    }
}