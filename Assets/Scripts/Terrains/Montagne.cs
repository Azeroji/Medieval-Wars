using System.Collections.Generic;

public class Montagne : Terrain
{
    public Montagne()
    {
        terrainType = TerrainType.BaraqueBleu;
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