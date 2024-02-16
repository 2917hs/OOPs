using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class AllSamples
    {
        public AllSamples()
        {
            IColor ic = new Blue();
            ic.GetColor();
        }
    }

    public interface IColor
    {
        void GetColor();
    }

    public class Green : IColor
    {
        public void GetColor()
        {
            System.Console.WriteLine("Green");
        }
    }

    public class Blue : IColor
    {
        public void GetColor()
        {
            System.Console.WriteLine("Blue");
        }
    }

    public sealed class Logger
    {
        private static Logger? loggerInstance = null;

        private static readonly object lockObject = new object();

        private Logger()
        {

        }

        public static Logger LoggerInstance
        { 
            get
            {
                lock (lockObject)
                {
                    if (loggerInstance is null)
                    {
                        lock (lockObject)
                        {
                            loggerInstance = new Logger();
                        }
                    }
                }
                return loggerInstance;
            }
        }
    }
}