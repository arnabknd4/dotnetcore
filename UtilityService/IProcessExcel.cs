namespace UtilityService
{
    using FMS_API_BAL;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.IO;

    public interface IProcessExcel
    {
        Task<List<AdminUser>> ProcessAdminBulkUpload(Stream formFile);
        Task<List<AssosiateFeedbackModel>> ProcessBulkUploadForAssosiates(Stream formFile);
    }
}
