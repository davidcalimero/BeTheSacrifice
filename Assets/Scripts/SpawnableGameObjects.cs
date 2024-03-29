﻿using System;
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
    

    //publico a verificar

   
    



    public int maxWpnNumber = 20;

    //prefab
    public GameObject[] spawnableObjects;
    public float[] spawnChance;
    public GameObject cratePrefab;
    public GameObject[] Cratesitems;
    public float[] spawnChanceCrate;

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
        //StartCoroutine(Utils.CreateLoopCoroutine(MakeWeapon, spawningItemDelay));
        
        //determinar o spawn da proxima Crate
        StartCoroutine(Utils.CreateLoopCoroutine(MakeCrate, spawningCrateDelay));


    }
    
    //Spawn Arma
    void MakeWeapon(){
        Vector3 spawnPosition;

        float zMinRange = -3.5f;
        float zMaxRange = 4.5f;
        float xMinRange = -1.0f;
        float xMaxRange = 6.0f;

        if (weaponNumber <= maxWpnNumber)
        {
            //random coordinate in a rectangle
            spawnPosition.x = UnityEngine.Random.Range(xMinRange, xMaxRange);
            spawnPosition.y = 8;
            spawnPosition.z = UnityEngine.Random.Range(zMinRange, zMaxRange);
            float power = UnityEngine.Random.Range(3f, 6.5f);

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

        float zMinRange = -3.7f;
        float zMaxRange = 3.7f;
        float xMinRange = -5;
        float xMaxRange = 5;

        Vector3 spawnPosition;

        if (weaponNumber <= maxWpnNumber)
        {
            //random coordinate in a rectangle
            spawnPosition.x = UnityEngine.Random.Range(xMinRange, xMaxRange);
            spawnPosition.y = 5;
            spawnPosition.z = UnityEngine.Random.Range(zMinRange, zMaxRange);

            //Meter o prefab 
            if (cratePrefab != null && Cratesitems.Length > 0)
            {
                GameObject newCrate = Instantiate(cratePrefab, spawnPosition, new Quaternion()) as GameObject;
                newCrate.GetComponent<Crate>().Item = getRandomItemCrate();
            }
        }
    }

    public GameObject getRandomItem(){
        float num = UnityEngine.Random.value * 100;
        float v = 0;
        for (int i = 0; i < spawnableObjects.Length; i++)
        {
            if (spawnChance[i] + v > num)
                return spawnableObjects[i];
            v += spawnChance[i];
        }
        return null;
    }


    public GameObject getRandomItemCrate()
    {
        float num = UnityEngine.Random.value * 100;
        float v = 0;
        for (int i = 0; i < Cratesitems.Length; i++){
            if (spawnChanceCrate[i] + v > num)
                return Cratesitems[i];
            v += spawnChanceCrate[i];
        }
        return null;
    }

    public void IncrementItem(){
        weaponNumber++;
    }

    public void DecrementItem()
    {
        weaponNumber--;
    }
}