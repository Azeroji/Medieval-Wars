using System.Collections.Generic;

public class Plaine : Terrain
{
    public Plaine()
    {
        terrainType = TerrainType.Plaine;
        defenseBonus = 1;

        movement = new Dictionary<UnitType, int>
        {
            { UnitType.Infantry, 1 },
            { UnitType.Cavalry, 2 },
            { UnitType.Mech, 1 }
        };

        hide = false;
        inc = 1;
    }
}