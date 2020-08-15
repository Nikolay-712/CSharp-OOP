using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerInfo
{
    public interface ILayout
    {
        string Format { get; }
    }
}
