using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float rotateSpeed = 0.7f;

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
