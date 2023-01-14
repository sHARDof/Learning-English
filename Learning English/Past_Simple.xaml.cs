using System.Windows;
using System.Windows.Input;


namespace Learning_English
{
    public partial class Past_Simple : Window
    {
        public static Past_Simple Window;
        public Past_Simple()
        {
            InitializeComponent();
            Window = this;            
        }
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window.DragMove();
            }
        }
        private void HideWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void CloseWindow1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();            
        }
    }
}
