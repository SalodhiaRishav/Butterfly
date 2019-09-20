namespace DatabaseUtils
{   
    using System;
    using System.Configuration;
   
    using CTDS.CaseManagement.Contracts.Enums;
    using CTDS.Database.Context;
    using CTDS.Database.Models.CaseManagement;

    public class CaseSeeder
    {
        private readonly CTDSContext CTDSContext;
        private readonly Random Random;
        public CaseSeeder()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CTDSContext"].ConnectionString;
            CTDSContext = new CTDSContext(connectionString);
            Random = new Random();
        }

        
        public void CreateCases(int numberOfCasesToSeed)
        {
            for (int index = 0; index < numberOfCasesToSeed; ++index)
            {
                Case @case = new Case();
                Guid gId=Guid.NewGuid();
                @case.Id = gId;
                @case.CreatedOn = CreateRandomDate(3);
                @case.ModifiedOn = CreateRandomDate(3);
                CTDSContext.Case.Add(@case);
                CTDSContext.Client.Add(CreateClient(gId, index));
                CTDSContext.CaseInformation.Add(CreateCaseInformation(gId));
                CTDSContext.CaseStatus.Add(CreateCaseStatus(gId));
                CTDSContext.Notes.Add(CreateNotes(gId));
            }

            CTDSContext.SaveChanges();

            Console.WriteLine("Data Created");
        }

        private Client CreateClient(Guid caseId,int index)
        {
            Client client = new Client();
            client.ClientIdentifier = "Client" + index;
            client.CaseId = caseId;
            int rnd= Random.Next(3);
            client.IdentifierType = (IdentifierType)rnd;
            client.CreatedOn = CreateRandomDate(3);
            client.ModifiedOn = CreateRandomDate(3);
            return client;
        }

        private CaseInformation CreateCaseInformation(Guid caseId)
        {
            CaseInformation caseInformation = new CaseInformation();
            caseInformation.CaseId = caseId;
            int rnd = Random.Next(3);
            caseInformation.Priority = (PriorityType)rnd;
            caseInformation.CreatedOn = CreateRandomDate(3);
            caseInformation.ModifiedOn = CreateRandomDate(3);
            return caseInformation;
        }

        private CaseStatus CreateCaseStatus(Guid caseId)
        {
            CaseStatus caseStatus = new CaseStatus();
            caseStatus.CaseId = caseId;
            int rnd = Random.Next(3);
            caseStatus.Status = (CaseStatusType)rnd;
            caseStatus.CreatedOn = CreateRandomDate(3);
            caseStatus.ModifiedOn = CreateRandomDate(3);
            return caseStatus;
        }

        private Notes CreateNotes(Guid caseId)
        {
            Notes notes = new Notes();
            notes.CaseId = caseId;
            int rnd = Random.Next();
            notes.NotesByCpa = "Notes" + rnd;
            notes.CreatedOn = CreateRandomDate(3);
            notes.ModifiedOn = CreateRandomDate(3);
            return notes;
        }

        private DateTime CreateRandomDate(int yearForRange)
        {
            int range = yearForRange * 365;          
            DateTime randomDate = DateTime.Today.AddDays(-Random.Next(range));
            return randomDate;
        }
    }
}
