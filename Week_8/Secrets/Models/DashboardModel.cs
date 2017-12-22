using System.Collections.Generic;

namespace Secrets.Models
{
    public class DashboardModel
    {
        public User User {get;set;}
        public Secret NewSecret {get;set;}
        public List<Secret> Secrets {get;set;}
    }
}