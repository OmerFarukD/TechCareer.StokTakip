using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstracts;

namespace Service.BusinessRules;

public class ProductRules
{

    private readonly IProductRepository _productRepository;

    public ProductRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void ProductNameMustBeUnique(string productName)
    {
        var product = _productRepository.GetByFilter(x=>x.Name==productName);
        if (product is not null) 
        {
            throw new BusinessException("Ürün ismi benzersiz olmalı");
        }
    }

    public void ProductIsPresent(Guid id)
    {
        var product = _productRepository.GetById(id);

        if (product is  null) 
        {
            throw new BusinessException($"Id si : {id} olan ürün bulunamadı.");
        }
    }

}
