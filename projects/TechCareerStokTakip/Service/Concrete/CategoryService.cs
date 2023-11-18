using Core.Shared;
using DataAccess.Repositories.Abstracts;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;
using Models.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Response<CategoryResponseDto> Add(CategoryAddRequest categoryAddRequest)
    {
        Category category = categoryAddRequest;

        _categoryRepository.Add(category);

        CategoryResponseDto response = category;


        return new Response<CategoryResponseDto> 
        {
            Data = response,
            Message = "Kategori Eklendi",
            StatusCode = System.Net.HttpStatusCode.Created
        };

    }

    public Response<CategoryResponseDto> Delete(int id)
    {
        Category category = _categoryRepository.GetById(id);
        _categoryRepository.Delete(category);

        CategoryResponseDto responseDto = category;

        return new Response<CategoryResponseDto>
        {
            Data = responseDto,
            Message = "Kategori Silindi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };


    }

    public Response<List<CategoryResponseDto>> GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();

        List<CategoryResponseDto> response = categories.Select(x=> (CategoryResponseDto)x).ToList();

        return new Response<List<CategoryResponseDto>>() 
        {
            Data = response, 
            StatusCode=System.Net.HttpStatusCode.OK
        };
    }

    public Response<CategoryResponseDto> GetById(int id)
    {
        Category? category = _categoryRepository.GetById(id);

        CategoryResponseDto response = category;

        return new Response<CategoryResponseDto> { Data = response,StatusCode = System.Net.HttpStatusCode.OK };
    }

    public Response<CategoryResponseDto> Update(CategoryUpdateRequest categoryUpdateRequest)
    {
        Category category = categoryUpdateRequest;

        _categoryRepository.Update(category);

        CategoryResponseDto categoryResponseDto = category;
        return new Response<CategoryResponseDto> 
        {
            Data = categoryResponseDto,
            Message = "Kategori Güncellendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}
