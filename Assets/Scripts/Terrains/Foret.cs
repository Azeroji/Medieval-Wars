using System.Collections.Generic;

public class Foret : Terrain
{
    public Foret()
    {
        terrainType = TerrainType.Foret;
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