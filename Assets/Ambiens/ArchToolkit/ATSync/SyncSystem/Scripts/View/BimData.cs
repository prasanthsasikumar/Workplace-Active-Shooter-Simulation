using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
[ExecuteInEditMode]
public class BimData : MonoBehaviour
{
    public enum BimDataType
    {
        Object,
        Material
    }
    [SerializeField]
    public BimDataType dataType;

    public Dictionary<string, string> bimDatas = new Dictionary<string, string>();
    public Dictionary<string, bool> bimDataVisibility = new Dictionary<string, bool>();

    public List<string> keys = new List<string>();
    public List<string> values = new List<string>();
    public List<bool> bools = new List<bool>();

    private void Start()
    {
        foreach (var k in bimDatas.Keys.ToList())
        {
            keys.Add(k);
        }

        foreach (var v in bimDatas.Values.ToList())
        {
            values.Add(v);
        }
        this.GetData();
        this.GetBoolDict();
    }
    public string GetParameter(string key)
    {
        return GetData().TryGetValue(key, out var parameter) ? parameter : string.Empty;
    }

    public bool GetParameterVisibility(string key)
    {
        return GetBoolDict().TryGetValue(key, out bool parameter);
    }

    public Dictionary<string, string> GetParameters()
    {
        return GetData();
    }
    public Dictionary<string, string> GetData()
    {
        if (this.bimDatas.Count != this.keys.Count)
        {
            this.bimDatas.Clear();
            for (int i = 0; i < this.keys.Count; i++)
            {
                var key = this.keys[i];
                var value = this.values[i];

                this.bimDatas.Add(key, value);
            }
        }

        return this.bimDatas;
    }

    public Dictionary<string, bool> GetBoolDict()
    {
        if (this.bimDataVisibility.Count != this.keys.Count)
        {
            this.bimDataVisibility.Clear();
            for (int i = 0; i < this.keys.Count; i++)
            {
                var key = this.keys[i];
                //var value = this.bools[i];

                this.bimDataVisibility.Add(key, true);
            }
        }

        return this.bimDataVisibility;
    }


    public void ChangeParameter(string key, string value)
    {
        //if key exists, change old value with new value
        if (GetData().TryGetValue(key, out var parameter))
        {
            GetData()[key] = value;
        }
    }
}
