using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaIllico.Models
{
    class LoginOutput
    {

        private string login;
        private string password;
        private UserAuthentication _data = new UserAuthentication();
        private RequestResult _result = new RequestResult();
        public string Login
        {
            get => login;
            set => login = value;
        }
        public string Password
        {
            get => password;
            set => password = value;
        }

        public UserAuthentication Data { 
            get => _data;
            set => _data = value;
        }
        public RequestResult Result 
        { 
            get => _result;
            set => _result = value;
        }

        public LoginOutput(string login, string password)
        {
            this.login = login;
            this.password = password;
            
        }
        public LoginOutput()
        {
            this.login = "";
            this.password = "";

        }
    }
}
