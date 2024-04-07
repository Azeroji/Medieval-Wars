using System.Collections.Generic;
using Unity.VisualScripting;

public class Port : Batiment
{
    public Port(Team team)
    {
        terrainType = TerrainType.PortBleu;
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