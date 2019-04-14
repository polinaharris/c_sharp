using JetBrains.Annotations;
using System;
using System.Diagnostics;

namespace Polia05.Models
{
    public class UiThread
    {
        private readonly ProcessThread _thread;

        public int Id => _thread.Id;
        public ThreadState State => _thread.ThreadState;
        public DateTime LaunchDateTime => _thread.StartTime;

        internal UiThread([NotNull] ProcessThread thread)
        {
            _thread = thread;
        }

        public override bool Equals(object obj)
        {
            return obj is UiThread another && this._thread.Equals(another._thread);
        }

        public override int GetHashCode()
        {
            return _thread.GetHashCode();
        }
    }
}
