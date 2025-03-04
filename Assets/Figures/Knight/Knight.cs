using System.Collections.Generic;
using UnityEngine;

public class Knight : Figure
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override FigureMoves getMoves()
    {
        FigureMoves figureMoves = new FigureMoves(new List<(int X, int Z)> { },
                                                    new List<(int X, int Z)> { });

        int x = _x + 1;
        int z = _z + 2;

        if (z < 8)
        {
            if (x < 8)
                setGMove(figureMoves, x, z);
            x -= 2;
            if (x > -1)
                setGMove(figureMoves, x, z);
        }
        x = _x + 2;
        z = _z + 1;
        if (x < 8)
        {
            if (z < 8)
                setGMove(figureMoves, x, z);
            z -= 2;
            if (z > -1)
                setGMove(figureMoves, x, z);
        }
        x = _x + 1;
        z = _z - 2;
        if (z > -1)
        {
            if (x < 8)
                setGMove(figureMoves, x, z);
            x -= 2;
            if (x > -1)
                setGMove(figureMoves, x, z);
        }
        x = _x - 2;
        z = _z + 1;
        if (x > -1)
        {
            if (z < 8)
                setGMove(figureMoves, x, z);
            z -= 2;
            if (z > -1)
                setGMove(figureMoves, x, z);
        }

        return figureMoves;
    }
    private void setGMove(FigureMoves figureMoves, int x, int z)
    {
        if (_chessboardScript.checkPosition(x, z))
        {
            if (_chessboardScript.checkFigureColor(x, z, Type))
                figureMoves.AttackMoves.Add((x, z));
        }
        else figureMoves.LegalMoves.Add((x, z));
    }
}
