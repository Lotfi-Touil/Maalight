using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;


public class LightRadius : MonoBehaviour
{
    public float timeStart = 60;
    UnityEngine.Experimental.Rendering.Universal.Light2D playerLight;
    public float decrease;

    public static LightRadius instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        playerLight = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        setDecrease(0.09766666666f);

    }

    void FixedUpdate()
    {
        if (playerLight.pointLightOuterRadius > 1)
        {
            perteVie();
            if (playerLight.pointLightOuterRadius < 2f)
            {
                playerLight.color = Color.red;
            }
        }
        else
        {
            Die();
            return;
        }
    }
    public void Die()
    {
        PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void aggrandirHallo()
    {
        playerLight.pointLightOuterRadius += 0.09766666666f * 5;
        if (playerLight.pointLightOuterRadius > 4)
        {
            playerLight.pointLightOuterRadius = 4;
        }
    }

    public void perteVie()
    {
        playerLight.pointLightOuterRadius -= decrease / 60;
    }

    public void setDecrease(float f)
    {
        decrease = f;
    }
}
