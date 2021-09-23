using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Console.Models.EntityFramework
{
    partial class Film
    {
        public string ToString()
        {
            return this.Nom;
        }
    }
}
