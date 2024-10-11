using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public string enemyColor;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (!target)
        {
            Debug.LogError("No target (player) found!");
            enabled = false;
        }
    }

    void Update()
    {
        if (!target) return;

        Vector3 moveDirection = (target.position - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyColor + "Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
