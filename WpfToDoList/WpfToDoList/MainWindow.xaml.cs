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

        int selectedItem = -1;

        public MainWindow()
        {
            InitializeComponent();
            mainList = new ObservableCollection<ToDoListItem>();
            taskList.ItemsSource = mainList;
        }

        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            mainList.Add(new ToDoListItem(taskField.Text));

        }

        private void removeTask_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class ToDoListItem
    {
        public string text { get; set; }

        public ToDoListItem(string itemText)
        {
            this.text = itemText;
        }


    }
}
