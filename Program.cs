using System;

namespace server
{
    class Program
    {
        static void Main()
        {
	    new Server(80);
            Console.WriteLine("Server started..");
        }
    }
}
