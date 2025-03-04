using UnityEngine;
using System;
using System.Collections.Generic;

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
    public void setPoolLegal(List<(int X, int Z)> moves, ChessboardScript chessboardScript)
    {
        for (int i = 0; i < moves.Count; i++)
        {
            _pool1[i].SetActive(true);
            (Figure figure, Vector3 position) field = chessboardScript.getChessboard()[moves[i].X, moves[i].Z];
            _pool1[i].transform.position = field.position;
            _pool1[i].GetComponent<HighlighterScript>().X = moves[i].X;
            _pool1[i].GetComponent<HighlighterScript>().Z = moves[i].Z;
        }
    }
    public void setPoolAttack(List<(int X, int Z)> moves, ChessboardScript chessboardScript)
    {
        for (int i = 0; i < moves.Count; i++)
        {
            _pool2[i].SetActive(true);
            (Figure figure, Vector3 position) field = chessboardScript.getChessboard()[moves[i].X, moves[i].Z];
            _pool2[i].transform.position = field.position;
            _pool2[i].GetComponent<HighlighterScript>().X = moves[i].X;
            _pool2[i].GetComponent<HighlighterScript>().Z = moves[i].Z;
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
