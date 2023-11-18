using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDto;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody]CategoryAddRequest categoryAddRequest)
    {
        var result = _categoryService.Add(categoryAddRequest);

        return ActionResultInstance(result);
    }

    [HttpPut]
    public IActionResult Update([FromBody] CategoryUpdateRequest categoryUpdateRequest)
    {
        var result = _categoryService.Update(categoryUpdateRequest);
        return ActionResultInstance(result);

    }
    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        var result = _categoryService.Delete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        var result = _categoryService.GetById(id);
        return ActionResultInstance(result);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return ActionResultInstance(result);
    }
}
