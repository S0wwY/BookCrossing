﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models
{
    public class User : IdentityUser
    {
        public virtual IEnumerable<Book> Books { get; set; }
        public virtual IEnumerable<UserBookHistory> UserBooks { get; set; }
    }
}
