using UnityEngine;
using System;

[Serializable]
public class HighlightersPool
{
    [SerializeField] private GameObject highlighterPrefab;

    private GameObject[] _pool;

    public void Initialize()
    {
        _pool = new GameObject[30];

        for (int i = 0; i < 30; i++)
        {
            _pool[i] = GameObject.Instantiate(highlighterPrefab);
            _pool[i].SetActive(false);
        }
    }
    public void setPool(Vector3[] positions)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            _pool[i].SetActive(true);
            _pool[i].transform.position = positions[i];
        }
    }
    public void disablePool()
    {
        for (int i = 0; i < 30; i++)
        {
            if (_pool[i].active) _pool[i].SetActive(false);
            else return;
        }
    }

    
}
