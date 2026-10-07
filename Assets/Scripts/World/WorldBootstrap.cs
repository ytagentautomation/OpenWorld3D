using UnityEngine;

public class WorldBootstrap : MonoBehaviour
{
    void Awake()
    {
        if (FindObjectOfType<CityGenerator>() == null)
            gameObject.AddComponent<CityGenerator>();
    }
}
