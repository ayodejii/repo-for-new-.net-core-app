using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BopHubData.Model
{
    [Table("Accounts")]
    public class Account
    {
        public int Id { get; set; }
        [Required][StringLength(40), MinLength(4)]
        public string Username { get; set; }
        [Required][StringLength(40), MinLength(4)]
        public string Password { get; set; }
    }
}
