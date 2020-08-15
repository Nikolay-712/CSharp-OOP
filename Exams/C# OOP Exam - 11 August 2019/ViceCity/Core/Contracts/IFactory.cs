using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Core.Contracts
{
    public interface IFactory
    {
        object Create(params object[] info);
    }
}
