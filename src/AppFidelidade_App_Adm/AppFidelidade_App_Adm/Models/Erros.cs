using System;

namespace AppFidelidade_App_Adm.Models
{

    public class Errors
    {
        public Error[] errors { get; set; }
    }

    public class Error
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }
    }

}
