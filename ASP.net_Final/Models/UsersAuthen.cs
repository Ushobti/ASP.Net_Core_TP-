﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ASP.net_Final.Models
{
    public class UsersAuthen : IdentityUser
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }
    }
}
