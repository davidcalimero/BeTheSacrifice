using UnityEngine;

public class SpawnableGameObjects : MonoBehaviour
{
    public static SpawnableGameObjects Instance;

    //public variables
    public float secondsBetweenSpawning = 3.0f;
    private int weaponNumber = 0;
    float yMinRange = 1;
    float yMaxRange = 1;
    public int maxWpnNumber = 15;

    //area circular variaveis
    public GameObject[] spawnObjects; // what prefabs spawn

    private float nextSpawnTime;
    private Vector3 newposition;

    void Awake()
    {
        //
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
            newposition = Random.insideUnitCircle * 5;
            spawnPosition.x = newposition.x;
            spawnPosition.y = 1;
            spawnPosition.z = newposition.z;

            //determine which object
            int objectToSpawn = Random.Range(0, spawnObjects.Length);
            Debug.Log(objectToSpawn);

            //actually spawn game object
            GameObject var = spawnObjects[objectToSpawn];
            Debug.Log(var);
            Instantiate(var, spawnPosition, new Quaternion());

            //indexar ao Pai
            //spawnedObject.transform.parent = gameObject.transform;

            //My NUMBER IS!!!
            weaponNumber++;
        }
    }

    void RemoveWeapon()
    {
        weaponNumber--;
    }


}

