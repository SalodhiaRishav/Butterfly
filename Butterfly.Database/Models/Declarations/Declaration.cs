using System;
using System.Collections.Generic;

namespace Butterfly.Database.Models.Declarations
{
    public class Declaration
    {
        public Guid DeclarationId { get; set; }
        public String ConsigneeName { get; set; }
        public String ConsigneeOrganisationNumber { get; set; }
        public String ConsigneeAddress1 { get; set; }
        public String ConsigneeAddress2 { get; set; }
        public String ConsigneePostalCode { get; set; }
        public String ConsigneeCity { get; set; }
        public String ConsigneeCountry { get; set; }
        public String CustomCreditNumber { get; set; }

        public String DefferedPayment { get; set; }
        public String ConsignorName { get; set; }

        public String ConsignorAddress1 { get; set; }

        public String ConsignorAddress2 { get; set; }

        public String ConsignorPostalCode { get; set; }

        public String ConsignorCity { get; set; }

        public String ConsignorCountry { get; set; }
        public String DeclarantName { get; set; }
        public String DeclarantOrganisationNumber { get; set; }
        public String DeclarantAddress1 { get; set; }
        public String DeclarantAddress2 { get; set; }
        public String DeclarantPostalCode { get; set; }
        public String DeclarantCity { get; set; }
        public String DeclarantCountry { get; set; }
        public String ContactPerson { get; set; }
        public String MessageName { get; set; }
        public String DeclarationType1 { get; set; }
        public String DeclarationType2 { get; set; }
        public String TermsOfDelivery { get; set; }
        public String DeliveryPlace { get; set; }
        public String CountryOfDispatch { get; set; }
        public String NationalityOfTransport { get; set; }
        public String ModeOfTransport { get; set; }
        public String LocationOfGoods { get; set; }
        public String SupervisingCustomOffice { get; set; }
        public String NatureOfTransaction { get; set; }
        public String Freight { get; set; }
        public String Amount { get; set; }
        public String Currency { get; set; }
        public String Rate { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<ReferenceTable> References { get; set; }
    }
}
