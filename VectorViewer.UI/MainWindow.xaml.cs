namespace VectorViewer.UI
{
    using System.Windows;
    using Interfaces;
    using PrimitivesViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow(
            IPrimitivesViewModel primitivesViewModel)
        {
            InitializeComponent();
            DataContext = primitivesViewModel.Initialize(this);
        }
    }
}