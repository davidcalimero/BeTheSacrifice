using System;
using UnityEngine;


class Crate : MonoBehaviour{

    // Which prefab drops down
    // PELO AMOR DA SANTA NAO METER NADA!!!!!
    public GameObject Item;

    void OnTriggerEnter(Collider col){
        Vector3 position = transform.position;
        position.y += 0.5f;
        Instantiate(Item, position, new Quaternion());
        Destroy(gameObject); 
    }
}
