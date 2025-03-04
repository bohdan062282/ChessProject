using System.Collections.Generic;
using UnityEngine;

public class King : Figure
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

        for (int x = -1; x < 2; x++)
        {
            for (int z = -1; z < 2; z++)
            {
                int xPos = _x + x;
                int zPos = _z + z;

                if (checkBounds(xPos, zPos))
                {
                    if (_chessboardScript.checkPosition(xPos, zPos))
                    {
                        if (_chessboardScript.checkFigureColor(xPos, zPos, Type))
                            figureMoves.AttackMoves.Add((xPos, zPos));
                    }
                    else figureMoves.LegalMoves.Add((xPos, zPos));
                }
            }
        }

        return figureMoves;
    }
    private bool checkBounds(int x, int z) => x < 8 && x > -1 && z < 8 && z > -1;
}
