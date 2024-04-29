using UnityEngine;
using System;
using TMPro;

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
    public bool hasPlayed = false;

    //Speciales
    public Player owner;
    public Teams team;
    public bool isPower;
    public bool isAlive = true;

    //Gameobject
    public GameObject unitGameObject;
    public GameObject objectInstance;
    public Sprite sprite;

    public float AttackValue(int IndividualATK = 100, int UniversalATK = 100)
    {
        float result = this.baseDamage * IndividualATK / 100.0f * UniversalATK / 100.0f;
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
        float attackValue = this.AttackValue();
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
            } else {
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

    public void Move(int x, int y)
    {
        hasPlayed = true;
        posx = x;
        posy = y;
        
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