using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDto;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
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

        if (result.StatusCode == System.Net.HttpStatusCode.Created) 
        {
            return Created("/", result);
        }

        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update([FromBody] CategoryUpdateRequest categoryUpdateRequest)
    {
        var result = _categoryService.Update(categoryUpdateRequest);
        if(result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        return BadRequest(result);

    }
    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        var result = _categoryService.Delete(id);
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        var result = _categoryService.GetById(id);
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
