using Microsoft.AspNetCore.Http;

namespace UtilityService
{
    public interface IProcessExcel
    {
        string ProcessFile(IFormFile formFile);
    }
}
