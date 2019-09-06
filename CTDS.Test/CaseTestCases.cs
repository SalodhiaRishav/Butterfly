namespace CTDS.Test
{
    using CTDS.Web.CaseManagement;
    using CTDS.CaseManagement.Contracts.Interfaces;

    using Moq;
    using NUnit.Framework;
    using CTDS.CaseManagement.Contracts.EndPoints;
    using System.Collections.Generic;

    [TestFixture]
    public class CaseTestCases
    {
        [Test]
        public void Should_return_message_invalidClientData_when_clientData_empty()
        {

        }

        [Test]
        public void TestCaseCountAPI()
        {
            var caseBusinessLogic = new Mock<ICaseBusinessLogic>();
            CaseManagementService caseManagement = new CaseManagementService(caseBusinessLogic.Object);

            GetCaseCount getCaseCount = new GetCaseCount();

            int count = 1;
            caseBusinessLogic.Setup(c => c.GetCaseCount()).Returns(count);

            var expectedResult = caseManagement.Get(getCaseCount);

            Assert.That(expectedResult.Success, Is.EqualTo(true));
        }

        [Test]
        public void TestFilteredCaseCountAPI()
        {
            var caseBusinessLogic = new Mock<ICaseBusinessLogic>();
            CaseManagementService caseManagement = new CaseManagementService(caseBusinessLogic.Object);

            GetFilteredCaseCount getFilteredCaseCount = new GetFilteredCaseCount();

            Dictionary<string, int> temp = new Dictionary<string, int>();
            temp = null;

            caseBusinessLogic.Setup(c => c.GetFilteredCaseCount()).Returns(temp);

            var expectedResult = caseManagement.Get(getFilteredCaseCount);

            Assert.That(expectedResult.Success, Is.EqualTo(true));
        }
    }
}
