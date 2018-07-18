using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ListaDeOrcamento
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "NewPeca",
                url: "inserir-nova-peca",
                defaults: new { controller = "Home", action = "NewPeca", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ExcluirPeca",
                url: "Excluir-peca",
                defaults: new { controller = "Home", action = "ExcluirPeca", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditarPeca",
                url: "Editar-peca",
                defaults: new { controller = "Home", action = "EditarPeca", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
