using Webshop.Web.Models.Dtos;

namespace Webshop.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true);


    }
}
