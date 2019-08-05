namespace Butterfly.web
{
    using Butterfly.web.CaseManagement;
    using Funq;
    using ServiceStack;
    using ServiceStack.ServiceInterface.Cors;
    using ServiceStack.Text;
    using ServiceStack.WebHost.Endpoints;
    using Butterfly.CaseManagement.Application.Services;
    using Butterfly.CaseManagement.Application.Repository;
    using Butterfly.CaseManagement.Contracts.Interfaces;
    using Butterfly.CaseManagement.Application.Mapper;
    using Butterfly.CaseManagement.Application.Repository.Interfaces;
    using Butterfly.CaseManagement.Application.Mapper.MapperInterface;

    public class AppHost : AppHostBase
    {
        public AppHost() : base("Butterfly.web",typeof(CaseManagementService).Assembly) { }
        public override void Configure(Container container)
        {
            
            JsConfig.EmitCamelCaseNames = true;

            container.Register<ICaseRepository>(new CaseRepository());
            container.Register<ICaseInformationRepository>(new CaseInformationRepository());
            container.Register<ICaseReferenceRepository>(new CaseReferenceRepository());
            container.Register<ICaseStatusRepository>(new CaseStatusRepository());
            container.Register<IClientRepository>(new ClientRepository());
            container.Register<INotesRepository>(new NotesRepository());

            container.Register<IClientMapper>(new ClientMapper());
            container.Register<ICaseInformationMapper>(new CaseInformationMapper());
            container.Register<ICaseStatusMapper>(new CaseStatusMapper());
            container.Register<ICaseReferenceMapper>(new CaseReferenceMapper());
            container.Register<INotesMapper>(new NotesMapper());

            container.Register<ICaseBusinessLogic>(new CaseBusinessLogic(
              new CaseRepository(),
              new ClientRepository(),
              new CaseInformationRepository(),
              new CaseStatusRepository(),
              new CaseReferenceRepository(),
              new NotesRepository(),
              new CaseInformationMapper(),
              new CaseStatusMapper(),
              new ClientMapper(),
              new NotesMapper(),
              new CaseReferenceMapper()
              )
              );



            Plugins.Add(new CorsFeature());
            RequestFilters.Add((httpReq, httpRes, requestDto) =>
            {
                if (httpReq.HttpMethod == "OPTIONS")
                {
                    httpRes.AddHeader("Access-Control-Allow-Methods", "POST, GET,DELETE, OPTIONS");
                    httpRes.AddHeader("Access-Control-Allow-Headers", "X-Requested-With, Content-Type, Accept, X-ApiKey");
                    httpRes.EndRequest();
                }
            });
        }


    }
}