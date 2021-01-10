using System;
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
            toDoList.ItemsSource = _mainView.TaskList;
            addTask.Command = _mainView.AddTask;


            this.Loaded += _mainView.OnViewStart;
            this.Closed += _mainView.OnViewClose;  
        }
    }
}
