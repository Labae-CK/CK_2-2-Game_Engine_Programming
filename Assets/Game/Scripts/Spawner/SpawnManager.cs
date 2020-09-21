using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Spawner[] Spawners;
    public List<SpawnEntity> SpawnEntities = new List<SpawnEntity>();
    public List<SpawnEntity> processedSpawnEntity = new List<SpawnEntity>();

    private float _tick = 0.0f;

    private void Start()
    {
        if(Spawners.Length == 0)
        {
            Spawners = FindObjectsOfType<Spawner>();
        }

        if(Spawners.Length == 0)
        {
            Debug.LogWarning("There are no spawner in the game");
        }

        for (int i = 0; i < Spawners.Length; i++)
        {
            Spawners[i].StartSpawner();
        }
    }

    private void Update()
    {
        _tick += Time.deltaTime;

        var nextEntity = GetNextEntity();
        if(nextEntity != null)
        {
            Spawners[nextEntity.SpawnerIndex].AddEntity(nextEntity);
            processedSpawnEntity.Add(nextEntity);
            SpawnEntities.Remove(nextEntity);
        }
    }

    private SpawnEntity GetNextEntity()
    {
        for (int i = 0; i < SpawnEntities.Count; i++)
        {
            if(_tick >= SpawnEntities[i].SpawnTime)
            {
                return SpawnEntities[i];
            }
        }

        return null;
    }
}
