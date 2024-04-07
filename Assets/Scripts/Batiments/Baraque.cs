using System.Collections.Generic;
using Unity.VisualScripting;

public class Barque : Batiment
{
    public Barque(Team team)
    {
        terrainType = TerrainType.BaraqueBleu;
        defenseBonus = 2;
        this.team = team;
        movement = new Dictionary<UnitType, int>
        {
            { UnitType.Infantry, 1 },
            { UnitType.Cavalry, 1 },
            { UnitType.Mech, 1 }
        };

        hide = false;
        inc = 1;
    }
}