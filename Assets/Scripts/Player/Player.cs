using System.Collections.Generic;

public class Player
{
    // Commanding Officer (CO) of the player
    public CO co;

    // team
    Teams team;

    // funds
    public int funds = 100;

    // List of units belonging to the player
    public List<Unit> units = new List<Unit>();
    public List<Terrain> villes = new List<Terrain>();

    // builder
    public Player(Teams team)
    {
        this.team = team;
    }

    // Method to add a unit to the player's list of units
    public void AddUnit(Unit unit)
    {
        units.Add(unit);
    }
    // Method to remove a unit from the player's list of units
    public void RemoveUnit(Unit unit)
    {
        units.Remove(unit);
    }

    // Method to add a ville to the player's list of units
    public void AddVille(Terrain batiment)
    {
        villes.Add(batiment);
    }
    // Method to remove a ville from the player's list of units
    public void RemoveVille(Terrain batiment)
    {
        villes.Remove(batiment);
    }
}
