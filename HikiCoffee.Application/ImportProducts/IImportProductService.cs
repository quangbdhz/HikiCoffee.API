using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.ImportProducts;
using HikiCoffee.ViewModels.ImportProducts.ImportProductDataRequest;

namespace HikiCoffee.Application.ImportProducts
{
    public interface IImportProductService
    {
        Task<List<ImportProductViewModel>> GetAll();

        Task<ApiResult<ImportProductViewModel?>> GetById(int importProductId);

        Task<ApiResult<ImportProductViewModel?>> GetDetailById(int importProductId, int languageId);

        Task<ApiResult<bool>> AddImportProduct(ImportProductCreateRequest request);

    }
}
