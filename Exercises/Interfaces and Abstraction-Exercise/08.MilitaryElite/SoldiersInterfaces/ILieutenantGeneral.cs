using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public interface ILieutenantGeneral
    {
        public IReadOnlyCollection<Private> Privates { get; }
    }
}
