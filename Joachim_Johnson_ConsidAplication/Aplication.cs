using DataLayer.DataAcess;
using Joachim_Johnson_ConsidAplication;
using Joachim_Johnson_ConsidAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joachim_Johnson_ConsidAplication
{
    public class Aplication
    {
        public class Application : IAplication
        {
            ICordinatesModells _CordinatesModells;

            public Application(ICordinatesModells CordinatesModells)
            {
                _CordinatesModells = CordinatesModells;
            }

            public void Run()
            {

            }
        }
    }
}