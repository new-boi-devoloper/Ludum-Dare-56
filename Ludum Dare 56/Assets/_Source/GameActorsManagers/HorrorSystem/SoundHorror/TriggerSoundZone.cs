using System;
using System.Collections;
using System.Collections.Generic;
using _Source.GameActorsManagers.HorrorSystem;
using _Source.GameActorsManagers.HorrorSystem.SoundHorror;
using _Source.Utils;
using UnityEngine;

public class TriggerSoundZone : MonoBehaviour
{
    private HorrorSoundSlot SpawnObject;
    
    private void Start()
    {
        SpawnObject = gameObject.GetComponentInChildren<HorrorSoundSlot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskCheck.ContainsLayer(LayerMask.GetMask("Player"), other.gameObject)) ;
        {
            var horrorSlot = SpawnObject.GetComponent<HorrorSoundSlot>();
            horrorSlot.ActivateHorror();
        }
    }
}
// }    private GameObject SpawnObject;
// private Type _horrorType; // 
//
// private void Start()
// {
//     _horrorType = typeof(HorrorSoundSlot); //выгнести в отельное место (is, as) 
//     SpawnObject = GetComponentInChildren<GameObject>();
// }
//
// private void OnTriggerEnter(Collider other)
// {
//     if (LayerMaskCheck.ContainsLayer(LayerMask.GetMask("Player"), other.gameObject)) ;
//     {
//         var unused = (HorrorSoundSlot)SpawnObject.GetComponent(_horrorType);
//         unused.ActivateHorror();
//     }
// }
