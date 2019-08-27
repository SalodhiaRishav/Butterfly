namespace CTDS.Test
{
    using CTDS.Declarations.Application.Services;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.web.Declaration;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DeclarationTestCases
    {
        [Test]
        public void should_return_success_true()
        {
            AddDeclarationService addDeclaration = new AddDeclarationService();
            var declarationBll = new Mock<DeclarationBll>();
            //arrange
            AddDeclaration newDeclaration = new AddDeclaration();
            newDeclaration.Declaration = new Declarations.Contracts.DeclarationDTO.DeclarationDto();
            newDeclaration.Declaration.Amount = "1001";
            newDeclaration.Declaration.ConsigneePostalCode = "100";
            newDeclaration.Declaration.ConsignorPostalCode = "100";
            newDeclaration.Declaration.DeclarantPostalCode = "101";
            newDeclaration.Declaration.ConsignorCity = "abc";
            newDeclaration.Declaration.ConsigneeCity = "abc";
            newDeclaration.Declaration.DeclarationId = Guid.NewGuid();
         //   newDeclaration.ReferenceData = null;
         
            declarationBll.Setup(d => d.AddDeclaration(newDeclaration.Declaration)).Returns(newDeclaration.Declaration.DeclarationId);
            //act
            var expectedResult = addDeclaration.Post(newDeclaration);

            //assert
            Assert.That(expectedResult.Success, Is.EqualTo(true));
            
        }
        [Test]
        public void should_return_success_false()
        {
            AddDeclarationService addDeclaration = new AddDeclarationService();
            var declarationBll = new Mock<DeclarationBll>();
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
