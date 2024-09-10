using RestfulBookerTestFramework.Models.Auth.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBookerTestFramework.Builders
{
    public class AuthorizationBuilder
    {
        private readonly AuthorizationModel _authorizationModel;

        public AuthorizationBuilder() 
        { 
            _authorizationModel = new AuthorizationModel();
        }

        public AuthorizationBuilder WithUserName(string userName)
        {
            _authorizationModel.Username = userName;
            return this;
        }

        public AuthorizationBuilder WithPassword(string password)
        {
            _authorizationModel.Password = password;
            return this;
        }

        public AuthorizationModel Build()
        {
            return _authorizationModel;
        }
    }
}
