using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    // Reference to the player representing the Red team
    public Player playerRed;

    // Reference to the player representing the Blue team
    public Player playerBlue;

    public Teams currentTurn = Teams.Red;

    // Current day in the game
    public int currentDay = 1;

    // Map of the game
    public string map;

    public TMP_Text dayC1;
    public TMP_Text dayC2;

    void Start ( ) {
        currentDay = 1;
        playerRed = new Player();
        playerBlue = new Player();

        playerRed.AddUnit(new Guerrier(2,3,Teams.Red));
        playerRed.AddUnit(new Lancier(5,3,Teams.Red));
        playerRed.AddUnit(new Lancier(5,0,Teams.Red));

        playerBlue.AddUnit(new Guerrier(4,5,Teams.Blue));
        playerBlue.AddUnit(new Cavalier(5,2,Teams.Blue));

    }

    void Update ( ) {
        dayC1.text = "DAY "+currentDay;
        dayC2.text = "DAY "+currentDay;
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


    public Unit getUnitAll ( float x, float y ) {
        foreach ( var unit in playerRed.units ) {
            if ( ( unit.posx == Mathf.Round(x+9.51f) ) && ( unit.posy == Mathf.Round(y+4.58f) ) ) {
                return unit;
            }
        }
        foreach ( var unit in playerBlue.units ) {
            if ( ( unit.posx == Mathf.Round(x+9.51f) ) && ( unit.posy == Mathf.Round(y+4.58f) ) ) {
                return unit;
            }
        }
        return null;
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

    public bool isEmptyF ( float x, float y ) {
        foreach ( var unit in playerRed.units ) {
            if ( unit.posx == Mathf.Round(x+9.51f) && unit.posy == Mathf.Round(y+4.58f) ) {
                return false;
            }
        }
        foreach ( var unit in playerBlue.units ) {
            if ( unit.posx == Mathf.Round(x+9.51f) && unit.posy == Mathf.Round(y+4.58f) ) {
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
        foreach ( var unit in playerRed.units ) {
            unit.hasPlayed = false;
        }
        foreach ( var unit in playerBlue.units ) {
            unit.hasPlayed = false;
        }
    }

    public List<Unit> attackableUnits ( Unit attacker ) {

        List<Unit> units = new List<Unit>();

        Player player = attacker.team == Teams.Red ? playerBlue : playerRed;

        foreach ( var unit in player.units ) {
            if ( attacker.IsAttackPossible ( unit ) ) {
                units.Add ( unit );
            }
        }
        return units;
    }

    public bool hasRedWon ( ) {
        foreach ( var unit in playerBlue.units ) {
            if ( unit.isAlive ) {
                return false;
            }
        }
        return true;
    }

    public bool hasBlueWon ( ) {
        foreach ( var unit in playerRed.units ) {
            if ( unit.isAlive ) {
                return false;
            }
        }
        return true;
    }

}