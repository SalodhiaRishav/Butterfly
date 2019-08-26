namespace CTDS.Database.Migrations
{
    using CTDS.Database.Models.Declarations;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using CTDS.Database.Models.Authentication;

    internal sealed class Configuration : DbMigrationsConfiguration<CTDS.Database.Context.CTDSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CTDS.Database.Context.CTDSContext context)
        {
            List<DropDown> DropDownList = new List<DropDown>();
            DropDownList.Add(new DropDown {Type="Countries",Key="FRA",Value="France" });
            DropDownList.Add(new DropDown { Type = "Countries", Key = "SWE", Value = "Sweden" });
            DropDownList.Add(new DropDown { Type = "Countries", Key = "IN", Value = "India" });
            DropDownList.Add(new DropDown { Type = "Countries", Key = "BARCA", Value = "Barcelona" });
            DropDownList.Add(new DropDown { Type = "TermsOfDelivery", Key = "CFR", Value = "Cost and Freight" });
            DropDownList.Add(new DropDown { Type = "TermsOfDelivery", Key = "CIF", Value = "Cost, Insuarance and Frieght" });
            DropDownList.Add(new DropDown { Type = "TermsOfDelivery", Key = "CIP", Value = "Carriage and Insurance paid to" });
            DropDownList.Add(new DropDown { Type = "ModeOfTransport", Key = "10", Value = "Vessels,Norwegian/foriegn" });
            DropDownList.Add(new DropDown { Type = "ModeOfTransport", Key = "16", Value = "Car on Vessels" });
            DropDownList.Add(new DropDown { Type = "LocationOfGoods", Key = "A", Value = "Customs warehouse A" });
            DropDownList.Add(new DropDown { Type = "LocationOfGoods", Key = "B", Value = "Customs warehouse B" });
            DropDownList.Add(new DropDown { Type = "SupervisingCustomOfiice", Key = "010160", Value = "Tvinn-Internett" });
            DropDownList.Add(new DropDown { Type = "NatureOfTransaction", Key = "0", Value = "The item is not to be paid" });
            DropDownList.Add(new DropDown { Type = "NatureOfTransaction", Key = "1", Value = "Buy At Fixed expense" });
            DropDownList.Add(new DropDown { Type = "ReferenceType", Key = "325", Value = "Proforma" });
            DropDownList.Add(new DropDown { Type = "ReferenceType", Key = "380", Value = "Invoice" });
            DropDownList.Add(new DropDown { Type = "MessageName", Key = "FU", Value = "Standard Declaration" });
            DropDownList.Add(new DropDown { Type = "MessageName", Key = "MV", Value = "Manual Treatment" });
            DropDownList.Add(new DropDown { Type = "DeclarationType1", Key = "0", Value = "Import/Export from efta, ec, eea" });
            DropDownList.Add(new DropDown { Type = "DeclarationType1", Key = "1", Value = "Import export from country not belonging to efta, ec, eea" });
            DropDownList.Add(new DropDown { Type = "DeclarationType2", Key = "0", Value = "Provisions" });
            DropDownList.Add(new DropDown { Type = "DeclarationType2", Key = "5", Value = "Temporary Imports" });
            DropDownList.Add(new DropDown { Type = "DeclarationType2", Key = "4", Value = "Ordinary Imports" });
            DropDownList.Add(new DropDown { Type = "DefferedPayment", Key = "M", Value = "Monthly" });
            DropDownList.Add(new DropDown { Type = "DefferedPayment", Key = "D", Value = "Daily" });

            foreach(var dropDownItem in DropDownList)
            {
                context.DropDown.AddOrUpdate(item=>item.Value,dropDownItem);
                context.SaveChanges();
            }
            Role adminRole = new Role();
            adminRole.RoleName = "Admin";
            context.Role.AddOrUpdate(r => r.RoleName, adminRole);
            context.SaveChanges();
            Role userRole = new Role();
            userRole.RoleName = "User";
            context.Role.AddOrUpdate(r => r.RoleName, userRole);
            context.SaveChanges();

            User user = new User();
            user.Email = "virat@CTDS.com";
            user.Password = "Lkjh";
            context.User.AddOrUpdate(u => u.Email, user);
            context.SaveChanges();

            UserRole viratRole1 = new UserRole();
            viratRole1.RoleId = adminRole.Id;
            viratRole1.UserId = user.Id;
            context.UserRole.AddOrUpdate(viratRole1);
            context.SaveChanges();

            UserRole viratRole2 = new UserRole();
            viratRole2.RoleId = userRole.Id;
            viratRole2.UserId = user.Id;
            context.UserRole.AddOrUpdate(viratRole2);
            context.SaveChanges();



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}