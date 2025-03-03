using UnityEngine;
using System;

[Serializable]
public class HighlightersPool
{
    [SerializeField] private GameObject legalHighlighterPrefab;
    [SerializeField] private GameObject attackHighlighterPrefab;

    private GameObject[] _pool1;
    private GameObject[] _pool2;

    public void Initialize()
    {
        _pool1 = new GameObject[30];
        _pool2 = new GameObject[30];

        for (int i = 0; i < 30; i++)
        {
            _pool1[i] = GameObject.Instantiate(legalHighlighterPrefab);
            _pool1[i].SetActive(false);

            _pool2[i] = GameObject.Instantiate(attackHighlighterPrefab);
            _pool2[i].SetActive(false);
        }
    }
    public void setPoolLegal(Vector3[] positions)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            _pool1[i].SetActive(true);
            _pool1[i].transform.position = positions[i];
        }
    }
    public void setPoolAttack(Vector3[] positions)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            _pool2[i].SetActive(true);
            _pool2[i].transform.position = positions[i];
        }
    }
    public void disablePoolLegal()
    {
        for (int i = 0; i < 30; i++)
        {
            if (_pool1[i].active) _pool1[i].SetActive(false);
            else return;
        }
    }
    public void disablePoolAttack()
    {
        for (int i = 0; i < 30; i++)
        {
            if (_pool2[i].active) _pool2[i].SetActive(false);
            else return;
        }
    }


}
