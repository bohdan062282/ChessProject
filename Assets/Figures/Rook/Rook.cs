using System.Collections.Generic;
using UnityEngine;

public class Rook : Figure
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public override FigureMoves getMoves()
    {
        FigureMoves figureMoves = new FigureMoves(new List<(int X, int Z)> { },
                                                    new List<(int X, int Z)> { });

        for (int i = _z + 1; i < 8; i++)
        {
            if (_chessboardScript.checkPosition(_x, i))
            {
                if (_chessboardScript.checkFigureColor(_x, i, Type))
                    figureMoves.AttackMoves.Add((_x, i));
                i = 8;
            }
            else figureMoves.LegalMoves.Add((_x, i));
        }
        for (int i = _z - 1; i > -1; i--)
        {
            if (_chessboardScript.checkPosition(_x, i))
            {
                if (_chessboardScript.checkFigureColor(_x, i, Type))
                    figureMoves.AttackMoves.Add((_x, i));
                i = -1;
            }
            else figureMoves.LegalMoves.Add((_x, i));
        }
        for (int i = _x + 1; i < 8; i++)
        {
            if (_chessboardScript.checkPosition(i, _z))
            {
                if (_chessboardScript.checkFigureColor(i, _z, Type))
                    figureMoves.AttackMoves.Add((i, _z));
                i = 8;
            }
            else figureMoves.LegalMoves.Add((i, _z));
        }
        for (int i = _x - 1; i > -1; i--)
        {
            if (_chessboardScript.checkPosition(i, _z))
            {
                if (_chessboardScript.checkFigureColor(i, _z, Type))
                    figureMoves.AttackMoves.Add((i, _z));
                i = -1;
            }
            else figureMoves.LegalMoves.Add((i, _z));
        }

        return figureMoves;
    }
}
