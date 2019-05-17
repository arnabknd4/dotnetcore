namespace Tests
{
    using FMS_API_BAL;
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;
    using Utility;

    [TestFixture]
    public class UtilityTest
    {
        private Email _email;
        [SetUp]
        public void Setup()
        {
            _email = new Email();
        }
        [Category("Email")]
        [Test]
        public void email_PerticipatedSendMail_returns_Bool()
        {
            bool result = false;
            string emailBodyTemplate = string.Empty;
            Task.Run(async () =>
            {
                emailBodyTemplate = await _email.GetEmailTemplate
                            (
                            Constants.PERTICIPATED,
                            DateTime.Now.ToString("dd/MM/yyyy"),
                            "Sample Test Event",
                            "749783"
                            );
            }).GetAwaiter().GetResult();

            EmailConfig config = new EmailConfig()
            {
                Body = emailBodyTemplate.ToString(),
                Subject = "Your feedback is valuable for us",
                TextFormatter = "html",
                ToEmailAddress = "pealibanerjeesona@gmail.com",
                ToName = "Arnab"
            };            
            Task.Run(async () =>
            {
                result = await _email.Send(config);
            }).GetAwaiter().GetResult();
            Assert.That(result, Is.True);
        }
        [Category("Email")]
        [Test]
        public void email_NotPerticipatedSendMail_returns_Bool()
        {
            bool result = false;
            string emailBodyTemplate = string.Empty;
            Task.Run(async () =>
            {
                emailBodyTemplate = await _email.GetEmailTemplate
                            (
                            Constants.NOTPERTICIPATED,
                            DateTime.Now.ToString("dd/MM/yyyy"),
                            "Sample Test Event",
                            "749783"
                            );
            }).GetAwaiter().GetResult();

            EmailConfig config = new EmailConfig()
            {
                Body = emailBodyTemplate.ToString(),
                Subject = "Your feedback is valuable for us",
                TextFormatter = "html",
                ToEmailAddress = "pealibanerjeesona@gmail.com",
                ToName = "Arnab"
            };
            Task.Run(async () =>
            {
                result = await _email.Send(config);
            }).GetAwaiter().GetResult();
            Assert.That(result, Is.True);
        }

        [Category("Email")]
        [Test]
        public void email_UnregisteredSendMail_returns_Bool()
        {
            bool result = false;
            string emailBodyTemplate = string.Empty;
            Task.Run(async () =>
            {
                emailBodyTemplate = await _email.GetEmailTemplate
                            (
                            Constants.UNREGISTERED,
                            DateTime.Now.ToString("dd/MM/yyyy"),
                            "Sample Test Event",
                            "749783"
                            );
            }).GetAwaiter().GetResult();

            EmailConfig config = new EmailConfig()
            {
                Body = emailBodyTemplate.ToString(),
                Subject = "Your feedback is valuable for us",
                TextFormatter = "html",
                ToEmailAddress = "pealibanerjeesona@gmail.com",
                ToName = "Arnab"
            };
            Task.Run(async () =>
            {
                result = await _email.Send(config);
            }).GetAwaiter().GetResult();
            Assert.That(result, Is.True);
        }
    }
}