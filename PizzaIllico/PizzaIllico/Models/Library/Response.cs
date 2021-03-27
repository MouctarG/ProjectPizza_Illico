
namespace PizzaIllico.Models.Library
{
    class Response
    {
        private bool is_success;
        private string error_code;
        private string error_message;
        public bool Is_success { get => is_success; set => is_success = value; }
        public string Error_code { get => error_code; set => error_code = value; }
        public string Error_message { get => error_message; set => error_message = value; }

        public int Http_code { get; set; }

        public override string ToString()
        {
            string msg = "";
            if (error_code != null && error_message != "")
            {
                if (error_code != null && error_code != "") msg = ": [" + error_code + "]" + " " + error_message;
                else msg = ": " + error_message;
            }
            else if (error_code != null && error_code != "") msg = " : [" + error_code + "]";

            return msg;
        }
    }
}
