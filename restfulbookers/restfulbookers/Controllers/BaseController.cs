using RestfulBookerTestFramework.Core;

namespace RestfulBookerTestFramework.Controllers
{
    public class BaseController
    {
        protected readonly Client _client;

        public BaseController(Client client) 
        {
            this._client = client;
        }
    }
}
