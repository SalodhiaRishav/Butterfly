namespace DatabaseUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            //CaseSeeder caseSeeder = new CaseSeeder();
            //caseSeeder.CreateCases(10);
            DeclarationSeeder declarationSeeder = new DeclarationSeeder();
            declarationSeeder.CreateDeclarations(10);
        }
    }
}
