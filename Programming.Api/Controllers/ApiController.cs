using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Programming.Core.Interfaces.Services;

namespace Programming.Api.Controllers
{
    public abstract class ApiController<TCreateDto, TUpdateDto> : ControllerBase
    {
        public abstract Task<IActionResult> Create(TCreateDto data);
        public abstract Task<IActionResult> Get(long id);
        public abstract Task<IActionResult> Edit(long id, TUpdateDto data);
        public abstract Task<IActionResult> Delete(long id);
    }
}
