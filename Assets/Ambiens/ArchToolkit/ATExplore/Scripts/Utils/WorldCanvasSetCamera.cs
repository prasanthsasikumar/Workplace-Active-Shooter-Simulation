using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ambiens.archtoolkit.atexplore.utils{
    public class WorldCanvasSetCamera : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            ArchToolkit.ArchToolkitManager.Instance.OnVisitorCreated+=InitCamera;
        }

        void InitCamera(){
            this.GetComponent<Canvas>().worldCamera=FindObjectOfType<Camera>();
        }
    }
}

