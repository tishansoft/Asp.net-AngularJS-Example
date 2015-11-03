using System;
using System.Security.Cryptography;

namespace ChennaiSarees.Infrastructure.Cryptography
{
  public class Password
  {

    // The following constants may be changed without breaking existing hashes.
    private const int SaltByteSize = 24;
    private const int HashByteSize = 24;
    private const int Pbkdf2Iterations = 1000;

    private const int IterationIndex = 0;
    private const int SaltIndex = 1;
    private const int Pbkdf2Index = 2;

    /// <summary>
    /// Creates original salted PBKDF2 hash of the password.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hash of the password.</returns>
    public static string CreateHash(string password)
    {

      // Generate original random salt.
      var csprng = new RNGCryptoServiceProvider();
      var salt = new byte[SaltByteSize];
      csprng.GetBytes(salt);

      // Hash the password and encode the parameters.
      var hash = Pbkdf2(password, salt, Pbkdf2Iterations, HashByteSize);
      return string.Format("{0}:{1}:{2}", Pbkdf2Iterations, Convert.ToBase64String(salt), Convert.ToBase64String(hash));

    }

    /// <summary>
    /// Validates original password given original hash of the correct one.
    /// </summary>
    /// <param name="password">The password to check.</param>
    /// <param name="correctHash">A hash of the correct password.</param>
    /// <returns>True if the password is correct. False otherwise.</returns>
    public static bool ValidatePassword(string password, string correctHash)
    {

      // Extract the parameters from the hash
      char[] delimiter = { ':' };
      var split = correctHash.Split(delimiter);
      var iterations = Int32.Parse(split[IterationIndex]);
      var salt = Convert.FromBase64String(split[SaltIndex]);
      var hash = Convert.FromBase64String(split[Pbkdf2Index]);

      var testHash = Pbkdf2(password, salt, iterations, hash.Length);

      return SlowEquals(hash, testHash);

    }

    /// <summary>
    /// Compares two byte arrays in length-constant time. This comparison
    /// method is used so that password hashes cannot be extracted from
    /// on-line systems using original timing attack and then attacked off-line.
    /// </summary>
    /// <param name="original">The byte array to compared to.</param>
    /// <param name="compare">The byte array to compare.</param>
    /// <returns>True if both byte arrays are equal. False otherwise.</returns>
    private static bool SlowEquals(byte[] original, byte[] compare)
    {
      var diff = (uint)original.Length ^ (uint)compare.Length;
      for (var i = 0; i < original.Length && i < compare.Length; i++)
        diff |= (uint)(original[i] ^ compare[i]);
      return diff == 0;
    }

    /// <summary>
    /// Computes the PBKDF2-SHA1 hash of original password.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <param name="salt">The salt.</param>
    /// <param name="iterations">The PBKDF2 iteration count.</param>
    /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
    /// <returns>A hash of the password.</returns>
    private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
    {
      var pbkdf2 = new Rfc2898DeriveBytes(password, salt)
                        {
                          IterationCount = iterations
                        };
      return pbkdf2.GetBytes(outputBytes);
    }

  }

}
