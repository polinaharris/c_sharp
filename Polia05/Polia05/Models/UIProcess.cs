using System;
using System.Collections.Generic;
using System.Diagnostics;
using Polia05.Models;
using Polia05.Tools;

namespace Polia05
{
    public class UiProcess
    {
        private readonly Process _process;
        private PerformanceCounter _cpuCounter;

        public string Name => _process.ProcessName;
        public int Id => _process.Id;
        public string User => _process.MachineName;
        public string Path { get; set; }
        public DateTime LaunchDateTime => _process.StartTime;

        public bool IsActive => _process.Responding;

        private float _cpu;

        public float CPU
        {
            get
            {
                RefreshCpu();
                return _cpu;
            }
            private set
            {
                _cpu = value;
            }
        }
        public long MEM => _process.PrivateMemorySize64 / 1024;
        public int ThreadsCnt => _process.Threads.Count;

        private HashSet<UiModule> _modules;

        public HashSet<UiModule> Modules
        {
            get
            {
                if (_modules == null)
                    RefreshModules();
                return _modules;
            }
        }

        private HashSet<UiThread> _threads;

        public HashSet<UiThread> Threads
        {
            get
            {
                if (_threads == null)
                    RefreshThreads();
                return _threads;
            }
        }

        internal UiProcess([JetBrains.Annotations.NotNull] Process process)
        {
            _process = process;
            try
            {
                Path = _process.MainModule.FileName;
            }
            catch(Exception)
            {
                Path = "";
            }

            try
            {
                _cpuCounter = ProcessCpuCounter.GetPerfCounterForProcessId(_process.Id);
                _cpuCounter.NextValue();
            }
            catch(Exception)
            {
                
            }
        }

        internal void RefreshModules()
        {
            if (_modules == null)
                _modules = new HashSet<UiModule>();
            foreach (ProcessModule m in _process.Modules)
            {
                _modules.Add(new UiModule(m));
            }
        }

        internal void RefreshCpu()
        {
            if(_cpuCounter != null)
            {
                CPU = _cpuCounter.NextValue() / Environment.ProcessorCount;
            }
            else
            {
                CPU = 0;
            }
        }

        internal void RefreshThreads()
        {
            if (_threads == null)
                _threads = new HashSet<UiThread>();
            foreach (ProcessThread t in _process.Threads)
            {
                _threads.Add(new UiThread(t));
            }
        }

        public override bool Equals(object obj)
        {
            return obj is UiProcess another && this.Id == another.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}