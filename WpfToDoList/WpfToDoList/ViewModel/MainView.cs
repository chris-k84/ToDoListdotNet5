using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfToDoList
{
    public class MainView : INotifyPropertyChanged
    {
        private ToDoListItem _newTask = new ToDoListItem();

        public ToDoListItem NewTask
        {
            get
            {
                return _newTask;
            }
            set
            {
                _newTask = value;
                OnPropertyChanged("NewTask");
            }
        }

        private ObservableCollection<ToDoListItem> _taskList = new ObservableCollection<ToDoListItem>();

        public ObservableCollection<ToDoListItem> TaskList
        {
            get
            {
                return _taskList;
            }
            set
            {
                _taskList = value;
                OnPropertyChanged("TaskList");
            }
        }

        public ICommand AddTask { get; set; }
        public ICommand RemoveTask { get; set; }

        public MainView()
        {
            AddTask = new Command(AddTaskMethod, canAddTask);
            RemoveTask = new Command(RemoveTaskMethod, canRemoveTask);
        }

        private void AddTaskMethod(Object paramter)
        {
            TaskList.Add(_newTask);
        }

        private bool canAddTask(Object paramter)
        {
            return true;
        }

        private void RemoveTaskMethod(Object parameter)
        {
            MessageBox.Show("remove");
        }

        private bool canRemoveTask(Object parameter)
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    //private void addTask_Click(object sender, RoutedEventArgs e)
    //{
    //    ToDoListItem toDoListItem = new ToDoListItem();
    //    toDoListItem.Name = taskNameField.Text;
    //    toDoListItem.Description = taskDescriptionField.Text;
    //    mainList.Add(toDoListItem);
    //}

    //private void removeTask_Click(object sender, RoutedEventArgs e)
    //{
    //    mainList.RemoveAt(taskList.SelectedIndex);
    //}

    //private void save_Click(object sender, RoutedEventArgs e)
    //{
    //    string jsonString = JsonSerializer.Serialize(mainList);
    //    File.WriteAllText(dataFilePath, jsonString);
    //}

    //private void load_Click(object sender, RoutedEventArgs e)
    //{
    //    string jsonString = File.ReadAllText(dataFilePath);
    //    ObservableCollection<ToDoListItem> loaded = JsonSerializer.Deserialize<ObservableCollection<ToDoListItem>>(jsonString);
    //    foreach (ToDoListItem x in loaded)
    //    {
    //        mainList.Add(x);
    //    }
    //    MessageBox.Show(mainList.Count.ToString());
    //}
}
