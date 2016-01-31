using System;
using UnityEngine;


class Crate : MonoBehaviour{

    // Which prefab drops down
    // PELO AMOR DA SANTA NAO METER NADA!!!!!
    public GameObject Item;

    void OnTriggerEnter(Collider col){
        Instantiate(Item, transform.position, new Quaternion());
        Destroy(gameObject); 
    }
}
