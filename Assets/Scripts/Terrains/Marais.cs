using System.Collections.Generic;

public class Marais : Terrain
{
    public Marais()
    {
        terrainType = TerrainType.Marais;
        defenseBonus = 0;

        movement = new Dictionary<UnitType, int>
        {
            { UnitType.Guerrier, 2},
            { UnitType.Lancier, 2},
            { UnitType.Eclaireur, 1},
            { UnitType.Infirmier, 2},
            { UnitType.Charette, 99},

            { UnitType.Cavalier, 99},
            { UnitType.CavalierRoyal, 99},
            { UnitType.Archer, 2},
            { UnitType.Catapulte, 99},
            { UnitType.Belier, 99},

            { UnitType.NavireDeTransport, 99},
            { UnitType.Galere, 99},
            { UnitType.Radeau, 99},
        };
    }
}