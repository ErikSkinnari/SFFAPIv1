using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Version = "v1";
        public const string Root = "api";
        public const string Base = Root + "/" + Version;

        public static class Movies
        {
            public const string GetAll = Base + "/movies";
            public const string Get = Base + "/movies/{Id}";
            public const string Create = Base + "/movies";
            public const string Update = Base + "/movies/{Id}";
            public const string Delete = Base + "/movies/{Id}";
        }

        public static class Studios
        {
            public const string GetAll = Base + "/studios";
            public const string Get = Base + "/studios/{Id}";
            public const string Create = Base + "/studios";
            public const string Update = Base + "/studios/{Id}";
            public const string Delete = Base + "/studios/{Id}";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
        }

        public static class Label
        {
            public const string Simple = Base + "/label/basic";
            public const string Detailed = Base + "/label/full";
        }
    }
}
