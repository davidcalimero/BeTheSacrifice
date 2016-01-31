using System;
using UnityEngine;

public class SpawnableGameObjects : MonoBehaviour{

    public static SpawnableGameObjects Instance;

    //Inicializar variaveis
    public float secondsBetweenSpawning = 3.0f;
    public float secondsBetweenSpawningCrate = 5.0f;

    private int weaponNumber = 0;
    float zMinRange = -20;
    float zMaxRange = 20;
    float xMinRange = -20;
    float xMaxRange = 20;
    public int maxWpnNumber = 15;

    //prefab
    public GameObject[] spawnObjects;
    public GameObject Crate;

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
        StartCoroutine(Utils.CreateLoopCoroutine(MakeWeapon, secondsBetweenSpawning));
        
        //determinar o spawn da proxima Crate
        StartCoroutine(Utils.CreateLoopCoroutine(MakeCrate, secondsBetweenSpawningCrate));
    }

    //update entre frames
    void Update()
    {
        /*  SOMETHING IS MISSING KEEP THIS CODE FOR ENDING OR ELSE MOAR SPAWN
                //sair quando acabar no game manager e o jogo acabar
                if(GameManager.gm){
                    if(GameManager.gm.gameIsOver)
                        return;
                }
        */
    }

    //Spawn Arma
    void MakeWeapon(){
        Vector3 spawnPosition;

        if (weaponNumber <= maxWpnNumber){
            
            //random coordinate in a rectangle
            spawnPosition.x = UnityEngine.Random.Range(xMinRange, xMaxRange);
            spawnPosition.y = 1;
            spawnPosition.z = UnityEngine.Random.Range(zMinRange, zMaxRange);

            Debug.Log(spawnPosition);
            //determine which object
            if(spawnObjects.Length > 0){
                int objectToSpawn = UnityEngine.Random.Range(0, spawnObjects.Length);
                Instantiate(spawnObjects[objectToSpawn], spawnPosition, new Quaternion());
            }

            //My NUMBER IS!!!
            weaponNumber++;
        }
    }


    void MakeCrate()
    {
        // Inicializar variaveis
        Vector3 spawnPosition;
        float zMinRange = -20;
        float zMaxRange = 20;
        float xMinRange = -20;
        float xMaxRange = 20;


        //random coordinate in a rectangle
        spawnPosition.x = UnityEngine.Random.Range(xMinRange, xMaxRange);
        spawnPosition.y = 50;
        spawnPosition.z = UnityEngine.Random.Range(zMinRange, zMaxRange);

        //Meter o prefab 
        if (Crate != null){
        GameObject newCrate = Instantiate(Crate, spawnPosition, transform.rotation) as GameObject;
            newCrate.GetComponent<Crate>().Weapon = getRandomWeapon();
        }
    }

    public GameObject getRandomWeapon(){
        int objectToSpawn = UnityEngine.Random.Range(0, spawnObjects.Length);
        return spawnObjects[objectToSpawn];
    }

    public void RemoveWeapon(){
        weaponNumber--;
    }
    
}