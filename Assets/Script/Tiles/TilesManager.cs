using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    Transform playerTransform;
    public GameObject[] titlePrefabs;
    public float tileLength = 12f;
    float safeZone = 30f;

    int difficultRange = 0;

    static int difficultLevel = 1;

    float spawnZ = 0f;

    public int amnTilesOnScreen = 3;
    int lastPrefabsIndex = 0;
    List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 3) SpawnTile(0);
            else SpawnTile();
        }
    }


    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }


    private void SpawnTile(int prefabsIndex = -1)
    {
        GameObject go;
        go = prefabsIndex == -1 ?
            Instantiate(titlePrefabs[RandomPrefabIndex()]) as GameObject :
            Instantiate(titlePrefabs[prefabsIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public static void setDifficult(int level)
    {
        difficultLevel = level;
    }

    private int RandomPrefabIndex()
    {
        if (titlePrefabs.Length <= 1)
        {
            return 0;
        }
        else
        {
            int randomIndex = lastPrefabsIndex;

            while (randomIndex == lastPrefabsIndex)
            {
                difficultRange = titlePrefabs.Length > difficultLevel ? difficultLevel : titlePrefabs.Length;
                randomIndex = Random.Range(1, titlePrefabs.Length);
            }

            lastPrefabsIndex = randomIndex;
            return randomIndex;
        }
    }
}
