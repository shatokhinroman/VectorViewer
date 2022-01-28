namespace VectorViewer
{
    using System.Windows;
    using Interfaces;
    using LightInject;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Bootstrapper.InitializeModules();
        }

        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = ContainerProvider.Container.GetInstance<IMainWindow>();
            mainWindow.Show();            
        }
    }
}