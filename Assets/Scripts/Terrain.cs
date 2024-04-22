using System.Collections.Generic;
using UnityEngine;
public enum UnitType
{
    Archer,
    Belier,
    Catapulte,
    Cavalier,
    CavalierRoyal,
    Charette,
    Eclaireur,
    Galere,
    Guerrier,
    Infirmier,
    Lancier,
    NavireDeTransport,
    Radeau,
}
public enum Team
{
    blue, red
}

public class Unit
{
    public UnitType unitType;

    public Unit(UnitType unitType)
    {
        this.unitType = unitType;
    }
}
public enum TerrainType
{
    Plaine,
    Montagne,
    Foret,
    Cave,
    Marais,
    Ocean,
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
    // public Dictionary<UnitType, int> movement;
    public int defenseBonus;//[0-5] Each type of terrain has a defensive rating ranging from 0 to 5 stars ;

    public bool hide = false;
    public int inc = 0; // increment the vision


    // Add more attributes as needed
    public Terrain(TerrainType terrainType, int defenseBonus)
    {
        this.terrainType = terrainType;
        this.defenseBonus = defenseBonus;
        // Initialize other attributes here if needed
    }
}

// Movement Cost from advance wars wiki : 
// The range in which units can travel may also be affected by terrains. When checking terrains' detail using the L button, several numbers corresponding to each movement type will indicate how much movement points are needed to cross that terrain. 1 means the unit can move over that terrain unrestricted, 2 means that the unit will need to spend 2 movement points to cross that terrain, and 3 means that 3 movement points are needed.

// Only Infantries and Mechs can travel through mountains and rivers, in which the latter unit has unrestricted movement. Air units can travel on all terrains unhindered. Some COs have special abilities or powers to reduce the movement points needed to move across each terrain.