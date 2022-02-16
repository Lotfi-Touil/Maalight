using System.Collections;
using UnityEngine;
using Object = System.Object;

public class LightLife : MonoBehaviour
{
    UnityEngine.Experimental.Rendering.Universal.Light2D lamp;
    // Start is called before the first frame update
    public static LightLife instance;
    public GameObject lampElement;
    public bool lampCheck=false;
    float minIntensity = 0.8f;
    float maxIntensity = 0.3f;
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
        lamp = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        lamp.intensity = Random.Range(minIntensity, maxIntensity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LightRadius.instance.setDecrease(0f);
        StartCoroutine(RemoveAfterSeconds(10f));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        LightRadius.instance.setDecrease(0.09766666666f);
    }
    IEnumerator RemoveAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        lampElement.SetActive(false);
    }
}
