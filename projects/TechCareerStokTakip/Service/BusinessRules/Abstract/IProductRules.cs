using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessRules.Abstract;
public interface IProductRules
{

    void ProductNameMustBeUnique(string productName);
    void ProductIsPresent(Guid id);
}
