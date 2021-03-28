
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
        HOME, LOGIN, MAP, REGISTRATION, PIZZERIA, PROFILE_UPDATE, PASSWORD_UPDATE, CART, ORDER_HISTORY
    }

    class Config
    {

        public static string APP_NAME = "PizzaIllico";
        
        public static string URL_LOGIN = "https://pizza.julienmialon.ovh/api/v1/authentication/credentials";
        public static string URL_USER_REGISTRATION = "https://pizza.julienmialon.ovh/api/v1/accounts/register";
        public static string URL_SHOPS = "https://pizza.julienmialon.ovh/api/v1/shops";
        public static string URL_UPDATE_PASSWORD = "https://pizza.julienmialon.ovh/api/v1/authentication/credentials/set";
        public static string URL_REFRESH_TOKEN = "https://pizza.julienmialon.ovh/api/v1/authentication/refresh";
        public static string URL_UPDATE_PROFILE = "https://pizza.julienmialon.ovh/api/v1/accounts/me";


        public static string RESOURCE_IMAGE_LOGGED_IN = "account2_45";
        public static string RESOURCE_IMAGE_ACCOUNT = "account45";

        public static string CLIENT_ID = "MOBILE";
        public static string CLIENT_SECRET = "UNIV";

        public static string KEY_EMAIL = "Email";
        public static string KEY_PASSWORD = "Password";
        public static string KEY_PHONE_NUMBER = "Phone_number";
        public static string KEY_FIRST_NAME = "First_name";
        public static string KEY_LAST_NAME = "Last_name";
        public static string KEY_AUTHENTICATION_TOKEN = "authentication_token";
        public static string KEY_CART = "cart";
        public static string KEY_ORDER_HISTORY = "order_history";


        public static string KEY_PIZZERIA = "pizzeria";

        public static string MSG_LOGGED_IN = "[ Logged in]";
        public static string MSG_LOGGED_OUT = "[ Logged out]";

        public static string APP_CACHE_ID = "Pizzaillico";
        public static string APP_CACHE_ENCRYPTION_KEY = "prs2kaIuv";
        public static string APP_CACHE_TOKEN_KEY = "kre3Zrft";
        public static string APP_CACHE_BASE_PATH = FileSystem.AppDataDirectory;


        public static string Pizzeria_getURI(string pizzeria_id)
        {
            return URL_SHOPS + "/" + pizzeria_id + "/" + "pizzas";
        }
        public static string PizzeriaPizzaImage_getURI(string pizzeria_id, string pizza_id)
        {
            return Pizzeria_getURI(pizzeria_id) + "/" + pizza_id + "/image";
        }
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
