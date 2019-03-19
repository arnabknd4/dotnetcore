namespace Utility
{
    using ExcelDataReader;
    using FMS_API_BAL;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using UtilityService;

    public class ProcessExcel : IProcessExcel
    {
        public async Task<List<User>> ProcessFile(IFormFile formFile)
        {
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var fileStream = formFile.OpenReadStream();
            try
            {
                List<User> listUsers = new List<User>();
                if (formFile.Length > 0)
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                    {
                        reader.Read();
                        do
                        {
                            while (reader.Read())
                            {
                                Int32 roleId = 0;
                                bool isRoleValidated = false;
                                if (reader[5] != DBNull.Value)
                                {
                                    if (reader.GetString(5).ToLower().Equals("pmo"))
                                    {
                                        roleId = UserRoles.PMO;
                                        isRoleValidated = true;
                                    }
                                    else if (reader.GetString(5).ToLower().Equals("poc"))
                                    {
                                        roleId = UserRoles.POC;
                                        isRoleValidated = true;

                                    }
                                }
                                if (isRoleValidated)
                                {
                                    listUsers.Add(new User()
                                    {
                                        FirstName = (reader[0] != DBNull.Value) ? reader.GetString(0) : null,
                                        MiddleName = (reader[1] != DBNull.Value) ? reader.GetString(1) : null,
                                        LastName = (reader[2] != DBNull.Value) ? reader.GetString(2) : null,
                                        Email = (reader[3] != DBNull.Value) ? reader.GetString(3) : null,
                                        Password = (reader[4] != DBNull.Value) ? Convert.ToString(reader.GetValue(4)) : null,
                                        RoleId = roleId
                                    });
                                }

                            }
                        } while (reader.NextResult());
                    }
                }
                return listUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
