using System.Collections.Generic;
using UnityEngine;

public enum TerrainType
{
    Plaine,
    Montagne,
    Foret,
    Cave,
    Marais,
    Ocean,
    OceanCote,
    VillageNeutre,

    QgBleu,
    VillageBleu,
    BaraqueBleu,
    PortBleu,
    AtelierBleu,

    QgRouge,
    VillageRouge,
    BaraqueRouge,
    PortRouge,
    AtelierRouge
}

[System.Serializable]
public class Terrain
{
    public TerrainType terrainType;
    public Dictionary<UnitType, int> movement = new Dictionary<UnitType, int>();
    public int defenseBonus;//[0-5] Each type of terrain has a defensive rating ranging from 0 to 5 stars ;
    public bool isCapturable = false;
    public int capturePoints = 20;
    public Teams team;
    public bool hide = false;
    public string category;
    public int inc = 0; // increment the vision

    public void switchTeam ( Teams team ) {
        this.team = team;
    }

}

// Movement Cost from advance wars wiki : 
// The range in which units can travel may also be affected by terrains. When checking terrains' detail using the L button, several numbers corresponding to each movement type will indicate how much movement points are needed to cross that terrain. 1 means the unit can move over that terrain unrestricted, 2 means that the unit will need to spend 2 movement points to cross that terrain, and 3 means that 3 movement points are needed.

// Only Infantries and Mechs can travel through mountains and rivers, in which the latter unit has unrestricted movement. Air units can travel on all terrains unhindered. Some COs have special abilities or powers to reduce the movement points needed to move across each terrain.