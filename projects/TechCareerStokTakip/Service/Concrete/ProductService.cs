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

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Response<ProductResponseDto> Add(ProductAddRequest request)
    {
        Product product = ProductAddRequest.ConvertToEntity(request);

        product.Id = new Guid();
        _productRepository.Add(product);

        var data = ProductResponseDto.ConvertToResponse(product);

        return new Response<ProductResponseDto>()
        {
            Data = data,
            Message = "Ürün Eklendi",
            StatusCode = System.Net.HttpStatusCode.Created
        };

    }

    public Response<ProductResponseDto> Delete(Guid id)
    {
      var product = _productRepository.GetById(id); 

        _productRepository.Delete(product);

        var data = ProductResponseDto.ConvertToResponse(product);

        return new Response<ProductResponseDto>()
        {
            Data = data,
            Message= "Ürün Silindi",
            StatusCode = System.Net.HttpStatusCode.OK
        };

    }

    public Response<List<ProductResponseDto>> GetAll()
    {
        var products = _productRepository.GetAll();

        var response = products.Select(x=> ProductResponseDto.ConvertToResponse(x)).ToList();

        return new Response<List<ProductResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };

    }

    public Response<List<ProductResponseDto>> GetAllByPriceRange(decimal min, decimal max)
    {
      var products = _productRepository.GetAll(x=> x.Price<=max && x.Price>=min);
        var response = products.Select(x => ProductResponseDto.ConvertToResponse(x)).ToList();

        return new Response<List<ProductResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };

    }

    public Response<List<ProductDetailDto>> GetAllDetails()
    {
        var details = _productRepository.GetAllProductDetails();

        return new Response<List<ProductDetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<ProductDetailDto>> GetAllDetailsByCategoryId(int categoryId)
    {
        var details = _productRepository.GetDetailsByCategoryId(categoryId);
        return new Response<List<ProductDetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<ProductDetailDto> GetByDetailId(Guid id)
    {
        var detail = _productRepository.GetProductDetail(id);

        return new Response<ProductDetailDto>()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Data = detail,
        };
    }

    public Response<ProductResponseDto> GetById(Guid id)
    {
       var product = _productRepository.GetById(id);
        var response = ProductResponseDto.ConvertToResponse(product);
        return new Response<ProductResponseDto>() {
            Data = response,
            StatusCode= System.Net.HttpStatusCode.OK
        };

    }

    public Response<ProductResponseDto> Update(ProductUpdateRequest request)
    {
        Product product = ProductUpdateRequest.ConvertToEntity(request);
        
        _productRepository.Update(product);

        var response = ProductResponseDto.ConvertToResponse(product);

        return new Response<ProductResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };

    }
}
