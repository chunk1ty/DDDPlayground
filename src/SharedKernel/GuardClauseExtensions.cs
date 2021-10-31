using System;

// Using the same namespace will make sure your code picks up your 
// extensions no matter where they are in your codebase.
namespace Ardalis.GuardClauses
{
    public static class GuardClauseExtensions
    {
        public static string StringLength(this IGuardClause guardClause, string input, string parameterName, int minLength, int maxLength, string message = null)
        {
            if (minLength <= input.Length && input.Length <= maxLength)
            {
                return input;
            }

            throw new ArgumentOutOfRangeException($"[{parameterName}] must have between [{minLength}] and [{maxLength}] symbols.");
        }

        public static string InvalidUrl(this IGuardClause guardClause, string url, string parameterName, string message = null)
        {
            if (url.Length <= 2048 &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return url;
}

            throw new ArgumentOutOfRangeException($"[{url}] must be a valid URL.");
        }
    }
}
