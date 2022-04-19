using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscapeSucess : MonoBehaviour
{
    public UnityEvent onSucess;

    void OnTriggerEnter(Collider triggerObject)
    {
        print(triggerObject.name);
        if (triggerObject.name == "GrabVolumeSmall" || triggerObject.name == "GrabVolumeBig")
        {
            onSucess.Invoke();
        }
    }
}
