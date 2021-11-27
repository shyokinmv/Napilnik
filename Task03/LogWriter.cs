using System;
using System.Collections.Generic;
using System.IO;

namespace Task03
{
    interface ILogWriter
    {
        void WriteError(string message);
    }

    class ConsoleLogWritter: ILogWriter
    {
        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogWritter: ILogWriter
    {
        public virtual void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class SecureLogWritter : ILogWriter
    {
        ILogWriter _logWriter;

        public SecureLogWritter(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        public virtual void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                _logWriter.WriteError(message);
            }
        }
    }

    class MultiLogWriter : ILogWriter
    {
        readonly IEnumerable<ILogWriter> _logWriters;

        public MultiLogWriter(IEnumerable<ILogWriter> logWriters)
        {
            _logWriters = logWriters;
        }

        public static MultiLogWriter Create(params ILogWriter[] logWriters)
        {
            return new MultiLogWriter(logWriters);
        }


        public void WriteError(string message)
        {
            foreach (var lw in _logWriters)
                lw.WriteError(message);
        }
    }
}
