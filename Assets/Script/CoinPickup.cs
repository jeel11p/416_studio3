using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindFirstObjectByType<GameManager>().AddCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
