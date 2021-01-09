using System.IO;
using System.Windows;
using System.Text.Json;
using System.Windows.Data;

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

       
    }
}
