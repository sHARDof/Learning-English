using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        public static int index_infinitive = 0;
        public static int index_simple = 0;
        public static int index_participle = 0;

        public static string[] arr_words = new string[212];
        public static string[] arr_trans = new string[212];
        public static string[] arr_infinitive = new string[100];
        public static string[] arr_simple = new string[100];
        public static string[] arr_participle = new string[100];

        public static MainWindow Window;       

        public MainWindow()
        {           
            InitializeComponent();
            Window = this;
            foreach (string line in File.ReadLines(@"Words.txt"))
            {
                arr_words[index_words] = line;
                index_words++;
            }

            foreach (string lines in File.ReadLines(@"Translate.txt"))
            {
                arr_trans[index_trans] = lines;
                index_trans++;
            }

            foreach (string lines in File.ReadLines(@"Infinitive.txt"))
            {
                arr_infinitive[index_infinitive] = lines;
                index_infinitive++;
            }

            foreach (string lines in File.ReadLines(@"Past Simple.txt"))
            {
                arr_simple[index_simple] = lines;
                index_simple++;
            }

            foreach (string lines in File.ReadLines(@"Participle.txt"))
            {
                arr_participle[index_participle] = lines;
                index_participle++;
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
            if (Input_Trans.Text==arr_trans[acor])
            {
                Accept_Image.Visibility = Visibility.Visible;
                Close_Image.Visibility = Visibility.Hidden;
            }
            else
            {
                Close_Image.Visibility = Visibility.Visible;
                Accept_Image.Visibility = Visibility.Hidden;
            }
        }

        private void ShowStats_B(object sender, RoutedEventArgs e)
        {

        }

        private void ShowTimes_B(object sender, RoutedEventArgs e)
        {

        }

        private void ShowVerbs_B(object sender, RoutedEventArgs e)
        {
            Write_Infinitive();
            Write_Simple();
            Write_Participle();

            Border_word.Visibility = Visibility.Hidden;
            Border_Verbs.Visibility = Visibility.Visible;
            Online_Times.Visibility = Visibility.Hidden;
            Online_Words.Visibility = Visibility.Hidden;
            Online_Verbs.Visibility = Visibility.Visible;      
        }

        private void Write_Infinitive()
        {
            for (int i = 0; i < arr_infinitive.Length; i++)
            {
                first_form_verbs.Text = first_form_verbs.Text +arr_infinitive[i];
                first_form_verbs.Text = first_form_verbs.Text + "\n";
            }
        }

        private void Write_Simple()
        {
            for (int i = 0; i < arr_simple.Length; i++)
            {
                secound_form_verbs.Text = secound_form_verbs.Text + arr_simple[i];
                secound_form_verbs.Text = secound_form_verbs.Text + "\n";
            }
        }

        private void Write_Participle()
        {
            for (int i = 0; i < arr_participle.Length; i++)
            {
                three_form_verbs.Text = three_form_verbs.Text + arr_participle[i];
                three_form_verbs.Text = three_form_verbs.Text + "\n";
            }
        }

        private void ShowWords_B(object sender, RoutedEventArgs e)
        {
            Border_word.Visibility = Visibility.Visible;
            Border_Verbs.Visibility = Visibility.Hidden;
            Online_Times.Visibility = Visibility.Hidden;
            Online_Words.Visibility = Visibility.Visible;
            Online_Verbs.Visibility = Visibility.Hidden;
        }

        private void Back_text(object sender, RoutedEventArgs e)
        {
            Input_Trans.Text = "Translate word";
        }
    }
}
