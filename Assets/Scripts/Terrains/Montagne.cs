using System.Collections.Generic;

public class Montagne : Terrain
{
    public static Dictionary<UnitType, int> movement;

    public Montagne()
    {
        terrainType = TerrainType.BaraqueBleu;
        defenseBonus = 4;
        inc = 2;

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