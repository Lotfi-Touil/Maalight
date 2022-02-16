using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreScript : MonoBehaviour
{

    public SpriteRenderer spriteCoffre1;
    public BoxCollider2D coffre1;
    public SpriteRenderer spriteCoffre2;
    public BoxCollider2D coffre2;
    public SpriteRenderer spriteCoffre3;
    public BoxCollider2D coffre3;

    void Awake()
    {
        //initialisation
        spriteCoffre1.enabled = false;
        spriteCoffre2.enabled = false;
        spriteCoffre3.enabled = false;
        coffre1.enabled = false;
        coffre2.enabled = false;
        coffre3.enabled = false;

        lancement();
    }

    private void lancement()
    {
        int choix = (int)Random.Range(1.0f, 4.0f);
        if (choix == 1)
        {
            coffre1.enabled = true;
            spriteCoffre1.enabled = true;
        }
        else if (choix == 2)
        {
            coffre2.enabled = true;
            spriteCoffre2.enabled = true;
        }
        else
        {
            coffre3.enabled = true;
            spriteCoffre3.enabled = true;
        }
    }
}
