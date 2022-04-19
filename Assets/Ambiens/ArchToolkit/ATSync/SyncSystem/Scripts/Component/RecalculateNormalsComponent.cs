using UnityEngine;
#if UNITY_EDITOR
using ambiens.avrs.classextensions;
#endif
[ExecuteInEditMode]
public class RecalculateNormalsComponent : MonoBehaviour
{
   
    public float angle;

    public void RecalculateNormals(float _angle=-1)
    {
        if (_angle == -1) _angle = this.angle;
#if UNITY_EDITOR
        this.GetComponent<MeshFilter>().sharedMesh.RecalculateNormalsByAngle(_angle);
#endif

    }

}
