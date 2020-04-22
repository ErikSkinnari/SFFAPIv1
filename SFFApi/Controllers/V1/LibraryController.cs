using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFFApi.Contracts.V1;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Domain;
using SFFApi.Services;

namespace SFFApi.Controllers.V1
{
    public class LibraryController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMovieLibraryService _movieLibraryService;

        public LibraryController(IMovieLibraryService movieLibraryService, IMovieService movieService)
        {
            _movieLibraryService = movieLibraryService;
            _movieService = movieService;
        }

        

    }
}