using EnemyAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StayHere : MonoBehaviour
{
    public GameObject enemy;
    public State state;

    public UnityEvent action;

    void OnTriggerEnter(Collider triggerObject)
    {
        print(triggerObject.name);
        if (triggerObject.name == "LeftUpLeg" || triggerObject.name == "RightUpLeg")
        {
            enemy.GetComponent<StateController>().currentState = state;
            action.Invoke();

        }
    }
}
