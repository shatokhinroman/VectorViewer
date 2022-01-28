namespace VectorViewer
{
    using System;
    using System.IO;
    using System.Reflection;

    public class Bootstrapper
    {
        public static void InitializeModules()
        {
            var files = Directory.GetFiles(AppContext.BaseDirectory, "VectorViewer.*.dll");
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var name = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
                var assembly = Assembly.Load(new AssemblyName(name));
                ContainerProvider.Container.RegisterAssembly(assembly);
            }
        }
    }
}