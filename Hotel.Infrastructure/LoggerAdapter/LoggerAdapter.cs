using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.LoggerAdapter
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
        where T : class
    {
        private readonly ILogger<T> _logger;

        public CategoriaException CategoriaException { get; private set; }
        

        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }
        public void LogCritical(string message)
        {
            _logger.LogCritical(message);
            
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogInformacion(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }
    }
}
