using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GmailWithDataBase.Models
{
    public class UserRegistrationDB
    {
        [Key]
        public int UserID { get; set; }
        
        public string UserName { get; set; }
        
        public long Phone { get; set; }
       
        public string EmailId { get; set; }

        public string Password { get; set; }
    }
}
