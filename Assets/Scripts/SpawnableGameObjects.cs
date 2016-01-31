using System;
using UnityEngine;

public class SpawnableGameObjects : MonoBehaviour{

    public static SpawnableGameObjects Instance;

    //Inicializar variaveis
    public float spawningItemDelay = 3.0f;
    public float spawningCrateDelay = 5.0f;

    private int weaponNumber = 0;
    float zMinRange = -3.5f;
    float zMaxRange = 5;
    float xMinRange = -1;
    float xMaxRange = 6;
    public int maxWpnNumber = 20;

    //prefab
    public GameObject[] spawnableObjects;
    public GameObject cratePrefab;

    private float nextSpawnTime;
    private Vector3 newposition;

    void Awake()
    {
        Instance = this;
    }

    //Inicialização
    void Start()
    {
        //determinar o spawn do proximo objecto
        StartCoroutine(Utils.CreateLoopCoroutine(MakeWeapon, spawningItemDelay));
        
        //determinar o spawn da proxima Crate
        StartCoroutine(Utils.CreateLoopCoroutine(MakeCrate, spawningCrateDelay));
    }

    //Spawn Arma
    void MakeWeapon(){
        Vector3 spawnPosition;

        if (weaponNumber <= maxWpnNumber)
        {
            //random coordinate in a rectangle
            spawnPosition.x = UnityEngine.Random.Range(xMinRange, xMaxRange);
            spawnPosition.y = 5;
            spawnPosition.z = UnityEngine.Random.Range(zMinRange, zMaxRange);

            //determine which object
            if(spawnableObjects.Length > 0)
            {
                Instantiate(getRandomItem(), spawnPosition, new Quaternion());
            }
        }
    }


    void MakeCrate()
    {
        Vector3 spawnPosition;

        if (weaponNumber <= maxWpnNumber)
        {
            //random coordinate in a rectangle
            spawnPosition.x = UnityEngine.Random.Range(xMinRange, xMaxRange);
            spawnPosition.y = 5;
            spawnPosition.z = UnityEngine.Random.Range(zMinRange, zMaxRange);

            //Meter o prefab 
            if (cratePrefab != null && spawnableObjects.Length > 0)
            {
                GameObject newCrate = Instantiate(cratePrefab, spawnPosition, new Quaternion()) as GameObject;
                newCrate.GetComponent<Crate>().Item = getRandomItem();
            }
        }
    }

    public GameObject getRandomItem(){
        int objectToSpawn = UnityEngine.Random.Range(0, spawnableObjects.Length);
        return spawnableObjects[objectToSpawn];
    }

    public void IncrementItem(){
        weaponNumber++;
    }

    public void DecrementItem()
    {
        weaponNumber--;
    }

}