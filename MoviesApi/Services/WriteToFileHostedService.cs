using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesApi.Services
{
    public class WriteToFileHostedService : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string filename = "File 1.txt";
        private Timer timer;
        public WriteToFileHostedService(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            WriteToFile("Process Started");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile("Process Stopped");                       
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            WriteToFile("Process Ongoing: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }

        private void WriteToFile(string message)
        {
            var path = $@"{env.ContentRootPath}\wwwroot\{filename}";
            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
