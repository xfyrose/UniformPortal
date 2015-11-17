using System.Diagnostics;

namespace Util.Core
{
    public class Test
    {
        public Test()
        {
            _watch = new Stopwatch();
        }

        private readonly Stopwatch _watch;

        public void Start()
        {
            _watch.Start();
        }

        public void Stop()
        {
            _watch.Stop();
        }

        public double GetElapsed()
        {
            return _watch.Elapsed.TotalSeconds;
        }

        public double GetElapsedAndStop()
        {
            Stop();
            return GetElapsed();
        }
    }
}