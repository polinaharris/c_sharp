using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Polia05
{
    public class ProcessesViewModel : INotifyPropertyChanged
    {
        private Action _refresh;
        public UiProcess SelectedProcess { get; set; }
        public HashSet<UiProcess> ProcessesList { get; set; }
        public Process[] _processes = Process.GetProcesses();


        internal ProcessesViewModel(Action refreshGridAction)
        {
            _refresh = refreshGridAction;
            ProcessesList = new HashSet<UiProcess>();
            foreach (var process in _processes)
            {
                 ProcessesList.Add(new UiProcess(process));
            }
        }

        internal async Task Update()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                while (true)
                {
                    _processes = Process.GetProcesses();
                    ProcessesList.Clear();
                    foreach (var process in _processes)
                    {
                        ProcessesList.Add(new UiProcess(process));
                    }
                    _refresh();
                    Thread.Sleep(5000);
                }
            });
        }

        public void KillCommand(object parameter)
        {
            var id = (int)parameter;
            var process = Process.GetProcessById(id);
            ProcessesList.RemoveWhere(o => o.Id == id);
            process.Kill();
            _refresh();
        }

        public void OpenFolder(object parameter)
        {
            var id = (int)parameter;

            var process = ProcessesList.First(o => o.Id == id);
            int index = process.Path.LastIndexOf("\\");
            string folderPath = "";
            if (index > 0)
                folderPath = process.Path.Substring(0, index);
            if(folderPath != "")
                Process.Start(folderPath);
        }

        #region Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
