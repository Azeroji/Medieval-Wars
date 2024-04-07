using System.Collections.Generic;
using Unity.VisualScripting;

public class Atelier : Batiment
{
    public Atelier(Team team)
    {
        if (team == Team.blue)
        {
            terrainType = TerrainType.AtelierBleu;
        }
        else
        {
            terrainType = TerrainType.AtelierRouge;
        }
        defenseBonus = 2;
        this.team = team;
        movement = new Dictionary<UnitType, int>
        {
            { UnitType.Infantry, 1 },
            { UnitType.Cavalry, 1 },
            { UnitType.Mech, 1 }
        };

        hide = false;
        inc = 1;
    }
}