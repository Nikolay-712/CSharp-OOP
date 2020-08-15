using DungeonsAndCodeWizards.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Items.Contracts
{
    public interface IItem
    {
        int Weight { get; }
        void AffectCharacter(Character character);

    }
}
