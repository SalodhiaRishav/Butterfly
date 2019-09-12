namespace CTDS.Declarations.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;

    [Route("/getalldeclaration","GET")]
    public class GetAllDeclaration
    {
        public int index { get; set; }
        public string orderBy { get; set; }
    }
}
