using System;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Figure
{
    
    private bool _isPawnFirstTurn;

    void Start()
    {

        _isPawnFirstTurn = true;


    }

    void Update()
    {
        
    }
    public override FigureMoves getMoves()
    {
        FigureMoves figureMoves = new FigureMoves(  new List<(int X, int Z)> { },
                                                    new List<(int X, int Z)> { }    );

        int zPlus = _z + 1;
        int xMinus = _x - 1;
        int xPlus = _x + 1;

        if (zPlus < 8)
        {
            if (!_chessboardScript.checkPosition(_x, zPlus))
                figureMoves.LegalMoves.Add((_x, zPlus));

            if (xMinus > -1 && _chessboardScript.checkPosition(xMinus, zPlus, this.Type))
                figureMoves.AttackMoves.Add((xMinus, zPlus));

            if (xPlus < 8 && _chessboardScript.checkPosition(xPlus, zPlus, this.Type))
                figureMoves.AttackMoves.Add((xPlus, zPlus));

        }
        zPlus++;
        if (_isPawnFirstTurn && zPlus < 8)
            if (    !_chessboardScript.checkPosition(_x, zPlus) &&
                    !_chessboardScript.checkPosition(_x, zPlus-1))
                figureMoves.LegalMoves.Add((_x, zPlus));

        return figureMoves;
    }
}
