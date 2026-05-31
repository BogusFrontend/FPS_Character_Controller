using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int coinCount = 10;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float areaSize = 8f;
    [SerializeField] private float spawnHeight = 1f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < coinCount; i++)
        {
            SpawnCoin();

            yield return new WaitForSeconds(spawnInterval);
        }
        
        Debug.Log("Все монеты заспавнены!");
    }

    private void SpawnCoin()
    {
        float x = Random.Range(-areaSize, areaSize);
        float z = Random.Range(-areaSize, areaSize);
        Vector3 position = new Vector3(x, spawnHeight, z);
        
        GameObject coin = Instantiate(coinPrefab, position, Quaternion.identity);
        
        coin.transform.SetParent(transform);
    }
}
