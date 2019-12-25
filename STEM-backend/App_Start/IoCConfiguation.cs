using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;

namespace STEM_backend.App_Start
{
    public static class IoCConfiguation
    {
        public static void DependenceInjection(HttpConfiguration http)
        {
            var container = new UnityContainer();
            http.DependencyResolver = new UnityResolver(container);
            return;
        }
    }
}