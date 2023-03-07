using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkyLauncher.Pages;

namespace SkyLauncher;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        string appGuid = "cafdfea8-9ca5-4c7b-9426-52ef31efdd5d";
        //string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
        string mutexId = string.Format("Global\\{{{0}}}", appGuid);
        bool createdNew = false;
        using (var mutex = new Mutex(false, mutexId, out createdNew))
        {
            var hasHandle = false;
            try
            {
                try
                {
                    hasHandle = mutex.WaitOne(1000, false);
                    if (hasHandle == false)
                        throw new TimeoutException("Timeout waiting for exclusive access");
                }
                catch (AbandonedMutexException)
                {
                    hasHandle = true;
                }

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var host = CreateHostBuilder().Build();
                ServiceProvider = host.Services;

                Application.Run(ServiceProvider.GetRequiredService<LoginFrame>());
            }
            finally
            {
                if (hasHandle)
                    mutex.ReleaseMutex();
            }
        }

        
    }
    public static IServiceProvider ServiceProvider { get; private set; }
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => {
                services.AddTransient<LoginFrame>();
            });
    }
}