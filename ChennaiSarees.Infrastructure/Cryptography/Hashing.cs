using System;
using System.Security.Cryptography;
using System.Text;

namespace ChennaiSarees.Infrastructure.Cryptography
{

  public static class Hashing
  {

    // Crypto modifiers.
    private const string ConfirmCodeModifier = "SlkltCuEtJWyGoCByP3qzlvI5IayqbmxHGxezRVYBupeAm87m49kVzFfF3TpVRBUtpCu0v3CdZkAWTRcbnvRaspcttYYzvLfMMYRlYM0iPAQOhIAhFcgosxPlLiZcsRB";
    private const string UnlockCodeModifier = "WLhITiEkZBB4TsHWdtQqAQAepzqNX0XcAlToDE7LMfzfKIGk1XNHHONsMV6MGwMldwLDOzlnTrOYUykjnUhTrKVudKRDRtltmA2bZvRQX5B5MRBRs9sMkfX7QNYWssWJ";
    private const string HashModifier = "qOYrqPGheRK8dOyqO0lVcciEmirAiGzied7enQNWV7D0bGl929AFBii7AIu8xJzC3zeSIi18E4NZ28JD6b81God6d7rl7ZSsOfNp7tSQejdSKR12H9IhfDAaf9wpQU";


    #region Public Functions

    /// <summary>Hash string</summary>
    /// <param name="value">value to be hashed</param>
    /// <param name="salt">password value to use</param>
    /// <returns>Hashed string</returns>
    public static string HashString(string value, string salt)
    {
      return GetHash(value + salt);
    }

    /// <summary>
    /// Gets the confirmation code hash.
    /// </summary>
    /// <returns>System.String.</returns>
    public static string GetConfirmationCode()
    {
      var hash = GetHash(string.Format("{0}{1}", DateTime.UtcNow.Ticks, ConfirmCodeModifier));
      return hash.Length > 20 ? hash.Substring(0, 20) : hash;
    }

    /// <summary>
    /// Gets a new unlock code.
    /// </summary>
    /// <returns>System.String.</returns>
    public static string GetUnlockCode()
    {
      var hash = GetHash(string.Format("{0}{1}", DateTime.UtcNow.Ticks, UnlockCodeModifier));
      return hash.Length > 20 ? hash.Substring(0, 20) : hash;
    }

    #endregion

    #region Private Functions

    /// <summary>Get hash code</summary>
    /// <param name="value">value to be hashed</param>
    /// <returns>Hashed value</returns>
    private static string GetHash(string value)
    {

      byte[] hash = null;

      try
      {

        using (HashAlgorithm algorithm = new SHA256CryptoServiceProvider())
        {

          if (value.Length > HashModifier.Length)
            value += ReverseString(HashModifier);
          else
            value += ReverseString(HashModifier.Substring(1, value.Length));

          hash = Encoding.Unicode.GetBytes(value);

          for (var i = 0; i < 1000; i++)
          {
            hash = algorithm.ComputeHash(hash);
          }

          algorithm.Clear();

        }

      }
      catch (Exception ex)
      {
        var message = ex.Message;
      }

      var hashed = StripCharacters(Convert.ToBase64String(hash));

      return hashed;

    }

    /// <summary>Reverse string</summary>
    /// <param name="value">string to be reversed</param>
    /// <returns>Reversed string</returns>
    private static string ReverseString(string value)
    {

      // Convert string to char array.
      var arrChar = value.ToCharArray();

      // Reverse array.
      Array.Reverse(arrChar);

      // Set procedure return value.
      return new string(arrChar);

    }

    /// <summary>Strip non alpha-numeric characters from string</summary>
    /// <param name="value">String to be checked</param>
    /// <returns>String stripped of disallowed characters</returns>
    private static string StripCharacters(string value)
    {

      var builder = new StringBuilder(101);

      for (var i = 0; i < value.Length; i++)
      {
        var character = value.Substring(i, 1);
        if (validation.validation.IsAlphaNumeric(character))
          builder.Append(character);
      }

      return builder.ToString();

    }

    #endregion

  }

}
