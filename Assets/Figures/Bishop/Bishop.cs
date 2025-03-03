using System.Collections.Generic;
using UnityEngine;

public class Bishop : Figure
{


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

        int i, j;
        i = _x + 1;
        j = _z + 1;

        for (; i < 8 && j < 8; i++, j++)
        {
            if (_chessboardScript.checkPosition(i, j))
            {
                if (_chessboardScript.checkFigureColor(i, j, Type))
                    figureMoves.AttackMoves.Add((i, j));
                i = 8;
            }
            else figureMoves.LegalMoves.Add((i, j));
        }

        i = _x + 1;
        j = _z - 1;

        for (; i < 8 && j > -1; i++, j--)
        {
            if (_chessboardScript.checkPosition(i, j))
            {
                if (_chessboardScript.checkFigureColor(i, j, Type))
                    figureMoves.AttackMoves.Add((i, j));
                i = 8;
            }
            else figureMoves.LegalMoves.Add((i, j));
        }

        i = _x - 1;
        j = _z - 1;

        for (; i > -1 && j > -1; i--, j--)
        {
            if (_chessboardScript.checkPosition(i, j))
            {
                if (_chessboardScript.checkFigureColor(i, j, Type))
                    figureMoves.AttackMoves.Add((i, j));
                i = -1;
            }
            else figureMoves.LegalMoves.Add((i, j));
        }

        i = _x - 1;
        j = _z + 1;

        for (; i > -1 && j < 8; i--, j++)
        {
            if (_chessboardScript.checkPosition(i, j))
            {
                if (_chessboardScript.checkFigureColor(i, j, Type))
                    figureMoves.AttackMoves.Add((i, j));
                i = -1;
            }
            else figureMoves.LegalMoves.Add((i, j));
        }

        return figureMoves;
    }
}
