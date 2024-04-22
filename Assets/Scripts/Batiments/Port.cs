using System.Collections.Generic;
using Unity.VisualScripting;

public class Port : Batiment
{
    public Port(Team team)
    {
        this.team = team;
        defenseBonus = 3;

        if (team == Team.blue)
        {
            terrainType = TerrainType.PortBleu;
        }
        else
        {
            terrainType = TerrainType.PortRouge;
        }
        
        movement = new Dictionary<UnitType, int>
        {
            { UnitType.Guerrier, 1},
            { UnitType.Lancier, 1},
            { UnitType.Eclaireur, 1},
            { UnitType.Infirmier, 1},
            { UnitType.Charette, 1},

            { UnitType.Cavalier, 1},
            { UnitType.CavalierRoyal, 1},
            { UnitType.Archer, 1},
            { UnitType.Catapulte, 1},
            { UnitType.Belier, 1},

            { UnitType.NavireDeTransport, 1},
            { UnitType.Galere, 1},
            { UnitType.Radeau, 1},
        };
    }
}