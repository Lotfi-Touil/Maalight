
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text percentage;
    public Image fill;


    public void changePercentage(float value)
    {
        int val = (int)value;
        if (val <= 100)
        {
            percentage.text = val.ToString() + "%";
        }

    }

    public void setMaxHealth(double health)
    {
        slider.minValue = 0.9984684f;
        slider.maxValue = (float)health;
        slider.value = (float)health;
    }


    public void setHealth(double health)
    {
        slider.value = (float)health;
        if (getHealth() < 2f)
        {
            fill.color = Color.red;
        }
    }

    private int getPercentage()
    {
        return int.Parse(percentage.text);
    }
    public float getHealth()
    {
        return slider.value;
    }


}
