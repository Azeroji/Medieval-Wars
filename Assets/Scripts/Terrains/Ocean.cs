using System.Collections.Generic;

public class Ocean : Terrain
{
    public static Dictionary<UnitType, int> movement;

    public Ocean()
    {
        terrainType = TerrainType.Ocean;
        defenseBonus = 0;

        movement = new Dictionary<UnitType, int>
        {
            { UnitType.Guerrier, 99},
            { UnitType.Lancier, 99},
            { UnitType.Eclaireur, 99},
            { UnitType.Infirmier, 99},
            { UnitType.Charette, 99},

            { UnitType.Cavalier, 99},
            { UnitType.CavalierRoyal, 99},
            { UnitType.Archer, 99},
            { UnitType.Catapulte, 99},
            { UnitType.Belier, 99},

            { UnitType.NavireDeTransport, 1},
            { UnitType.Galere, 1},
            { UnitType.Radeau, 1},
        };
    }
}