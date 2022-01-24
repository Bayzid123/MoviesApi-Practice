using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesApi.Services
{
    public class MovieInTheatersService : IHostedService, IDisposable
    {
        private readonly IServiceProvider serviceProvider;
        private Timer timer;

        public MovieInTheatersService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using(var scope = serviceProvider.Create)
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
