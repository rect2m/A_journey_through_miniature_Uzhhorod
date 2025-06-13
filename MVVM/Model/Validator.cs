using System.Text.RegularExpressions;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model
{
    class Validator
    {
        // Валідація імені користувача
        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username) &&
                   username.Length >= 3 &&
                   username.Length <= 20 &&
                   Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"); // Літери, цифри, підкреслення
        }

        // Валідація Email
        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) &&
                   Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // Валідація пароля (мінімум 6 символів, хоча б одна літера і одна цифра)
        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) &&
                   password.Length >= 6 &&
                   Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$");
        }
    }
}
