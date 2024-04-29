using UnityEngine;

public class Cavalier : Unit {
    public Cavalier(int x,int y,Teams color)
    {
        unitName = "Cavalier";
        unitDescription = "";
        hp = 10;
        baseDamage = 0.75f;
        movement = 5;
        ammo = 8;
        stamina = 50;
        staminaPerDay = 0;
        range = 1;
        vision = 1;
        cost = 50;
        isPower = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "01":"09" )) ;
        sprite = SpriteFromTexture(LoadTextureFromFile(((color==Teams.Red)? "Assets/UnitsPng/Red/image_2024-03-11_234524013-removebg-preview.png":"Assets/UnitsPng/Blue/Cavalier.png")));
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}