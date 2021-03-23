
using Xamarin.Essentials;

namespace PizzaIllico.Resources.Config
{

    enum ErrorCode
    {
        FIRST_NAME_INVALID, LAST_NAME_INVALID, EMAIL_INVALID, PASSWORD_INVALID, PASSWORD_TOO_SHORT,
        ALREADY_REGISTERED, REGISTRATION_ABORTED, LOGIN_ABORTED, CONNECTION_FAILURE
    }

    public enum EnumPages
    {
        HOME, LOGIN, MAP, REGISTRATION, PIZZERIA
    }

    class Config
    {

        public static string APP_NAME = "PizzaIllico";
        
        public static string URL_LOGIN = "https://pizza.julienmialon.ovh/api/v1/authentication/credentials";
        public static string URL_USER_REGISTRATION = "https://pizza.julienmialon.ovh/api/v1/accounts/register";
        public static string URL_SHOPS = "https://pizza.julienmialon.ovh/api/v1/shops";



        public static string CLIENT_ID = "MOBILE";
        public static string CLIENT_SECRET = "UNIV";

        public static string KEY_EMAIL = "email";
        public static string KEY_PASSWORD = "password";

        public static string APP_CACHE_ID = "Pizzaillico";
        public static string APP_CACHE_ENCRYPTION_KEY = "prs2kaIuv";
        public static string APP_CACHE_TOKEN_KEY = "kre3Zrft";
        public static string APP_CACHE_BASE_PATH = FileSystem.AppDataDirectory;

        public static string ToString(ErrorCode code)
        {
            switch (code)
            {
                case ErrorCode.LOGIN_ABORTED: return "login aborted"; 
                case ErrorCode.CONNECTION_FAILURE: return "connection failure";
                case ErrorCode.ALREADY_REGISTERED: return "this email is already registered"; 
                default: return "registration aborted"; 

            }
        }
    }

    


}
