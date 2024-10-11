using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public string bulletColor;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedEnemy") || other.gameObject.CompareTag("BlueEnemy") || other.gameObject.CompareTag("GreenEnemy"))
        {
            string enemyColor = other.gameObject.tag.Replace("Enemy", "");

            if (bulletColor == enemyColor)
            {
                Destroy(other.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
