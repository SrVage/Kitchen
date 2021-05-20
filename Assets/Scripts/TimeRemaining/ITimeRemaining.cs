using System;

namespace DefaultNamespace
{
    public interface ITimeRemaining
    {
        Action Method { get; }
        float Time { get; }
        float CurrentTime { get; set; }
    }
}