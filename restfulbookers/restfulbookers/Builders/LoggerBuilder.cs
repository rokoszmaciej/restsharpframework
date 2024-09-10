using RestfulBookerTestFramework.Models;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBookerTestFramework.Builders
{
    public class LoggerBuilder
    {
        private readonly Request _request;

        public LoggerBuilder()
        {
            _request = new Request();
        }

        // Metoda do ustawienia metody HTTP
        public LoggerBuilder WithMethod(Method method)
        {
            _request.Method = method.ToString();
            return this;
        }

        // Metoda do ustawienia URL
        public LoggerBuilder WithUrl(string url)
        {
            _request.Url = url;
            return this;
        }

        // Metoda do dodania nagłówków
        public LoggerBuilder WithRequestBody(string body)
        {
            _request.RequestBody = body;
            return this;
        }

        public Request Build()
        {
            return _request;
        }
    }
}
