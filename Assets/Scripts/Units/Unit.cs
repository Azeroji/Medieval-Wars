using UnityEngine;
using System;
using TMPro;
using System.Collections.Generic;
using System.Collections.Generic;

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

public class Unit
{
    // Variables de base de la classe Unit
    public UnitType unitType;
    public string unitName;
    public string unitDescription;
    public int hp;
    public Dictionary<UnitType, float> baseDamage = new Dictionary<UnitType, float>();
    public int movement;
    public int ammo;
    public int stamina;
    public int staminaPerDay;
    public int range;
    public int vision;
    public int cost;
    public bool canCapture;
    //Position
    public int posx;
    public int posy;
    public bool hasPlayed = false;
    public bool hasMoved = false;

    //Speciales
    public Player owner;
    public Teams team;
    public bool isPower;
    public bool isAlive = true;

    //Gameobject
    public GameObject unitGameObject;
    public GameObject objectInstance;
    public Sprite sprite;


    public static int get_unit_cost(UnitType unit) {
        // Archer
        if (unit == UnitType.Archer)
        {  
            return Archer.cost;     
        }

        // Belier
        else if (unit == UnitType.Belier)
        {
            return Belier.cost;
        }

        // Catapulte
        else if (unit == UnitType.Catapulte)
        {
            return Catapulte.cost;
        }

        // Cavalier
        else if (unit == UnitType.Cavalier)
        {
            return Cavalier.cost;
        }

        // CavalierRoyal
        else if (unit == UnitType.CavalierRoyal)
        {
            return CavalierRoyal.cost;
        }

        // Charette
        else if (unit == UnitType.Charette)
        {
            return Charette.cost;
        }

        // Eclaireur
        else if (unit == UnitType.Eclaireur)
        {
            return Eclaireur.cost;
        }

        // Galere
        else if (unit == UnitType.Galere)
        {
            return Galere.cost;
        }

        // Guerrier
        else if (unit == UnitType.Guerrier)
        {
            return Guerrier.cost;
        }

        // Infirmier
        else if (unit == UnitType.Infirmier)
        {
            return Infirmier.cost;
        }

        // Lancier
        else if (unit == UnitType.Lancier)
        {
            return Lancier.cost;
        }

        // NavireDeTransport
        else if (unit == UnitType.NavireDeTransport)
        {
            return NavireDeTransport.cost;
        }

        // Radeau
        else if (unit == UnitType.Radeau)
        {
            return Radeau.cost;
        }
    }

    public float AttackValue(Unit Defender, int IndividualATK = 100, int UniversalATK = 100)
    {
        float result = this.baseDamage[Defender.unitType] * IndividualATK / 100.0f * UniversalATK / 100.0f;
        return Mathf.Max(result, 0);
    }

    public float DefenseValue(int IndividualDEF = 100, int UniversalDEF = 100)
    {
        float defenseBonus = TilemapGenerator.terrainMap.map[posx, posy].defenseBonus;
        float result = (100 - defenseBonus * hp) / 100.0f * (200 - Mathf.Max(IndividualDEF, 0)) / 100.0f * (200 - Mathf.Max(UniversalDEF, 0)) / 100.0f;
        return Mathf.Max(result, 0);
    }

    public int TotalAttackDamage(Unit Defender)
    {
        float attackValue = this.AttackValue(Defender);
        float defenseValue = Defender.DefenseValue();
        float result = hp * attackValue * defenseValue;
        return Mathf.RoundToInt(Mathf.Max(result, 0));
    }
    public bool IsAttackPossible ( Unit Defender ) {
        float distance = Mathf.Sqrt( Mathf.Pow( ( Defender.posx - posx ) , 2 ) + Mathf.Pow( ( Defender.posy - posy ) , 2 ) );
        if ( Mathf.Ceil(distance) <= range ) {
            return ( true && Defender.isAlive ) ;
        } else {
            return false;
        }
    }

    public void Attack ( Unit Defender ) {

        if ( IsAttackPossible( Defender ) ) {

            Defender.hp = Defender.hp - TotalAttackDamage(Defender);

            if ( Defender.hp <= 0 ) {
                Defender.Die();
            } else if ( Defender.IsAttackPossible(this) ) {
                hp = hp - Defender.TotalAttackDamage(this);
                if ( hp <= 0 ) {
                    Die();
                }
            }


        }

        TextMeshPro textMeshProDEF = Defender.objectInstance.GetComponentInChildren<TextMeshPro>();
        TextMeshPro textMeshProATK = objectInstance.GetComponentInChildren<TextMeshPro>();

        if ( (textMeshProDEF != null) && ( Defender.hp < 10 ) )
        {
            textMeshProDEF.text = ""+Defender.hp;
        }

        if ( (textMeshProATK != null) && ( hp < 10 ) )
        {
            textMeshProATK.text = ""+hp;
        }

    }

    public void Die () {
        isAlive = false;
        SPUM_Prefabs spumScript = objectInstance.GetComponent<SPUM_Prefabs>();
        DestroyObject.Detruire(objectInstance, 0f);
    }

    public void UseStamina ( int s ) {
        stamina = ( ( stamina - s ) < 0 ) ? 0 : stamina - s;
    }

    public void Move(int x, int y)
    {
        
        if ( posx == x && posy == y ) {
            hasMoved = false;
            return;
        }

        hasMoved = true;
        hasPlayed = true;
        posx = x;
        posy = y;
        
    }

    public int Capture ( TilemapGenerator tilemapGenerator ) {

        int xm = TilemapGenerator.terrainMap.map.GetLength(0)/2;
        int ym = TilemapGenerator.terrainMap.map.GetLength(1)/2;

        int capPoints = hp;

        if ( unitType == UnitType.Belier ) {
            capPoints = Mathf.RoundToInt(hp * 1.5f);
        }

        TilemapGenerator.terrainMap.map[posx, posy].capturePoints = ( TilemapGenerator.terrainMap.map[posx, posy].capturePoints - capPoints < 0 ) ? 0 : TilemapGenerator.terrainMap.map[posx, posy].capturePoints - capPoints;

        if ( TilemapGenerator.terrainMap.map[posx, posy].capturePoints == 0 ) {

            Terrain terrain = TilemapGenerator.terrainMap.map[posx, posy];

            if ( terrain.category == "Village" ) {
                ((Village)TilemapGenerator.terrainMap.map[posx, posy]).switchTeam(team);
                TilemapGenerator.terrainMap.map[posx, posy].capturePoints = 20;
            } else if ( terrain.category == "Atelier" ) {
                ((Atelier)TilemapGenerator.terrainMap.map[posx, posy]).switchTeam(team);
                TilemapGenerator.terrainMap.map[posx, posy].capturePoints = 20;
            } else if ( terrain.category == "Baraque" ) {
                ((Baraque)TilemapGenerator.terrainMap.map[posx, posy]).switchTeam(team);
                TilemapGenerator.terrainMap.map[posx, posy].capturePoints = 20;
            } else if ( terrain.category == "Port" ) {
                ((Port)TilemapGenerator.terrainMap.map[posx, posy]).switchTeam(team);
                TilemapGenerator.terrainMap.map[posx, posy].capturePoints = 20;
            } else if ( terrain.category == "Qg" ) {
                return ( team == Teams.Red ? -1 : 1 );
            }


            Vector3Int tilePosition = new Vector3Int(posx-xm, posy-ym, 0);
            tilemapGenerator.tilemap.SetTile(tilePosition, tilemapGenerator.tiles[(int)TilemapGenerator.terrainMap.map[posx, posy].terrainType]);

        }

        return 0;

    }


     public void SpawnUnit(Vector2 position)
    {
        if (unitGameObject != null)
        {
            Quaternion spawnRotation = Quaternion.identity;

            objectInstance = GameObject.Instantiate(unitGameObject, position, spawnRotation);

            Transform unitRoot = objectInstance.transform.Find("UnitRoot");
            Transform horseRoot = objectInstance.transform.Find("HorseRoot");

            if (unitRoot != null)
            {
                unitRoot.Rotate(0, team == Teams.Red ? 180f : 0f, 0);
            }

            if (horseRoot != null)
            {
                horseRoot.Rotate(0, team == Teams.Red ? 180f : 0f, 0);
            }
        }
        else
        {
            Debug.LogError("Prefab is not assigned!");
        }

    }

    public Texture2D LoadTextureFromFile(string path)
    {
        byte[] fileData = System.IO.File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData); // Load image data into the texture
        return texture;
    }

    public Sprite SpriteFromTexture(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    }

}