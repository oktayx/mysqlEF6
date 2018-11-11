using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MysqlEF6.Helpers
{
    public class Persons
    {
        public string PersonName { get; set; }
        [Key]
        public int PersonId { get; set; }
    }
}