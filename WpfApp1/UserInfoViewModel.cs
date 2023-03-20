using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfApp1
{
    public class UserInfoViewModel : INotifyPropertyChanged
    {
        private User user;

        public UserInfoViewModel()
        {
            user = new User();
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        public string UserName
        {
            get { return user.Name; }
            set
            {
                user.Name = value;
                OnPropertyChanged("UserName");
            }
        }

        public int UserAge
        {
            get { return user.Age; }
            set
            {
                user.Age = value;
                OnPropertyChanged("UserAge");
            }
        }

        public string UserInfo
        {
            get { return $"Name:{UserName} Age:{UserAge}"; }
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        private void Save(object parameter)
        {
            // Save user data to database or service
            MessageBox.Show("User data saved!");

            OnPropertyChanged("UserInfo");
        }

        private void Cancel(object parameter)
        {
            // Close dialog window without saving data
            var window = parameter as Window;
            if (window != null)
                window.Close();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
