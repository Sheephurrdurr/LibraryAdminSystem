using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public static class Guard
    {
        public static string ValidateNotEmpty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{propertyName} cannot be empty.");
            }
            return value;
        }

        public static int ValidatePositive(int value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{propertyName} must be a positive integer.");
            }
            return value;
        }

        public static T NotNull<T>(T value, string propertyName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(propertyName, $"{propertyName} cannot be null.");
            }
            return value;
        }

        public static DateTime ValidateInFuture(DateTime value, string propertyName)
        {
            if (value <= DateTime.Now)
            {
                throw new ArgumentException($"{propertyName} must be a future date.");
            }
            return value;
        }
    }
}
