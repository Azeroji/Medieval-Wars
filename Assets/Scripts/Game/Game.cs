using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    // funds par day
    const int FUNDS_PAR_VILLE = 500;
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
        playerRed = new Player(Teams.Red);
        playerBlue = new Player(Teams.Blue);

        playerRed.AddUnit(new Lancier(1,2,Teams.Red));
        playerRed.AddUnit(new Guerrier(1,3,Teams.Red));
        playerRed.AddUnit(new Guerrier(2,3,Teams.Red));
        playerRed.AddUnit(new Cavalier(2,5,Teams.Red));
        playerRed.AddUnit(new Lancier(3,3,Teams.Red));
        playerRed.AddUnit(new Archer(4,3,Teams.Red));
        playerRed.AddUnit(new Eclaireur(4,2,Teams.Red));

        playerBlue.AddUnit(new Lancier(18,2,Teams.Blue));
        playerBlue.AddUnit(new Guerrier(18,3,Teams.Blue));
        playerBlue.AddUnit(new Guerrier(17,3,Teams.Blue));
        playerBlue.AddUnit(new Cavalier(17,5,Teams.Blue));
        playerBlue.AddUnit(new Cavalier(17,0,Teams.Blue));
        playerBlue.AddUnit(new Guerrier(16,3,Teams.Blue));
        playerBlue.AddUnit(new Eclaireur(15,2,Teams.Blue));

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
                    return true && !unit.hasPlayed && unit.isAlive;
                }
            }
            return false;
        } else {
            foreach ( var unit in playerBlue.units ) {
                if ( unit.posx == Mathf.Round(x+9.51f) && unit.posy == Mathf.Round(y+4.58f) ) {
                    return true && !unit.hasPlayed && unit.isAlive;
                }
            }
            return false;
        }
    }

    public bool isEmpty ( int x, int y ) {
        foreach ( var unit in playerRed.units ) {
            if ( unit.posx == x && unit.posy == y  && unit.isAlive) {
                return false;
            }
        }
        foreach ( var unit in playerBlue.units ) {
            if ( unit.posx == x && unit.posy == y  && unit.isAlive) {
                return false;
            }
        }
        return true;
    }

    public bool isEmpty ( int x, int y, Unit currentUnit ) {
        foreach ( var unit in playerRed.units ) {
            if ( unit.posx == x && unit.posy == y && unit != currentUnit && unit.isAlive) {
                return false;
            }
        }
        foreach ( var unit in playerBlue.units ) {
            if ( unit.posx == x && unit.posy == y && unit != currentUnit && unit.isAlive) {
                return false;
            }
        }
        return true;
    }

    public bool isEmptyTurn ( int x, int y ) {
        if ( currentTurn == Teams.Blue ) {
            foreach ( var unit in playerRed.units ) {
                if ( unit.posx == x && unit.posy == y && unit.isAlive) {
                    return false;
                }
            }
            return true;
        } else {
            foreach ( var unit in playerBlue.units ) {
                if ( unit.posx == x && unit.posy == y && unit.isAlive) {
                    return false;
                }
            }
            return true;
        }

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
            playerBlue.funds += playerBlue.villes.Count * FUNDS_PAR_VILLE;
        }
        else {
            currentTurn = Teams.Red;
            playerRed.funds += playerRed.villes.Count * FUNDS_PAR_VILLE;
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

        if ( attacker.range > 1 && attacker.hasMoved ) {
            return units;
        }

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