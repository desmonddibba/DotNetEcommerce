using Microsoft.AspNetCore.Mvc;
using Webshop.Web.Dtos;

namespace Webshop.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
            
    }
}
