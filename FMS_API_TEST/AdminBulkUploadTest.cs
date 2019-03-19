namespace FMS_API_TEST
{
    using Microsoft.AspNetCore.Hosting;
    using NUnit.Framework;
    using System.IO;
    using Utility;
    using FMS_API_BAL;
    using System.Collections.Generic;

    [TestFixture]
    public class AdminBulkUploadTest
    {
        private ProcessExcel _processExcel;
        private AdminUser _adminUser;
        private readonly IHostingEnvironment environment;
        List<AdminUser> listUsers;
        public AdminBulkUploadTest(IHostingEnvironment environment)
        {
            this.environment = environment;
        }
        [SetUp]
        public void SetUp()
        {
            listUsers = new List<AdminUser>();
            this._processExcel = new ProcessExcel();
            //this._adminUser = new AdminUser();
            
            listUsers.Add(new AdminUser() {
                Email = "SureshKumar@cognizant.com",
                FirstName = "Suresh",
                LastName = "Singh",
                MiddleName = "Kumar",
                Password= "123456",
                RoleId = 2,
            });
            listUsers.Add(new AdminUser()
            {
                Email = "AvinashDe@cognizant.com",
                FirstName = "Avinash",
                LastName = null,
                MiddleName = "De",
                Password = "123456",
                RoleId = 3,
            });
        }
        [Test]
        public async void ProcessAdminBulkUpload_returns_AdminUsers()
        {
            var filePath = Path.Combine(environment.WebRootPath, "Bulk_Admin_Upload.xlsx");
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var res = await _processExcel.ProcessAdminBulkUpload(fileStream);
            Assert.That(res, Is.EqualTo(listUsers));
        }
    }
}
