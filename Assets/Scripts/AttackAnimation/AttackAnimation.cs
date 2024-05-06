using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class AttackAnimation : MonoBehaviour
{

    public GameObject unit;
    public GameObject unitBleu;
    private List<GameObject> list = new List<GameObject>();
    private List<GameObject> listBleu = new List<GameObject>();
    public int hpBleuStart;
    public int hpBleuFin;
    public int hpRedStart;
    public int hpRedFin;
    void Start()
    {

        for (int i = 0; i < hpRedStart; i++)
        {

            if (i < 4)
            {
                list.Add(GameObject.Instantiate(unit, new Vector3(7, i - 2, 0), Quaternion.identity));
            }
            else
            {
                if (i < 7)
                {
                    list.Add(GameObject.Instantiate(unit, new Vector3(5, i - 5.5f, 0), Quaternion.identity));

                }
                else if (i < 9)
                {
                    if (i == 7)
                    {
                        list.Add(GameObject.Instantiate(unit, new Vector3(3, -0.5f, 0), Quaternion.identity));

                    }
                    if (i == 8)
                    {
                        list.Add(GameObject.Instantiate(unit, new Vector3(3, 0.5f, 0), Quaternion.identity));

                    }


                }
                else
                {
                    list.Add(GameObject.Instantiate(unit, new Vector3(1, 0, 0), Quaternion.identity));

                }
            }
        }



        for (int i = 0; i < hpBleuStart; i++)
        {

            Quaternion rotation = Quaternion.AngleAxis(180f, Vector3.up);

            if (i < 4)
            {
                listBleu.Add(GameObject.Instantiate(unitBleu, new Vector3(-7, i - 2, 0), rotation));
            }
            else
            {
                if (i < 7)
                {
                    listBleu.Add(GameObject.Instantiate(unitBleu, new Vector3(-5, i - 5.5f, 0), rotation));

                }
                else if (i < 9)
                {
                    if (i == 7)
                    {
                        listBleu.Add(GameObject.Instantiate(unitBleu, new Vector3(-3, -0.5f, 0), rotation));

                    }
                    if (i == 8)
                    {
                        listBleu.Add(GameObject.Instantiate(unitBleu, new Vector3(-3, 0.5f, 0), rotation));

                    }


                }
                else
                {
                    listBleu.Add(GameObject.Instantiate(unitBleu, new Vector3(-1, 0, 0), rotation));

                }
            }

        }


    }

    void Update ( ) {

        animateAttack();
        animateDefense();
        
    }

    public void animateAttack()
    {

        int i = hpRedStart;

        foreach (GameObject item in list)
        {

            item.transform.position = Vector2.MoveTowards(item.transform.position, new Vector2(0.5f, item.transform.position.y), 0.025f);

            Transform unitRoot = item.transform.Find("UnitRoot");

            if (unitRoot == null)
            {
                unitRoot = item.transform.Find("HorseRoot");
            }

            if (unitRoot != null)
            {
                Animator animator = unitRoot.gameObject.GetComponent<Animator>();
                animator.SetFloat("RunState", 0.5f);

                if ( item.transform.position == new Vector3(0.5f, item.transform.position.y,0) ) {

                if (i > hpRedFin) {
                    animator.SetTrigger("Die");
                    }
                else {
                    animator.SetTrigger("Attack");
                    }                    
                }
            }
            i--;
        }

    }
    public void animateDefense()
    {
        int i = hpBleuStart;
        foreach (GameObject item in listBleu)
        {

            item.transform.position = Vector2.MoveTowards(item.transform.position, new Vector2(-0.5f, item.transform.position.y), 0.025f);

            Transform unitRoot = item.transform.Find("UnitRoot");

            if (unitRoot == null)
            {
                unitRoot = item.transform.Find("HorseRoot");
            }

            if (unitRoot != null)
            {
                Animator animator = unitRoot.gameObject.GetComponent<Animator>();
                animator.SetFloat("RunState", 0.5f);

                if ( item.transform.position == new Vector3(-0.5f, item.transform.position.y,0) ) {
                
                if (i > hpBleuFin) {
                    animator.SetTrigger("Die");
                    }
                else {
                    animator.SetTrigger("Attack");
                    } 
                    
                }
            }
            i--;
        }
    }

    IEnumerator StartCountdown(float hpStart, float hpFin, TMP_Text textCountdown, Image img)
    {
        float timer = hpStart;
        float width = hpStart * 50;
        while (timer >= hpFin)
        {
            textCountdown.text = Mathf.CeilToInt(timer).ToString();
            img.rectTransform.sizeDelta = new Vector2(width, 70);
            yield return new WaitForSeconds(0.5f);
            timer -= 1f;
            width -= 50f;

        }


        // You can add any other actions you want to perform when countdown finishes here
    }
}
