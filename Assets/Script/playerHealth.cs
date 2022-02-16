
using UnityEngine;

public class playerHealth : MonoBehaviour
{

    public float currentHealth;
    public UnityEngine.Experimental.Rendering.Universal.Light2D playerLight;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3.93f;
        healthBar.setMaxHealth(currentHealth);

    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.H))
        // {
        //     takeDamage(20);
        // }

        healthBar.setHealth(playerLight.pointLightOuterRadius);
        float percentage = ((playerLight.pointLightOuterRadius - 1) / 2.93f) * 100;
        healthBar.changePercentage(percentage);

    }


    // public void takeDamage(double damage)
    // {
    //     currentHealth -= (float)damage;
    //     healthBar.setHealth(currentHealth);
    // }
}
