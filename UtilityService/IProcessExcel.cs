namespace UtilityService
{
    using FMS_API_BAL;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProcessExcel
    {
        Task<List<User>> ProcessFile(IFormFile formFile);
    }
}
