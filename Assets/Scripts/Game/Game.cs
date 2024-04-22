using UnityEngine;

public class Game : MonoBehaviour
{
    // Reference to the player representing the Red team
    public Player playerRed;

    // Reference to the player representing the Blue team
    public Player playerBlue;

    public Teams currentTurn = Teams.Red;

    // Current day in the game
    public int currentDay = 0;

    // Map of the game
    public string map;


    void Start ( ) {
        playerRed = new Player();
        playerBlue = new Player();

        playerRed.AddUnit(new Guerrier(1,3,Teams.Red));
        playerRed.AddUnit(new Lancier(2,4,Teams.Red));
        playerRed.AddUnit(new Lancier(5,0,Teams.Red));

        playerBlue.AddUnit(new Guerrier(4,5,Teams.Blue));
        playerBlue.AddUnit(new Cavalier(5,2,Teams.Blue));

    }


    public Unit getUnit ( float x, float y ) {
        if ( currentTurn == Teams.Red ) {
            foreach ( var unit in playerRed.units ) {
                if ( ( unit.posx == Mathf.Round(x+9.51f) ) && ( unit.posy == Mathf.Round(y+4.58f) ) ) {
                    return unit;
                }
            }
            return null;
        } else {
            foreach ( var unit in playerBlue.units ) {
                if ( ( unit.posx == Mathf.Round(x+9.51f) ) && ( unit.posy == Mathf.Round(y+4.58f) ) ) {
                    return unit;
                }
            }
            return null;
        }
    }

    public bool canGetUnit ( float x, float y ) {
        if ( currentTurn == Teams.Red ) {
            foreach ( var unit in playerRed.units ) {
                if ( unit.posx == Mathf.Round(x+9.51f) && unit.posy == Mathf.Round(y+4.58f) ) {
                    return true && !unit.hasPlayed;
                }
            }
            return false;
        } else {
            foreach ( var unit in playerBlue.units ) {
                if ( unit.posx == Mathf.Round(x+9.51f) && unit.posy == Mathf.Round(y+4.58f) ) {
                    return true && !unit.hasPlayed;
                }
            }
            return false;
        }
    }

    public bool isEmpty ( int x, int y ) {
        foreach ( var unit in playerRed.units ) {
            if ( unit.posx == x && unit.posy == y ) {
                return false;
            }
        }
        foreach ( var unit in playerBlue.units ) {
            if ( unit.posx == x && unit.posy == y ) {
                return false;
            }
        }
        return true;
    }

    public void endTurn () {
        if ( currentTurn == Teams.Red ) {
            currentTurn = Teams.Blue;
        } else {
            currentTurn = Teams.Red;
            currentDay++;
        }
    }

}