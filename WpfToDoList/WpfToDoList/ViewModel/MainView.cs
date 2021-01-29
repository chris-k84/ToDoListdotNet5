using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using System.Text.Json;
using System.IO;

namespace WpfToDoList
{
    public class MainView : INotifyPropertyChanged
    {
        private ToDoListItem _newTask = new ToDoListItem();

        private string dataFilePath;

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
            string[] paths = new string[] { Environment.CurrentDirectory, "TaskListData" };
            dataFilePath = Path.Combine(paths);
            //_newTask.PropertyChanged += TestEvent;
        }

        public void OnViewStart(Object source, EventArgs e)
        {
            if (File.Exists(dataFilePath))
            {
                string jsonString = File.ReadAllText(dataFilePath);
                ObservableCollection<ToDoListItem> loaded = JsonSerializer.Deserialize<ObservableCollection<ToDoListItem>>(jsonString);
                foreach (ToDoListItem x in loaded)
                {
                    TaskList.Add(x);
                }
            }
        }

        public void OnViewClose(object source, EventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(_taskList);
            File.WriteAllText(dataFilePath, jsonString);
        }

        private void AddTaskMethod(Object paramter)
        {
            NewTask = new ToDoListItem { Name = _newTask.Name, Description = _newTask.Description };
            TaskList.Add(NewTask);
        }

        private bool canAddTask(Object paramter)
        {
            return true;
        }

        private void RemoveTaskMethod(Object parameter)
        {
            if (parameter != null)
            {
                int element = Int16.Parse(parameter.ToString());
                if (element != -1)
                {
                    TaskList.RemoveAt(element);
                }
                
            }
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

        private void TestEvent(Object source, EventArgs e)
        {
            MessageBox.Show("you got it");
        }
    }
}
