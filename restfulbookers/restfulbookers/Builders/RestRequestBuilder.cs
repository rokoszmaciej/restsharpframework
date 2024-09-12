using RestfulBookerTestFramework.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBookerTestFramework.Builders
{
    public class RestRequestBuilder
    {
        private readonly RestRequest _restRequest;

        public RestRequestBuilder()
        {
            _restRequest = new RestRequest();
        }

        public RestRequestBuilder WithResource(string resource)
        {
            _restRequest.Resource = resource;
            return this;
        }

        public RestRequestBuilder WithUrlSegment(string parameter, string value)
        {
            _restRequest.AddUrlSegment(parameter, value);
            return this;
        }

        public RestRequestBuilder WithMethod(Method method) 
        {
            _restRequest.Method = method;
            return this;
        }

        public RestRequestBuilder WithHeader(string name, string value) 
        {
            _restRequest.AddHeader(name, value);
            return this;
        }

        public RestRequestBuilder WithJsonBody(object body)
        {
            var serialized = JsonHelpers.SerializeToJson(body);
            _restRequest.AddJsonBody(serialized);
            return this;
        }

        public RestRequestBuilder WithBody(object body)
        {
            _restRequest.AddJsonBody(body);
            return this;
        }

        public RestRequest Build()
        {
            return _restRequest;
        }

    }
}
