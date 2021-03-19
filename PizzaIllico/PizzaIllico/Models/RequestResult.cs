using PizzaIllico.Resources.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaIllico.Models
{
    class RequestResult
    {
        private bool is_success;
        private ErrorCode error_code;
        
        public bool Is_success 
        { 
            get => is_success; 
            set => is_success = value; 
        }
        public ErrorCode Error_code 
        { 
            get => error_code; 
            set => error_code = value; 
        }
    }
}
