using System.Collections.Generic;
using Unity.VisualScripting;

public class Port : Batiment
{
    public Port(Teams team)
    {
        category = "Port";
        this.team = team;
        defenseBonus = 3;

        if (team == Teams.Blue)
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

        // units produced
        units_produced.Add(UnitType.Galere);
        units_produced.Add(UnitType.NavireDeTransport);
        units_produced.Add(UnitType.Radeau);
    }

    public void switchTeam ( Teams team ) {
        this.team = team;
        if (team == Teams.Blue)
        {
            terrainType = TerrainType.PortBleu;
        }
        else
        {
            terrainType = TerrainType.PortRouge;
        }
        
    }

}