using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public interface ICommando
    {
       public IReadOnlyCollection<Missions> Missions { get; }
    }
}
