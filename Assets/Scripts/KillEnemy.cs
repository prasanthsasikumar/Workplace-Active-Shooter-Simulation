using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillEnemy : MonoBehaviour
{
    public UnityEvent onSucess;
    public bool isActive = false;


    void OnTriggerEnter(Collider triggerObject)
    {
        if (!isActive) return;

        print(triggerObject.name);


        if (triggerObject.name == "GrabVolumeSmall" || triggerObject.name == "GrabVolumeBig")
        {
            onSucess.Invoke();
        }
    }
}
