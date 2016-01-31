using System;
using UnityEngine;


class Crate : MonoBehaviour{

    // Which prefab drops down
    // PELO AMOR DA SANTA NAO METER NADA!!!!!
    public GameObject Item;
    public int fallDamage = 10;

    void OnTriggerEnter(Collider col){

        if (col.gameObject.tag == "Player")
        {
            IPlayer player = col.gameObject.GetComponent<IPlayer>();
            player.ChangeLife(-fallDamage);
            player.Push(Vector3.zero);
        }

        Vector3 position = transform.position;
        position.y += 0.5f;
        Instantiate(Item, position, new Quaternion());
        Destroy(gameObject); 
    }
}
