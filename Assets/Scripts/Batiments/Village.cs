using System.Collections.Generic;
using Unity.VisualScripting;

public class Village : Batiment
{
    public Village(Team team)
    {
        terrainType = TerrainType.VillageBleu;
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