using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateCSharp.Stopwatch
{
     class Program
    {
        public class Stopwatch
        {
            private DateTime _start;
            private DateTime _end;
            private TimeSpan _duration { get; set; }
            private Boolean _running; 
           
            public TimeSpan Duration
            {
                get {
                    _duration = _end - _start;
                    return _duration; 
                }
            } 
            public void Start() {
                if (_running)
                    throw new InvalidOperationException("Stopwatch is already running. Please stop Stopwatch before restarting");
                _start = DateTime.Now;
                _running = true;

             }
            public  void Stop() {
                if (!_running)
                    throw new InvalidOperationException("Stopwatch is not running. Please start Stopwatch before stopping");
               
                _end = DateTime.Now;
                _running = false;
            }  

        }

        public static void RunStopwatch()
        {
            var running = true;

            Console.Write("Type 'start' to start the stopwatch & 'stop' to stop it. \n" +
                "Type 'quit' to quit the program \n");
            var stopwatch = new Stopwatch();

            while (running)
            {
                var reply = Console.ReadLine();

                if (reply == "start")
                    stopwatch.Start();
                else if (reply == "stop")
                {
                    stopwatch.Stop();

                    Console.WriteLine("Time elapsed {0}", stopwatch.Duration);
                }
                else if (reply == "quit")
                {
                    Console.WriteLine("GoodBye");
                    running = false;
                }
                else
                    Console.WriteLine("Invalid entry {0}", reply);
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Stopwatch Program");
            Program.RunStopwatch();

        }
    }
}
