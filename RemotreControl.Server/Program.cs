using System.ServiceProcess;

namespace RemotreControl.Server
{
    static class Program
    {
        public static void Main()
        {
            ServiceBase[] ServicesToRun = new ServiceBase[]
            {
                new ServereService(Properties.Settings.Default.ip, Properties.Settings.Default.port, Properties.Settings.Default.maxConnections)
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
