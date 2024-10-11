using UnityEngine;

public class PrefabDestroyer : MonoBehaviour
{
    [SerializeField] private float minZ = -20.0f;
    [SerializeField] private float maxZ = 20.0f;
    void Update()
    {
        float zPosition = transform.position.z;

        if (zPosition < minZ || zPosition > maxZ)
        {
            Destroy(gameObject);
        }
    }
}
