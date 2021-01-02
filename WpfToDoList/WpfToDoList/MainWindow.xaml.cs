using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ToDoListItem> mainList; 

        public MainWindow()
        {
            InitializeComponent();
            mainList = new ObservableCollection<ToDoListItem>();
            taskList.ItemsSource = mainList;
        }

        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            mainList.Add(new ToDoListItem(taskNameField.Text,taskDescriptionField.Text));
        }

        private void removeTask_Click(object sender, RoutedEventArgs e)
        {
            mainList.RemoveAt(taskList.SelectedIndex);
        }
    }

    public class ToDoListItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ToDoListItem(string taskName, string taskDescription)
        {
            this.Name = taskName;
            this.Description = taskDescription;
        }


    }
}
