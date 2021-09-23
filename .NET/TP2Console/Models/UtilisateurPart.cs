using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Console.Models.EntityFramework
{
    partial class Utilisateur
    {
        public string ToString()
        {
            return this.Login;
        }
    }
}
