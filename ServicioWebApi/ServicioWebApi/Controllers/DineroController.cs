using EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioWebApi.Controllers
{
    public class DineroController : ApiController
    {
        readonly ProyectoFinalEntities entities;
        public DineroController()
        {
            entities = new ProyectoFinalEntities();
        }


        public PruebaAplicada GetTestMoney()
        {
            return entities.PruebaAplicada.First();
        }
    }
}
