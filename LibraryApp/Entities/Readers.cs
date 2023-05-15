﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class Readers : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => $"Id: {Id}, First name: {FirstName}, Last name: {LastName}";
    }
}
