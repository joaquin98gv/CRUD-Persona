using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CRUD_Persona.Models
{
    public class ControllerManager: ApiController
    {
        protected crudPEntities db;
        public ControllerManager()
        {
            db = new crudPEntities();
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }
    }
}