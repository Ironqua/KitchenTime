using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float spawnInterval = 5f;
    [SerializeField] int spawnsPerInterval = 1; 
    float initialDelay = 5f;
    bool spawnStarted = false;

    private void Update()
    {
        if (WorldTİme.currentTime == 11 && !spawnStarted)
        {
            StartCoroutine(SpawnObjectsRepeatedly());
            spawnStarted = true;
        }
    }

    IEnumerator SpawnObjectsRepeatedly()
    {
        yield return new WaitForSeconds(initialDelay); 

        while (true)
        {
            for (int i = 0; i < spawnsPerInterval; i++)
            {
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * 3f;
                Instantiate(prefab, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(0.5f); 
            }
            yield return new WaitForSeconds(spawnInterval); 
        }
    }
}
