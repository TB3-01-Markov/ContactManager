using ContactManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.CLI
{
    public class SystemConsole : IConsole
    {
        public void WriteLine(string message) => Console.WriteLine(message);
        public void Write(string message) => Console.Write(message);
        public string ReadLine() => Console.ReadLine()!;
    }
}
