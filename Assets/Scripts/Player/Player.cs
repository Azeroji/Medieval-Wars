using System.Collections.Generic;

public class Player
{
    // Commanding Officer (CO) of the player
    public CO co;

    // List of units belonging to the player
    public List<Unit> units = new List<Unit>();

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
}
