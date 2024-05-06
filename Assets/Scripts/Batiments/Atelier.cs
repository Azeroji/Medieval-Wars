using System.Collections.Generic;
using Unity.VisualScripting;

public class Atelier : Batiment
{
    public Atelier(Teams team)
    {
        category = "Atelier";
        this.team = team;
        defenseBonus = 3;

        if (team == Teams.Blue)
        {
            terrainType = TerrainType.AtelierBleu;
        }
        else
        {
            terrainType = TerrainType.AtelierRouge;
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

        units_produced =
        [
            UnitType.Belier,
            UnitType.Catapulte,
            UnitType.Charette
        ];
    }

    public void switchTeam ( Teams team ) {
        this.team = team;
        if (team == Teams.Blue)
        {
            terrainType = TerrainType.AtelierBleu;
        }
        else
        {
            terrainType = TerrainType.AtelierRouge;
        }
    }


}