using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebLuisArrieta
{
	public partial class Startup
	{
        public void ConfigInjector()
        {
            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.RegisterAssembly("WebLuisArrieta.Model*.dll");
            container.RegisterAssembly("WebLuisArrieta.Repositorio*.dll");
            container.RegisterControllers();
            container.EnableMvc();
        }
	}
}