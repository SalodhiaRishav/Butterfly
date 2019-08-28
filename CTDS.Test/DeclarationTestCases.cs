
namespace CTDS.Test
{
    using System;
     
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Declarations.Contracts.Interface;
    using CTDS.Web.Declaration;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class DeclarationTestCases
    {
        [Test]
        public void Should_return_success_true()
        {
            //IDeclarationBll declarationBll = new IDeclarationBll();
           var declarationBll = new Mock<IDeclarationBll>();
            AddDeclarationService addDeclaration = new AddDeclarationService(declarationBll.Object);
            
            //arrange
            AddDeclaration newDeclaration = new AddDeclaration();
            var Declaration = new DeclarationDto();
          
           // newDeclaration.Declaration = new Declarations.Contracts.DeclarationDTO.DeclarationDto();
            Declaration.Amount = "1001";
            Declaration.ConsigneePostalCode = "100";
            Declaration.ConsignorPostalCode = "100";
            Declaration.DeclarantPostalCode = "101";
            Declaration.ConsignorCity = "abc";
            Declaration.ConsigneeCity = "abc";
            Declaration.DeclarationId = Guid.NewGuid();
            newDeclaration.Declaration = Declaration;
            newDeclaration.ReferenceData = new ReferenceDto[0];
         
            declarationBll.Setup(d => d.AddDeclaration(newDeclaration.Declaration)).Returns(newDeclaration.Declaration.DeclarationId);
            //act
            var expectedResult = addDeclaration.Post(newDeclaration);

            //assert
            Assert.That(expectedResult.Success, Is.EqualTo(true));
        }
        [Test]
        public void Should_return_success_false()
        {
            var declarationBll = new Mock<IDeclarationBll>();
            AddDeclarationService addDeclaration = new AddDeclarationService(declarationBll.Object);
            //arrange
            AddDeclaration newDeclaration = new AddDeclaration();
            newDeclaration.Declaration = null;
            newDeclaration.ReferenceData = null;
            //act
            var expectedResult = addDeclaration.Post(newDeclaration);
            //assert
            Assert.That(expectedResult.Success, Is.EqualTo(false));
        }
    }
}
