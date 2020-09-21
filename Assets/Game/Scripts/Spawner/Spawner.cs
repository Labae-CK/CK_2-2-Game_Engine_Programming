using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<SpawnEntity> _spawnEntity = new List<SpawnEntity>();

    public void StartSpawner()
    {
        StartCoroutine(ProcessSpawn());
    }

    public void AddEntity(SpawnEntity entity)
    {
        _spawnEntity.Add(entity);
    }

    private IEnumerator ProcessSpawn()
    {
        while(true)
        {
            if(_spawnEntity.Count > 0)
            {
                SpawnEntity currentSpawnEntity = _spawnEntity[0];
                _spawnEntity.RemoveAt(0);

                for (int i = 0; i < currentSpawnEntity.SpawnData.Amount; i++)
                {
                    Instantiate(currentSpawnEntity.SpawnData.Prefab, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(currentSpawnEntity.SpawnData.Interval);
                }

                currentSpawnEntity.IsSpawnComplete = true;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
}
