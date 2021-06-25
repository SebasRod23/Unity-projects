using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Sprites;
    public CardController[] Cards;
    public int CardsClicked;
    private int[] indexs=new int[6];
    private int[] states=new int[3];
    void Start()
    {
        //Asigna el valor de los tres pares
        indexs[0] = Random.Range(0, 7);
        indexs[1] = indexs[0];
        indexs[2] = Random.Range(0, 7);
        indexs[3] = indexs[2];
        indexs[4] = Random.Range(0, 7);
        indexs[5] = indexs[4];
        for (int i = 0; i < 6; i++)
        {
            int r = Random.Range(i, 6);
            int t = indexs[r];
            indexs[r] = indexs[i];
            indexs[i] = t;
        }
        for (int i = 0; i < 6; i++)
        {
            Cards[i].Front = Sprites[indexs[i]];
            Cards[i].CardIndex = indexs[i];
        }

    }

    // Update is called once per frame
    void Update()
    {
        List<CardController> CardsSelected = new List<CardController>();
        foreach(CardController card in Cards)
        {
            if (card.isFront&&!card.found) CardsSelected.Add(card);
        }
        //Debug.Log("Cards Selected: "+CardsSelected.Count);
        if (CardsSelected.Count == 2)
        {
            //Checar si son iguales
            if (CardsSelected[0].CardIndex == CardsSelected[1].CardIndex)
            {
                Debug.Log("They match");
                CardsSelected[0].found = true;
                CardsSelected[1].found = true;
            }
            else
            {
                Debug.Log("They do not match");
                foreach (CardController card in Cards)
                {
                    card.isFront = false;
                    card.ShowBack();
                }
            }
        }
    }
}
