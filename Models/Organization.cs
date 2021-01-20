using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Models
{
    public class Organization
    {
        public Employee Boss { get; set; }
        public Employee ExtBoss { get; set; }
     
        public string Name { get; set; }
        public List<Vedomstvo> Vedomstvos { get; set; }

    }
}
