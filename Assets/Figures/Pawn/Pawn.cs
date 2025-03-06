using System;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Figure
{
    
    private bool _isPawnFirstTurn;
    private int _zDelta;
    private Predicate<int> _zComparsion;

    void Start()
    {

        _isPawnFirstTurn = true;

    }

    void Update()
    {
        
    }
    public override void Initialize(ChessboardScript chessboardScript, int x, int z, FigureColor type)
    {
        base.Initialize(chessboardScript, x, z, type);

        if (type == FigureColor.WHITE)
        {
            _zDelta = 1;
            _zComparsion = zComparePlus;
        }
        else
        {
            _zDelta = -1;
            _zComparsion = zCompareMinus;
        }
    }
    public override FigureMoves getMoves()
    {
        FigureMoves figureMoves = new FigureMoves(  new List<(int X, int Z)> { },
                                                    new List<(int X, int Z)> { }    );

        int zPlus = _z + _zDelta;
        int xMinus = _x - 1;
        int xPlus = _x + 1;

        if (_zComparsion(zPlus))
        {
            if (!_chessboardScript.checkPosition(_x, zPlus))
                figureMoves.LegalMoves.Add((_x, zPlus));

            if (xMinus > -1 && _chessboardScript.checkPosition(xMinus, zPlus, this.Type))
                figureMoves.AttackMoves.Add((xMinus, zPlus));

            if (xPlus < 8 && _chessboardScript.checkPosition(xPlus, zPlus, this.Type))
                figureMoves.AttackMoves.Add((xPlus, zPlus));

        }
        zPlus += _zDelta;
        if (_isPawnFirstTurn && _zComparsion(zPlus))
            if (    !_chessboardScript.checkPosition(_x, zPlus) &&
                    !_chessboardScript.checkPosition(_x, zPlus + (_zDelta*(-1))))
                figureMoves.LegalMoves.Add((_x, zPlus));

        return figureMoves;
    }
    private bool zComparePlus(int z) => z < 8;
    private bool zCompareMinus(int z) => z > -1;
    public override void move()
    {
        base.move();

        if (_isPawnFirstTurn) _isPawnFirstTurn = false;
    }
}
