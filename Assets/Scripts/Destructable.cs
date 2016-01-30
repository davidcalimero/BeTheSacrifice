using System;
using UnityEngine;
using System.Collections;
    class Destructable : MonoBehaviour{

            void DestroyNow(){

            // destroy the game Object
            Destroy(gameObject);
        
            //Retirar uma arma do contador
            SpawnableGameObjects.Instance.RemoveWeapon();
    }
}
