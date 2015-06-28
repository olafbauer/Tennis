using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    static class Translate
    {
        public static string[] Points = new string[] { "Love", "Fifteen", "Thirty", "Forty", "Deuce", "Advance", "Win" , "Undefined"};

        public static string Dict(int index)
        {
            return Points[index];
        }
    }
}
