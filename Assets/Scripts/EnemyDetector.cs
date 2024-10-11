using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float detectionRange = 10f;
    public Color gizmoColor = Color.red;

    private Transform nearestEnemy;

    void Update()
    {
        FindNearestEnemy();

        if (nearestEnemy != null)
        {
            RotateTowardsEnemy(nearestEnemy);
        }
    }

    void FindNearestEnemy()
    {
        GameObject[] redEnemies = GameObject.FindGameObjectsWithTag("RedEnemy");
        GameObject[] blueEnemies = GameObject.FindGameObjectsWithTag("BlueEnemy");
        GameObject[] greenEnemies = GameObject.FindGameObjectsWithTag("GreenEnemy");

        Transform playerTransform = transform;

        float nearestDistance = detectionRange;
        nearestEnemy = null;

        CheckNearest(redEnemies, playerTransform, ref nearestDistance);
        CheckNearest(blueEnemies, playerTransform, ref nearestDistance);
        CheckNearest(greenEnemies, playerTransform, ref nearestDistance);
    }

    void CheckNearest(GameObject[] enemies, Transform playerTransform, ref float nearestDistance)
    {
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(playerTransform.position, enemy.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }
    }

    void RotateTowardsEnemy(Transform enemy)
    {
        Vector3 direction = enemy.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }
    }

}
