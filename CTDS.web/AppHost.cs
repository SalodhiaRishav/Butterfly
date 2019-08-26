namespace CTDS.web
{
    using CTDS.web.CaseManagement;
    using CTDS.CaseManagement.Application.Services;
    using CTDS.CaseManagement.Application.Repository;
    using CTDS.Authentication.Application.Repository;
    using CTDS.CaseManagement.Contracts.Interfaces;
    using CTDS.CaseManagement.Application.Mapper;
    using CTDS.CaseManagement.Application.Repository.Interfaces;
    using CTDS.Authentication.Application.Repository.Interfaces;
    using CTDS.CaseManagement.Application.Mapper.MapperInterface;
    using CTDS.Authentication.Contracts.Interfaces;
    using CTDS.Authentication.Application.Services;
    using CTDS.Declarations.Application.Mapper.Interface;
    using CTDS.Declarations.Application.Mapper;
    using CTDS.Declarations.Application.Repository;
    using CTDS.Declarations.Application.Repository.Interface;
    using CTDS.Declarations.Application.Services;

    using Serilog;
    using Funq;
    using ServiceStack;
    using ServiceStack.ServiceInterface.Cors;
    using ServiceStack.Text;
    using ServiceStack.WebHost.Endpoints;
    using CTDS.Declarations.Contracts.Interface;

    public class AppHost : AppHostBase
    {
        public AppHost() : base("CTDS.web", typeof(CaseManagementService).Assembly) { }
        public override void Configure(Container container)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Enrich.FromLogContext()
                .CreateLogger();

            JsConfig.EmitCamelCaseNames = true;

            container.Register<ICaseRepository>(new CaseRepository());
            container.Register<IUserRepository>(new UserRepository());
            container.Register<IUserRoleRepository>(new UserRoleRepository());
            container.Register<ITokenRepository>(new TokenRepository());
            container.Register<IRoleRepository>(new RoleRepository());
            container.Register<ICaseInformationRepository>(new CaseInformationRepository());
            container.Register<ICaseReferenceRepository>(new CaseReferenceRepository());
            container.Register<ICaseStatusRepository>(new CaseStatusRepository());
            container.Register<IClientRepository>(new ClientRepository());
            container.Register<INotesRepository>(new NotesRepository());
            container.Register<IDeclarationDal>(c => 
                new DeclarationDal(
                    c.Resolve<IDatabaseMapper>()
                    )
                );
            container.Register<IDropDownDal>(c => 
                new DropDownDal(
                    c.Resolve<IDatabaseMapper>()
                    )
                );

            container.Register<IClientMapper>(new ClientMapper());
            container.Register<ICaseInformationMapper>(new CaseInformationMapper());
            container.Register<ICaseStatusMapper>(new CaseStatusMapper());
            container.Register<ICaseReferenceMapper>(new CaseReferenceMapper());
            container.Register<INotesMapper>(new NotesMapper());
            container.Register<IDatabaseMapper>(new DatabaseMapper());

            container.Register<IRoleBusinessLogic>(c =>
                new RoleBusinessLogic(
                    c.Resolve<IUserRoleRepository>(),
                    c.Resolve<IRoleRepository>()
                    )
            );

            container.Register<ITokenBusinessLogic>(c =>
                new TokenBusinessLogic(
                    c.Resolve<IRoleBusinessLogic>(),
                    c.Resolve<ITokenRepository>(),
                    c.Resolve<IUserRepository>()
                    )
                );

            container.Register<IUserBusinessLogic>(c =>
                new UserBusinessLogic(
                    c.Resolve<IUserRepository>(),
                    c.Resolve<ITokenBusinessLogic>()
                )
            );

            container.Register<IClientBusinessLogic>(c =>
                new ClientBusinessLogic(
                    c.Resolve<IClientRepository>(),
                    c.Resolve<IClientMapper>()
                    )
            );

            container.Register<ICaseInformationBusinessLogic>(c=>
                new CaseInformationBusinessLogic(
                    c.Resolve<ICaseInformationRepository>(),
                    c.Resolve<ICaseInformationMapper>()
                    )
            );

            container.Register<ICaseStatusBusinessLogic>(c=>
                new CaseStatusBusinessLogic(
                    c.Resolve<ICaseStatusRepository>(),
                    c.Resolve<ICaseStatusMapper>()
                    )
            );

            container.Register<INotesBusinessLogic>(c => 
                new NotesBusinessLogic(
                    c.Resolve<INotesRepository>(),
                    c.Resolve<INotesMapper>()
                    )
                );

            container.Register<ICaseReferenceBusinessLogic>(c => 
                new CaseReferenceBusinessLogic(
                    c.Resolve<ICaseReferenceRepository>(),
                    c.Resolve<ICaseReferenceMapper>()
                    )
                );

            container.Register<ICaseBusinessLogic>(c=>
                new CaseBusinessLogic(
                    c.Resolve<IClientBusinessLogic>(),
                    c.Resolve<ICaseInformationBusinessLogic>(),
                    c.Resolve<ICaseStatusBusinessLogic>(),
                    c.Resolve<INotesBusinessLogic>(),
                    c.Resolve<ICaseReferenceBusinessLogic>(),
                    c.Resolve<ICaseRepository>()
                    )
                );

            container.Register<IDeclarationBll>(c => 
                new DeclarationBll(
                    c.Resolve<IDeclarationDal>()
                    )
                );

            container.Register<IDropDownBll>(c => 
                new DropDownBll(
                    c.Resolve<IDropDownDal>()
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