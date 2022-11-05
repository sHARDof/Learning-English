using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Learning_English
{
    public partial class MainWindow : Window
    {
        public string trans;
        public string worders;

        public static Random rnd = new Random();

        public static int acor;
        public static int index_words = 0;
        public static int index_trans = 0;

        public static string[] arr_words = new string[212];
        public static string[] arr_trans = new string[212];

        static string base_directory = Directory.GetCurrentDirectory();

        public static MainWindow Window;
        
        static StreamReader words = new StreamReader(base_directory + @"\temp\Words.txt");
        static StreamReader translation = new StreamReader(base_directory + @"\temp\Translate.txt");

        public MainWindow()
        {           
            InitializeComponent();
            Window = this;
            foreach (string line in File.ReadLines(@"C:\Users\sHARD\source\repos\test\test\Words.txt"))
            {
                arr_words[index_words] = line;
                index_words++;
            }

            foreach (string lines in File.ReadLines(@"C:\Users\sHARD\source\repos\test\test\Translate.txt"))
            {
                arr_trans[index_trans] = lines;
                index_trans++;
            }
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
            acor = rnd.Next(0, 212);                    
            Words.Content = arr_words[acor];
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
            Words.Content = arr_words[acor] + " - " + arr_trans[acor];
        }

        private void Verify(object sender, RoutedEventArgs e)
        {
            if (Input_Trans.Text == arr_trans[acor])
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
