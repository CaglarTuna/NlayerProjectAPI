﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NLayerProject.Core.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Password{ get; set; }
        public string Phone{ get; set; }
    }
}
