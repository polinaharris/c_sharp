using JetBrains.Annotations;
using Polia02.Managers;
using Polia02.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Data;

namespace Polia02
{
    public class InfoViewModel : INotifyPropertyChanged
    {
        private string _filterQuery;
        private bool _sortingAsc = true;

        private Person _selectedPerson;
        private RelayCommand _openRegisterView;
        private RelayCommand _openEditView;
        private RelayCommand _deleteCommand;

        private RelayCommand _sortCommand;
        private RelayCommand _clearFilterCommand;

        private static CollectionView _sortFilterOptionsCollection;

        public string SelectedSoftFilterProperty { get; set; }
        public static CollectionView SortFilterOptions => _sortFilterOptionsCollection ??
                                                          (_sortFilterOptionsCollection =
                                                              new CollectionView(SortFiltertOptions));
        public string FilterQuery
        {
            get => _filterQuery;
            set
            {
                _filterQuery = value;
                SelectedPerson = null;
                RefreshPersonsAction();
            }
        }

        public List<Person> PersonsListToShow =>
           (string.IsNullOrEmpty(SelectedSoftFilterProperty) || string.IsNullOrEmpty(FilterQuery))
               ? PersonsList
               : FilterByProperty(PersonsList, SelectedSoftFilterProperty, FilterQuery);


        public List<Person> PersonsList { get; set; }
        public string SelectedPersonShort { get; private set; }
        public Action RefreshPersonsAction { get; }

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                if (_selectedPerson == null) return;
                SelectedPersonShort = $"{_selectedPerson.Name} {_selectedPerson.Surname}";
                OnPropertyChanged($"SelectedPersonShort");
            }
        }

        public RelayCommand OpenRegisterView
        {
            get
            {
                return _openRegisterView ?? (_openRegisterView = new RelayCommand(OpenRegister, o => true));
            }
        }

        public RelayCommand OpenEditView
        {
            get
            {
                return _openEditView ?? (_openEditView = new RelayCommand(OpenEdit, o => _selectedPerson != null));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete, o => _selectedPerson != null));
            }
        }

        public RelayCommand SortCommand =>
            _sortCommand ?? (_sortCommand =
                new RelayCommand(SortImpl, o => !string.IsNullOrEmpty(SelectedSoftFilterProperty)));

        private async void SortImpl(object o)
        {
            await Task.Run(() =>
            {
                PersonsList = SortByProperty(PersonsList, SelectedSoftFilterProperty, _sortingAsc);
                _sortingAsc = !_sortingAsc;
                OnPropertyChanged($"PersonsListToShow");
                RefreshPersonsAction();
            });
        }

        public RelayCommand ClearFilterCommand =>
            _clearFilterCommand ?? (_clearFilterCommand = new RelayCommand((o) =>
            {
                FilterQuery = "";
                OnPropertyChanged($"FilterQuery");
            },
                o => !string.IsNullOrEmpty(FilterQuery)));


        private void OpenRegister(object o)
        {
            var registerWindow = new RegisterView();
            registerWindow.Show();
        }

        private void OpenEdit(object o)
        {
            if(SelectedPerson != null)
            {
                var registerWindow = new RegisterView(RegisterView.Mode.Edit, SelectedPerson);
                registerWindow.Show();
            }
        }

        private async void Delete(object o)
        {
            await Task.Run(() =>
            {
                StationManager.RemoveUser(SelectedPerson);
                RefreshPersonsAction();
            });
        }

        public InfoViewModel(Action refreshPersons)
        {
            RefreshPersonsAction = refreshPersons;
            StationManager.LoadUsers();
            PersonsList = StationManager.CurrentUsers;
            RefreshPersonsAction();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static readonly string[] SortFiltertOptions = Array.ConvertAll(typeof(Person).GetProperties(), (property) => property.Name);

        public static List<Person> SortByProperty(List<Person> persons, string property, bool ascending)
        {
            return Array.IndexOf(SortFiltertOptions, property) >= 0
                ?
                    (ascending
                        ?
                        (from p in persons orderby p.GetType().GetProperty(property)?.GetValue(p, null) ascending select p).ToList()
                        :
                        (from p in persons orderby p.GetType().GetProperty(property)?.GetValue(p, null) descending select p).ToList()
                    )
                : persons;
        }

        public static List<Person> FilterByProperty(List<Person> persons, string property, string query)
        {
            if (Array.IndexOf(SortFiltertOptions, property) < 0) return new List<Person>();

            query = query.ToLower();
            return (from p in persons
                    where (p.GetType().GetProperty(property)?.GetValue(p, null)).ToString().ToLower().Contains(query)
                    select p).ToList();
        }
    }
}
