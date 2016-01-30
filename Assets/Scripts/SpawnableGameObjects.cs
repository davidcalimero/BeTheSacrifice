using UnityEngine;

public class SpawnableGameObjects : MonoBehaviour
{
    public static SpawnableGameObjects Instance;

    //public variables
    public float secondsBetweenSpawning = 3.0f;
    private int weaponNumber = 0;
    float yMinRange = 1;
    float yMaxRange = 1;
    float zMinRange = -20;
    float zMaxRange = 20;
    float xMinRange = -20;
    float xMaxRange = 20;
    public int maxWpnNumber = 15;

    //area circular variaveis
    public GameObject[] spawnObjects; // what prefabs spawn

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

    void MakeWeapon()
    {
        Vector3 spawnPosition;

        if (weaponNumber <= maxWpnNumber)
        {
            //random coordinate in a circular area
           
            spawnPosition.x = Random.Range(xMinRange, xMaxRange);
            spawnPosition.y = 1;
            spawnPosition.z = Random.Range(zMinRange, zMaxRange);

            Debug.Log(spawnPosition);
            //determine which object
            if(spawnObjects.Length > 0){
                int objectToSpawn = Random.Range(0, spawnObjects.Length);
                Instantiate(spawnObjects[objectToSpawn], spawnPosition, new Quaternion());
            }

            //My NUMBER IS!!!
            weaponNumber++;
        }
    }

    void RemoveWeapon()
    {
        weaponNumber--;
    }
}