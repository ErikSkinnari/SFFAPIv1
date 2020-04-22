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
            public const string GetAll =    Base + "/movies";
            public const string Get =       Base + "/movies/{Id}";
            public const string Create =    Base + "/movies";
            public const string Update =    Base + "/movies/{Id}";
            public const string Delete =    Base + "/movies/{Id}";
            public const string Loan =      Base + "/movies/{movieId}/request/{studioId}";
            public const string Return =    Base + "/movies/{movieId}/return/{studioId}";
        }

        public static class Studios
        {
            public const string GetAll =    Base + "/studios";
            public const string Get =       Base + "/studios/{Id}";
            public const string Create =    Base + "/studios";
            public const string Update =    Base + "/studios/{Id}";
            public const string Delete =    Base + "/studios/{Id}";
            public const string ListMovies = Base + "/studios/{studioId}/movies";
        }

        public static class Identity
        {
            public const string Login =     Base + "/identity/login";
            public const string Register =  Base + "/identity/register";
        }

        public static class Library
        {
            public const string Create =    Base + "/library/add/{movieId},{licenseLimit}";
            public const string Update =    Base + "/library/{Id}";
            public const string Delete =    Base + "/library/{Id}";
        }

        public static class Label
        {
            public const string Simple = Base + "/label/basic/{loanId}";
            public const string Detailed = Base + "/label/full/{loanId}";
        }

        public static class Trivia
        {
            public const string Get = Base + "/trivia/{movieId}";
            public const string Create = Base + "/trivia";
            public const string Delete = Base + "/trivia{Id}";
        }

        public static class Scores
        {
            public const string Get = Base + "/scores/{Id}";
            public const string GetAll = Base + "/scores/{Id}";
            public const string Create = Base + "/scores";
            public const string Update = Base + "/scores/{Id}";
            public const string Delete = Base + "/scores/{Id}";
        }
    }
}
