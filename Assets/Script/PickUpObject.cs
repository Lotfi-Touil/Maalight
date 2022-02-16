using UnityEngine;
using System.Collections;
public class PickUpObject : MonoBehaviour
{

    public float jumpForce;
    void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string nom = gameObject.name;
        // print(nom.Substring(0, 3).ToString());
        if (nom.Substring(0, 3).ToString() == "vie")
        {
            Destroy(gameObject);
            LightRadius.instance.aggrandirHallo();
        }
        else if (nom.Substring(0, 3).ToString() == "pil")
        {
            Destroy(gameObject);
            Inventory.instance.AddCoins(1);
            PlayerMovement.instance.nbPiles++;
            // print(PlayerMovement.instance.nbPiles);
            if (PlayerMovement.instance.nbPiles == 4)
            {
                ilFautSortir();
            }
        }
        else
        {
            if (PlayerMovement.instance.nbPiles == 4)
            {
                Destroy(gameObject);
                coffreOuvert();
            }
        }
    }

    private void coffreOuvert()
    {

    }
    private void ilFautSortir()
    {
        ChronoBis.instance.lanceChrono();

    }
}
