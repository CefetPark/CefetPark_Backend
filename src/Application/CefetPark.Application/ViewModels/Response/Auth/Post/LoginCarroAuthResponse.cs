﻿using CefetPark.Application.ViewModels.Response.Common.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Response.Auth.Post
{
    public class LoginCarroAuthResponse
    {
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
}
