using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChronoBis : MonoBehaviour
{
    float time;
    public float TimerInterval = 5f;
    float tick;
    public static ChronoBis instance;
    private bool chronoLance = false;
    private int timeDebut;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ChronoBis dans la scène");
            return;
        }
        instance = this;
    }
    public void lanceChrono()
    {
        this.timeDebut = (int)Time.time;
        this.chronoLance = true;
        time = 3;
        tick = TimerInterval;
    }
    // Update is called once per frame
    void Update()
    {
        if (this.chronoLance == true && time >= 0)
        {
            GetComponent<Text>().text = time.ToString();
            time = 30 - (int)Time.time + (int)timeDebut;
            if (time == 0)
            {
                GetComponent<Text>().text = "GAME OVER";
                print("chrono écroulé");
                LightRadius.instance.Die();
            }
        }
    }
}