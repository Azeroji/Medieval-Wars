using System.Collections.Generic;

public class Cave : Terrain
{
    public Cave()
    {
        terrainType = TerrainType.Cave;
        defenseBonus = 2;

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