using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 100f; // Adjust the speed as needed

    void Start()
    {
        // Move the bullet forward (in the direction it's facing)
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
    }
}
