using System.ComponentModel;

namespace WpfToDoList
{
    public class ToDoListItem : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        //public ToDoListItem(string taskName, string taskDescription)
        //{
        //    this.Name = taskName;
        //    this.Description = taskDescription;
        //}


    }
}
