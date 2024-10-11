using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 1f; // Adjust this for the desired shooting frequency
    private float timeSinceLastShot = 0f;

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        // Check if enough time has passed to shoot again
        if (timeSinceLastShot >= shootInterval)
        {
            Shoot();
            timeSinceLastShot = 0f; // Reset the timer
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the firePoint's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add any necessary force or velocity to the bullet here (e.g., bulletRigidbody.velocity = transform.forward * bulletSpeed;)
    }
}