using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ASP.net_Final.Models
{
    public class ToDo
    {
        public int ID { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public UsersAuthen User { get; set; }

    }
}
