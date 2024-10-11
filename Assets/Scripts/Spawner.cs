using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject redEnemyPrefab;
    public GameObject blueEnemyPrefab;
    public GameObject greenEnemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Randomly choose which enemy type to spawn
            int enemyType = Random.Range(1, 4); // 1 = Red, 2 = Blue, 3 = Green

            GameObject enemyPrefab;

            switch (enemyType)
            {
                case 1:
                    enemyPrefab = redEnemyPrefab;
                    break;
                case 2:
                    enemyPrefab = blueEnemyPrefab;
                    break;
                case 3:
                    enemyPrefab = greenEnemyPrefab;
                    break;
                default:
                    enemyPrefab = redEnemyPrefab; // Default to RedEnemy
                    break;
            }

            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}