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

        if (_chessboardScript.checkPosition(_x+1, _z+2))
            if(_chessboardScript.checkFigureColor(_x+1, _z+2, Type))
                figureMoves.AttackMoves.Add((_x+1, _z+2));
        else figureMoves.LegalMoves.Add((_x+1, _z+2));

        if (_chessboardScript.checkPosition(_x + 2, _z - 1))
            if (_chessboardScript.checkFigureColor(_x + 2, _z - 1, Type))
                figureMoves.AttackMoves.Add((_x + 2, _z - 1));
            else figureMoves.LegalMoves.Add((_x + 2, _z - 1));

        if (_chessboardScript.checkPosition(_x - 1, _z - 2))
            if (_chessboardScript.checkFigureColor(_x - 1, _z - 2, Type))
                figureMoves.AttackMoves.Add((_x - 1, _z - 2));
            else figureMoves.LegalMoves.Add((_x - 1, _z - 2));

        if (_chessboardScript.checkPosition(_x - 2, _z + 1))
            if (_chessboardScript.checkFigureColor(_x - 2, _z + 1, Type))
                figureMoves.AttackMoves.Add((_x - 2, _z + 1));
            else figureMoves.LegalMoves.Add((_x - 2, _z + 1));

        return figureMoves;
    }
}
