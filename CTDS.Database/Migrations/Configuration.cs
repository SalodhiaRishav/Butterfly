using CTDS.Database.Models.Common;

namespace CTDS.Database.Migrations
{
    using CTDS.Database.Models.Declarations;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using CTDS.Database.Models.Authentication;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<CTDS.Database.Context.CTDSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CTDS.Database.Context.CTDSContext context)
        {
            List<MasterData> masterDataList = new List<MasterData>();
            masterDataList.Add(new MasterData { Id = new Guid(),Type = "Countries", Key = "FRA", Value = "France" });
            masterDataList.Add(new MasterData { Id = new Guid(),Type = "Countries", Key = "SWE", Value = "Sweden" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "Countries", Key = "IN", Value = "India" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "Countries", Key = "BARCA", Value = "Barcelona" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "TermsOfDelivery", Key = "CFR", Value = "Cost and Freight" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "TermsOfDelivery", Key = "CIF", Value = "Cost, Insuarance and Frieght" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "TermsOfDelivery", Key = "CIP", Value = "Carriage and Insurance paid to" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "ModeOfTransport", Key = "10", Value = "Vessels,Norwegian/foriegn" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "ModeOfTransport", Key = "16", Value = "Car on Vessels" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "LocationOfGoods", Key = "A", Value = "Customs warehouse A" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "LocationOfGoods", Key = "B", Value = "Customs warehouse B" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "SupervisingCustomOfiice", Key = "010160", Value = "Tvinn-Internett" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "NatureOfTransaction", Key = "0", Value = "The item is not to be paid" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "NatureOfTransaction", Key = "1", Value = "Buy At Fixed expense" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "ReferenceType", Key = "325", Value = "Proforma" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "ReferenceType", Key = "380", Value = "Invoice" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "MessageName", Key = "FU", Value = "Standard Declaration" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "MessageName", Key = "MV", Value = "Manual Treatment" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "DeclarationType1", Key = "0", Value = "Import/Export from efta, ec, eea" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "DeclarationType1", Key = "1", Value = "Import export from country not belonging to efta, ec, eea" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "DeclarationType2", Key = "0", Value = "Provisions" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "DeclarationType2", Key = "5", Value = "Temporary Imports" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "DeclarationType2", Key = "4", Value = "Ordinary Imports" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "DefferedPayment", Key = "M", Value = "Monthly" });
            masterDataList.Add(new MasterData { Id = new Guid(), Type = "DefferedPayment", Key = "D", Value = "Daily" });

            foreach (var masterData in masterDataList)
            {
                context.MasterData.AddOrUpdate(item => item.Value, masterData);
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
