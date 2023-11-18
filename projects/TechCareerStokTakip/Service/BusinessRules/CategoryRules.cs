using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessRules;

public class CategoryRules 
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    public void CategoryNameMustBeUnique(string categoryName)
    {
        var category = _categoryRepository.GetByFilter(x=>x.Name==categoryName);
        if (category != null ) 
        {
            throw new BusinessException("Kategori adı benzersiz olmalı.");
        }

    }


    public void CategoryIsPresent(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category == null ) 
        {
            throw new BusinessException($"Id : {id} olan kategori bulunamadı.");
        }

    }
}
