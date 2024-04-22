using System.Collections.Generic;

public class Cave : Terrain
{
    public static Dictionary<UnitType, int> movement;

    public Cave()
    {
        terrainType = TerrainType.Cave;
        defenseBonus = 2;
        hide = true;

        movement = new Dictionary<UnitType, int>
        {
            { UnitType.Guerrier, 1},
            { UnitType.Lancier, 1},
            { UnitType.Eclaireur, 1},
            { UnitType.Infirmier, 1},
            { UnitType.Charette, 2},

            { UnitType.Cavalier, 2},
            { UnitType.CavalierRoyal, 2},
            { UnitType.Archer, 1},
            { UnitType.Catapulte, 2},
            { UnitType.Belier, 2},

            { UnitType.NavireDeTransport, 99},
            { UnitType.Galere, 99},
            { UnitType.Radeau, 99},
        };
    }
}