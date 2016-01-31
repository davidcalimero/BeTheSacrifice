using System;
using UnityEngine;


class Crate : MonoBehaviour{

    // Which prefab drops down
    // PELO AMOR DA SANTA NAO METER NADA!!!!!
    public GameObject Weapon;

    void OnTriggerEnter(Collider Col){

        Instantiate(Weapon, transform.position, new Quaternion());
        Destroy(gameObject);
        
    }
}
