using System.Collections.Generic;

namespace AjaxFun
{
    public class UserContext
    {
        public List<User> Users {get;set;}
        public UserContext()
        {
            Users = new List<User>();
        }
    }
    public class User
    {
        public string Name {get;set;}
        public string Location {get;set;}
    }
}