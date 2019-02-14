using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Spawn : MonoBehaviour
{

    public int spawnCount;
    public int spawnSize = 1;
    public GameObject monster;

    [Range(0.00f,1f)]
    public float chanceSecondSpawn;


    void OnEnable()
    {
        EventManager.StartListening("Spawn", spawn);
    }

    void OnDisable()
    {
        EventManager.StopListening("Spawn", spawn);
    }

    void spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float tmp = Random.Range(0.01f, 1f);
            SpawnInstantiate();
            if(tmp < chanceSecondSpawn)
            {
                SpawnInstantiate();
            }
        }
    }

    void SpawnInstantiate()
    {
        Vector2 spawnPosition = GetSpawnPosition();
        Quaternion spawnRotation = new Quaternion();
        spawnRotation.eulerAngles = new Vector2(0.0f, 0.0f);
        if (spawnPosition != Vector2.zero)
        {

            Instantiate(monster, spawnPosition, spawnRotation);
        }
    }

    Vector2 GetSpawnPosition()
    {
        Vector2 spawnPosition = new Vector2();
        float startTime = Time.realtimeSinceStartup;
        bool test = false;
        while (test == false)
        {
            Vector2 spawnPositionRaw = Random.insideUnitCircle * spawnSize;
            spawnPosition = new Vector3(spawnPositionRaw.x, spawnPositionRaw.y);
            test = !Physics.CheckSphere(spawnPosition, 0.75f);
            if (Time.realtimeSinceStartup - startTime > 0.5f)
            {
                return Vector2.zero;
            }
        }
        return spawnPosition;
    }
}