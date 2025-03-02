using System;
using UnityEngine;

public class Pawn : Figure
{
    
    private bool _isPawnFirstTurn;

    void Start()
    {

        _isPawnFirstTurn = false;


    }

    void Update()
    {
        
    }
    public override FigureMoves getLegalMoves()
    {
        FigureMoves figureMoves = new FigureMoves();
        figureMoves.AttackMoves = new (int X, int Z)[0];

        if (_z + 1 < 8 && _chessboardScript.getChessboard()[_x, _z + 1].figure == null)
        {
            figureMoves.LegalMoves = new (int X, int Z)[1] { (_x, _z + 1) };
        }
        else figureMoves.LegalMoves = new (int X, int Z)[0];

        return figureMoves;
    }
}
