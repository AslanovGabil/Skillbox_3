﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Models
{
    public class Vedomstvo
    {
        public Employee VedomstvoBoss { get; set; }
       
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
    }
}
