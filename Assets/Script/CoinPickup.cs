using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindFirstObjectByType<GameManager>().AddCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
