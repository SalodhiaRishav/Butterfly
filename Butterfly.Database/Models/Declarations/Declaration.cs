﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Database.Models.Declarations
{
    public class Declaration
    {
        public int DeclarationId { get; set; }
        public String ConsigneeName { get; set; }
        public String ConsigneeOrganisationNumber { get; set; }
        public String ConsigneeAddress1 { get; set; }
        public String ConsigneeAddress2 { get; set; }
        public String ConsigneePostalCode { get; set; }
        public String ConsigneeCity { get; set; }
        public int ConsigneeCountry { get; set; }
        public String CustomCreditNumber { get; set; }

        public int DefferedPayment { get; set; }
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
        public int DeclarantCountry { get; set; }
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
        public String Reference { get; set; }
        public DateTime InvoiceDate { get; set; }
        public String Type { get; set; }
        public String Freight { get; set; }
        public String Amount { get; set; }
        public String Currency { get; set; }
        public String Rate { get; set; }
    }
}