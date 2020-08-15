using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public interface IEngineer
    {
       public IReadOnlyCollection<Repairs> Repairs { get; }
    }
}
