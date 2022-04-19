using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerMovement : MonoBehaviour
{
    public bool isRecording = false, isPlaying = false, finishedRecording = false;
    public float timeInterval = 0.5f;
    public string movementData;
    public GameObject head, playbackHead;

    public List<Transform> positions;
    public List<Vector3> positionsVector;
    public List<Quaternion> rotationsVector;
    private float lastTimeframe = 0f;
    private bool readRecording = false, coroutineStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRecording && (Time.time - lastTimeframe)>timeInterval)
        {
            positionsVector.Add(head.transform.position);
            rotationsVector.Add(head.transform.rotation);
            lastTimeframe = Time.time;
        }
        if (finishedRecording)
        {
            isRecording = false;
            finishedRecording = false;
            movementData = "";
            WirteRecording();
        }
        if (isPlaying)
        {
            if (!readRecording) { readRecording = true; ReadRecording();  }
            if (!coroutineStarted) { StartCoroutine("Playback"); coroutineStarted = true; }
        }
    }

    void WirteRecording()
    {
        for(int i = 0; i < positionsVector.Count; i++)
        {
            movementData += positionsVector[i].ToString() + "," + rotationsVector[i].ToString() + "|";
        }
        this.GetComponent<CloudSaveScript>().SaveUserData();
    }

    void ReadRecording()
    {
        string[] transforms = movementData.Split('|');
        foreach(string transform in transforms)
        {
            string updatedTransform = transform.Replace(")","").Replace("(", "");
            string[] vectors = updatedTransform.Split(',');
            print(vectors.Length);

            GameObject emptyGO = new GameObject();
            Transform newTransform = emptyGO.transform;

            newTransform.SetPositionAndRotation(new Vector3(float.Parse(vectors[0]), float.Parse(vectors[1]), float.Parse(vectors[2])), new Quaternion(float.Parse(vectors[3]), float.Parse(vectors[4]), float.Parse(vectors[5]), float.Parse(vectors[6])));
            positions.Add(newTransform);
        }
    }

    public IEnumerator Playback()
    {
        playbackHead.SetActive(true);
        
        foreach(Transform position in positions)
        {
            playbackHead.transform.SetPositionAndRotation(position.position, position.rotation);
            print("playback");
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
