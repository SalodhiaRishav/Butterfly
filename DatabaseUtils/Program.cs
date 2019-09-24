namespace DatabaseUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            //CaseSeeder caseSeeder = new CaseSeeder();
            //caseSeeder.CreateCases(100);
            DeclarationSeeder declarationSeeder = new DeclarationSeeder();
            declarationSeeder.CreateDeclarations(50);
            System.Console.WriteLine("Data created successfully...");

        }
    }
}
