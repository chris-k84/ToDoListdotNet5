using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;
using System.Windows.Data;
using System.ComponentModel;

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
            mainList = JsonSerializer.Deserialize<ObservableCollection<ToDoListItem>>(jsonString);
            MessageBox.Show(mainList.Count.ToString());
        }
    }

    public class ToDoListItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        //public ToDoListItem(string taskName, string taskDescription)
        //{
        //    this.Name = taskName;
        //    this.Description = taskDescription;
        //}


    }
}
