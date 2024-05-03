using UnityEngine;
using System.Collections.Generic;

public class Infirmier : Unit {
    public Infirmier(int x,int y,Teams color)
    {
        unitType = UnitType.Infirmier;
        unitName = "Infirmier";
        unitDescription = "";
        hp = 10;
        movement = 3;
        ammo = 0;
        stamina = 80;
        staminaPerDay = 0;
        range = 3;
        vision = 2;
        cost = 50;
        isPower = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "12":"00" )) ;
        sprite = SpriteFromTexture(LoadTextureFromFile(((color==Teams.Red)? "Assets/UnitsPng/Red/image_2024-03-11_233545393-removebg-preview.png":"Assets/UnitsPng/Blue/Infirmier.png")));
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}