using System;
using System.Windows;
using System.Text.Json;
using System.Windows.Data;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
        private int maxNumber = 0;
        private int currentNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitialiseClient();
            _mainView = new MainView();
            DataContext = _mainView;
            toDoList.ItemsSource = _mainView.TaskList;
            addTask.Command = _mainView.AddTask;
            this.Loaded += _mainView.OnViewStart;
            this.Closed += _mainView.OnViewClose;  
        }

        private async Task LoadImage(int imageNumber =0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);

            if (imageNumber == 0)
            {
                maxNumber = comic.Num;
            }

            currentNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            imageSpot.Source = new BitmapImage(uriSource);
        }
    }
}
