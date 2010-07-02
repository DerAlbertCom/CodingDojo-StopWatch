using System;

namespace CodingDojo.StopWatch
{
    public interface IDojoTime
    {
        TimeSpan Time { get; }
        void Increase();
        void Decrease();
    }
}