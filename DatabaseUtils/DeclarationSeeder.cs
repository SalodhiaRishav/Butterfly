namespace DatabaseUtils
{
    using System;
    using System.Configuration;
    using System.Linq;

    using CTDS.Database.Context;
    using CTDS.Database.Models.Declarations;

    public class DeclarationSeeder
    {
        private readonly CTDSContext CTDSContext;
        private readonly Random Random;
        public DeclarationSeeder()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CTDSContext"].ConnectionString;
            CTDSContext = new CTDSContext(connectionString);
            Random = new Random();
        }
        public void CreateDeclarations(int numberOfDeclarations)
        {
            var countries = CTDSContext.MasterData.Where(d => d.Type == "Countries").ToList();
            var termsOfDelivery = CTDSContext.MasterData.Where(d => d.Type == "TermsOfDelivery").ToList();
            var modesOfTransport = CTDSContext.MasterData.Where(d => d.Type == "ModeOfTransport").ToList();
            var locationsOfGoods = CTDSContext.MasterData.Where(d => d.Type == "LocationOfGoods").ToList();
            var naturesOfTransaction = CTDSContext.MasterData.Where(d => d.Type == "NatureOfTransaction").ToList();
            var referenceTypes = CTDSContext.MasterData.Where(d => d.Type == "ReferenceType").ToList();
            var messsageNames = CTDSContext.MasterData.Where(d => d.Type == "MessageName").ToList();
            var declaratationTypes1 = CTDSContext.MasterData.Where(d => d.Type == "DeclarationType1").ToList();
            var declarationTypes2 = CTDSContext.MasterData.Where(d => d.Type == "DeclarationType2").ToList();
            var defferedPayments = CTDSContext.MasterData.Where(d => d.Type == "DefferedPayment").ToList();
            var supervisingCustomOfiice = CTDSContext.MasterData.Where(d => d.Type == "SupervisingCustomOfiice").ToList();

            for (int index = 0; index<numberOfDeclarations;++index)
            {
                int rnd = Random.Next();
                Declaration declaration = new Declaration();

                declaration.MessageName = messsageNames[Random.Next(messsageNames.Count)].Key;
                declaration.DeclarationType1= declaratationTypes1[Random.Next(declaratationTypes1.Count)].Key;
                declaration.DeclarationType2= declarationTypes2[Random.Next(declarationTypes2.Count)].Key;
                declaration.ConsignorName = "ConsignorName" + index;
                declaration.ConsignorAddress1 = "ConsignorAddressOne" + index;
                declaration.ConsignorAddress2 = "ConsignorAddressTwo" + index;
                declaration.ConsignorCity = "ConsignorCity" + index;
                declaration.ConsignorPostalCode = rnd.ToString();
                declaration.ConsignorCountry = countries[Random.Next(countries.Count)].Key;

                declaration.ConsigneeOrganisationNumber = "ConsigneeOrg" + index;
                declaration.ConsigneeName = "ConsigneeName" + index;
                declaration.ConsigneeAddress2 = "ConsigneeAddressTwo" + index;
                declaration.ConsigneeAddress1= "ConsigneeAddressOne" + index;
                declaration.ConsigneePostalCode = rnd.ToString();
                declaration.ConsigneeCity = "ConsigneeCity" + index;
                declaration.ConsigneeCountry= countries[Random.Next(countries.Count)].Key;
                declaration.CustomCreditNumber = rnd.ToString();
                declaration.DefferedPayment = defferedPayments[Random.Next(defferedPayments.Count)].Key;

                declaration.DeclarantOrganisationNumber = "DeclarantOrgNumber" + index;
                declaration.DeclarantName = "DeclarantName" + index;
                declaration.DeclarantAddress2 = "DeclarantAddressTwo" + index;
                declaration.DeclarantAddress1 = "DeclarantAddressOne" + index;
                declaration.DeclarantPostalCode = rnd.ToString();
                declaration.DeclarantCity = "DeclarantCity" + index;
                declaration.DeclarantCountry = countries[Random.Next(countries.Count)].Key;
                declaration.ContactPerson = rnd.ToString();

                declaration.TermsOfDelivery = termsOfDelivery[Random.Next(termsOfDelivery.Count)].Key;
                declaration.DeliveryPlace = "DelPlace" + index;
                declaration.CountryOfDispatch= countries[Random.Next(countries.Count)].Key;
                declaration.NationalityOfTransport= countries[Random.Next(countries.Count)].Key;
                declaration.ModeOfTransport = modesOfTransport[Random.Next(modesOfTransport.Count)].Key;
                declaration.LocationOfGoods = locationsOfGoods[Random.Next(locationsOfGoods.Count)].Key;
                declaration.SupervisingCustomOffice = supervisingCustomOfiice[Random.Next(supervisingCustomOfiice.Count)].Key;

                declaration.Freight = "Freight";
                declaration.Amount = rnd.ToString();
                declaration.Currency = Random.Next(1, 4).ToString();
                declaration.Rate = Random.Next().ToString();
                declaration.CreatedOn = CreateRandomDate(1);

                //declaration.
                CTDSContext.Declaration.Add(declaration);
            }
            CTDSContext.SaveChanges();

        }

        private DateTime CreateRandomDate(int yearForRange)
        {
            int range = yearForRange * 60;
            DateTime randomDate = DateTime.Today.AddDays(-Random.Next(range));
            return randomDate;
        }
    }

   
}
