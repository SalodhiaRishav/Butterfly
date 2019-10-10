namespace DatabaseUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            //CaseSeeder caseSeeder = new CaseSeeder();
            //caseSeeder.CreateCases(1000);
            DeclarationSeeder declarationSeeder = new DeclarationSeeder();
            declarationSeeder.CreateDeclarations(1000);
            System.Console.WriteLine("Data created successfully...");

        }
    }
}
