using UnityEngine;
using System;

public enum Teams {
    Red,
    Blue
}

public class Unit
{
    // Variables de base de la classe Unit
    public string unitName;
    public string unitDescription;
    public int hp;
    public float baseDamage;
    public int movement;
    public int ammo;
    public int stamina;
    public int staminaPerDay;
    public int range;
    public int vision;
    public int cost;
    //Position
    public int posx;
    public int posy;

    //Speciales
    public Player owner;
    public Teams team;
    public bool isPower;
    public bool isAlive = true;

    //Gameobject
    public GameObject unitGameObject;
    public GameObject objectInstance;

    public float AttackValue ( int IndividualATK = 100 , int UniversalATK = 100 ) {
        return ( this.baseDamage * IndividualATK/100.0f * UniversalATK/100.0f );
    }

    public float DefenseValue ( int IndividualDEF = 100 , int UniversalDEF = 100 ) {
        return ( ( 100 - TilemapGenerator.terrainMap.map[posx,posy].defenseBonus * hp )/100.0f * ( 200 - IndividualDEF )/100.0f * ( 200 - UniversalDEF )/100.0f  );
    }

    public int TotalAttackDamage ( Unit Defender ) {
        return Mathf.RoundToInt( hp * this.AttackValue() * Defender.DefenseValue() );
    }

    public bool IsAttackPossible ( Unit Defender ) {
        float distance = Mathf.Sqrt( Mathf.Pow( ( Defender.posx - posx ) , 2 ) + Mathf.Pow( ( Defender.posy - posy ) , 2 ) );
        if ( Mathf.Floor(distance) <= range ) {
            return ( true && Defender.isAlive ) ;
        } else {
            return false;
        }
    }

    public void Attack ( Unit Defender ) {
        if ( IsAttackPossible( Defender ) ) {
            Defender.hp = Defender.hp - TotalAttackDamage( Defender );
            Debug.Log("Attack damage : "+TotalAttackDamage(Defender));
            if ( Defender.hp <= 0 ) {
                Defender.Die();
            }
        }
    }

    public void Die () {
        isAlive = false;
        SPUM_Prefabs spumScript = objectInstance.GetComponent<SPUM_Prefabs>();
        DestroyObject.Detruire(objectInstance, 3.0f);
    }

    public void SpawnUnit(Vector2 position)
    {
        // Check if the prefab is assigned
        if (unitGameObject != null)
        {
            // Instantiate the prefab at the given position
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
            if ( team == Teams.Red ) {
                spawnRotation = Quaternion.Euler(0, 180, 0);
            }
            objectInstance = GameObject.Instantiate(unitGameObject, position, spawnRotation);
        }
        else
        {
            Debug.LogError("Prefab is not assigned!");
        }
    }

}

public class Player
{
    public string playerName;
    public int playerID;

    public Player(string name, int id)
    {
        this.playerName = name;
        this.playerID = id;
    }
}