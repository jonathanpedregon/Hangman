using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            var hangman = new Hangman("nigganigganigga"); //the constructor takes the word you want to guess
            hangman.Run();
        }
    }
}
