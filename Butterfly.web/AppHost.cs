using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.web
{
    using Funq;
    using ServiceStack;
    using ServiceStack.ServiceInterface.Cors;
    using ServiceStack.WebHost.Endpoints;
    using Butterfly.Declarations.Contracts.EndPoints;
    public class AppHost : AppHostBase
    {
         public AppHost()
            : base("Butterfly.web", typeof(AddDropDownItem).Assembly)
        {


        }
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            this.Plugins.Add(new CorsFeature());
            RequestFilters.Add((httpReq, httpRes, requestDto) =>
            {
                if (httpReq.HttpMethod == "OPTIONS")
                {
                    httpRes.AddHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
                    httpRes.AddHeader("Access-Control-Allow-Headers", "X-Requested-With, Content-Type, Accept, X-ApiKey");
                    httpRes.EndRequest();
                }

            });
        }
        }
}