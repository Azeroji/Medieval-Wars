using System.Collections.Generic;
using Unity.VisualScripting;

public class Qg : Batiment
{
    public Qg(Teams team)
    {
        category = "Qg";
        this.team = team;
        defenseBonus = 3;
        isCapturable = true;

        if (team == Teams.Blue)
        {
            terrainType = TerrainType.QgBleu;
        }
        else
        {
            terrainType = TerrainType.QgRouge;
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

            { UnitType.NavireDeTransport, 99},
            { UnitType.Galere, 99},
            { UnitType.Radeau, 99},
        };

        units_produced = [
            UnitType.Eclaireur,
            UnitType.Guerrier,
            UnitType.Infirmier,
        ];
    }

    public void switchTeam ( Teams team ) {
        this.team = team;
        if (team == Teams.Blue)
        {
            terrainType = TerrainType.QgBleu;
        }
        else
        {
            terrainType = TerrainType.QgRouge;
        }
        
    }

}