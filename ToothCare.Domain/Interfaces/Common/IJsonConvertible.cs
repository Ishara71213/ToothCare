using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToothCare.Domain.Interfaces.Common
{
    public interface IJsonConvertible<T>
    {
        T FromJson(string json);
    }
}
