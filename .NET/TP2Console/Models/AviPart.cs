using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Console.Models.EntityFramework
{
    partial class Avi
    {
        public string ToString()
        {
            return this.UtilisateurNavigation.Email + " " + this.Note;
        }
    }
}
