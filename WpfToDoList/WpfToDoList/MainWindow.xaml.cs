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
        ObservableCollection<ToDoListItem> mainList;
        string dataFilePath;

        public MainWindow()
        {
            InitializeComponent();
            mainList = new ObservableCollection<ToDoListItem>();
            taskList.ItemsSource = mainList;
            string[] paths = new string[] { Environment.CurrentDirectory, "Test" };
            dataFilePath = Path.Combine(paths);
        }

        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoListItem toDoListItem = new ToDoListItem();
            toDoListItem.Name = taskNameField.Text;
            toDoListItem.Description = taskDescriptionField.Text;
            mainList.Add(toDoListItem);
        }

        private void removeTask_Click(object sender, RoutedEventArgs e)
        {
            mainList.RemoveAt(taskList.SelectedIndex);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(mainList);
            File.WriteAllText(dataFilePath, jsonString);
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(dataFilePath);
            ObservableCollection<ToDoListItem> loaded = JsonSerializer.Deserialize<ObservableCollection<ToDoListItem>>(jsonString);
            foreach (ToDoListItem x in loaded)
            {
                mainList.Add(x);
            }
            MessageBox.Show(mainList.Count.ToString());
        }
    }

    public class MainView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ToDoListItem toDoListItem = new ToDoListItem();

        private ObservableCollection<ToDoListItem> toDoListItems = new ObservableCollection<ToDoListItem>();

        public ICommand AddTask { get; set; }

        public MainView()
        {
            AddTask = new Command(AddTaskMethod, canAddTask);
        }

        private void AddTaskMethod(Object paramter)
        {
            
           
        }
        private bool canAddTask(Object paramter)
        {
            return true;
        }
    }
}
