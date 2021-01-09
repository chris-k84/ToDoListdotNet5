using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ObservableCollection<ToDoListItem> mainList;
        //string dataFilePath;
        MainView _mainView;

        public MainWindow()
        {
            InitializeComponent();
             _mainView = new MainView();
            DataContext = _mainView;
            //mainList = new ObservableCollection<ToDoListItem>();
            //taskList.ItemsSource = mainList;
            //string[] paths = new string[] { Environment.CurrentDirectory, "Test" };
            //dataFilePath = Path.Combine(paths);
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

        private ObservableCollection<ToDoListItem> toDoListItems = new ObservableCollection<ToDoListItem>();

        public ICommand AddTask { get; set; }
        public ICommand RemoveTask { get; set; }

        public MainView()
        {
            AddTask = new Command(AddTaskMethod, canAddTask);
            RemoveTask = new Command(RemoveTaskMethod, canRemoveTask);
        }

        private void AddTaskMethod(Object paramter)
        {
            MessageBox.Show("YaY");
        }

        private bool canAddTask(Object paramter)
        {
            return true;
        }

        private void RemoveTaskMethod(Object parameter)
        {
            MessageBox.Show("removed");
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
}
