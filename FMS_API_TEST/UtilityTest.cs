namespace Tests
{
    using FMS_API_BAL;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using Utility;

    [TestFixture]
    public class UtilityTest
    {
        private Email email;
        [SetUp]
        public void Setup()
        {
            email = new Email();
        }

        [Test]
        public void email_sendMail_returns_SuccessMessage()
        {
            EmailConfig config = new EmailConfig()
            {
                Body = "Sample Body",
                Subject = " Test Message",
                TextFormatter = "plain",
                ToEmailAddress = "arnabknd4@gmail.com",
                ToName = "Arnab"
            };
            bool result = false;
            Task.Run(async () =>
            {
               result = await email.send(config);
            }).GetAwaiter().GetResult();
            Assert.That(result, Is.True);
        }
    }
}