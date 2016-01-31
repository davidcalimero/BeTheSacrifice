using System;
using UnityEngine;

public class SpawnableGameObjects : MonoBehaviour{

    public static SpawnableGameObjects Instance;

    //Inicializar variaveis
    public float spawningItemDelay = 3.0f;
    public float spawningCrateDelay = 5.0f;
    

    private int weaponNumber = 0;

    /*
    float zMinRange = -3.5f;
    float zMaxRange = 5;
    float xMinRange = -1;
    float xMaxRange = 6;
    */

    //publico a verificar

    float zMinRange = 5f;
    float zMaxRange = 8f;
    float xMinRange = -3;
    float xMaxRange = 9;
    



    public int maxWpnNumber = 20;

    //prefab
    public GameObject[] spawnableObjects;
    public GameObject cratePrefab;
    public GameObject[] Cratesitems;

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
            spawnPosition.y = 8;
            spawnPosition.z = UnityEngine.Random.Range(zMinRange, zMaxRange);
            float power = UnityEngine.Random.Range(2f, 8f);

            //determine which object
            if (spawnableObjects != null && spawnableObjects.Length > 0)
            {
                GameObject newwpn = Instantiate(getRandomItem(), spawnPosition, new Quaternion()) as GameObject;
                newwpn.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-1) * power, ForceMode.Impulse);
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
                newCrate.GetComponent<Crate>().Item = getRandomItemCrate();
            }
        }
    }

    public GameObject getRandomItem(){
        int objectToSpawn = UnityEngine.Random.Range(0, spawnableObjects.Length);
        return spawnableObjects[objectToSpawn];
    }

    public GameObject getRandomItemCrate()
    {
        int objectToSpawn = UnityEngine.Random.Range(0, Cratesitems.Length);
        return Cratesitems[objectToSpawn];
    }

    public void IncrementItem(){
        weaponNumber++;
    }

    public void DecrementItem()
    {
        weaponNumber--;
    }

}