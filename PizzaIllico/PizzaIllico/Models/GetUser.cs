namespace PizzaIllico.Models
{
    public class GetUser
    {
        private DataUser _dataUser;
        private bool is_success;
        private string error_code;
        private string error_message;

        public DataUser DataUser => _dataUser;

        public bool IsSuccess => is_success;

        public string ErrorCode => error_code;

        public string ErrorMessage => error_message;
    }
}