using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Learning_English
{
    public partial class MainWindow : Window
    {
        public string trans;
        public string worders;

        static string base_directory = Directory.GetCurrentDirectory();

        public static MainWindow Window;
        
        static StreamReader words = new StreamReader(base_directory + @"\temp\Words.txt");
        static StreamReader translation = new StreamReader(base_directory + @"\temp\Translate.txt");

        public MainWindow()
        {           
            InitializeComponent();
            Window = this;
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Window.DragMove();
            }
        }

        private void NextWord(object sender, RoutedEventArgs e)
        {
            worders = words.ReadLine();
            trans = translation.ReadLine();
            Words.Content = worders;            
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HideWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Translate(object sender, RoutedEventArgs e)
        {
            Words.Content = worders + " - " + trans;
        }

        private void Verify(object sender, RoutedEventArgs e)
        {
            if (Input_Trans.Text == trans)
            {
                AcceptImage.Visibility = Visibility.Visible;
                CloseImage.Visibility = Visibility.Hidden;
            }
            else
            {
                AcceptImage.Visibility = Visibility.Hidden;
                CloseImage.Visibility = Visibility.Visible;
            }
        }
    }
}
