using System.Collections.Generic;

public class Cave : Terrain
{
    public Cave()
    {
        terrainType = TerrainType.Cave;
        defenseBonus = 2;
        hide = true;

        movement = new Dictionary<UnitType, int>
        {
            { UnitType.Guerrier, 2},
            { UnitType.Lancier, 1},
            { UnitType.Eclaireur, 2},
            { UnitType.Infirmier, 2},
            { UnitType.Charette, 99},

            { UnitType.Cavalier, 99},
            { UnitType.CavalierRoyal, 99},
            { UnitType.Archer, 1},
            { UnitType.Catapulte, 99},
            { UnitType.Belier, 99},

            { UnitType.NavireDeTransport, 99},
            { UnitType.Galere, 99},
            { UnitType.Radeau, 99},
        };
    }
}