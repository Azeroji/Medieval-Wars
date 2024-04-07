using UnityEngine;

public enum TerrainType {
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
public class Terrain {
    public TerrainType terrainType;
    public int movementCost;
    public int defenseBonus=1;
    // Add more attributes as needed
    public Terrain(TerrainType terrainType, int movementCost, int defenseBonus) {
        this.terrainType = terrainType;
        this.movementCost = movementCost;
        this.defenseBonus = defenseBonus;
        // Initialize other attributes here if needed
    }
}