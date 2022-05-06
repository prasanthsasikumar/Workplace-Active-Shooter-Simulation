using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerMovement : MonoBehaviour
{
    public bool isRecording = false, isPlaying = false, finishedRecording = false;
    public float timeInterval = 0.5f;
    public string movementData, terroristMovementData;
    public GameObject head, terrorist, playbackHead;

    public List<Transform> positions, terroristPositions;
    public List<Vector3> positionsVector, terroristPositionsVector;
    public List<Quaternion> rotationsVector, terroristRotationVector;
    private float lastTimeframe = 0f;
    private bool readRecording = false, coroutineStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Transform>();
        terroristPositions = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRecording && (Time.time - lastTimeframe)>timeInterval)
        {
            positionsVector.Add(head.transform.position);
            rotationsVector.Add(head.transform.rotation);

            terroristPositionsVector.Add(terrorist.transform.position);
            terroristRotationVector.Add(terrorist.transform.rotation);

            lastTimeframe = Time.time;
        }
        if (finishedRecording)
        {
            isRecording = false;
            finishedRecording = false;
            movementData = "";
            terroristMovementData = "";
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

        for (int i = 0; i < terroristPositionsVector.Count; i++)
        {
            terroristMovementData += terroristPositionsVector[i].ToString() + "," + terroristRotationVector[i].ToString() + "|";
        }
        this.GetComponent<CloudSaveScript>().SaveTerroristData();
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
