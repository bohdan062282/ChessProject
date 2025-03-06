using System.Collections.Generic;
using UnityEngine;

public class Queen : Figure
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
        return Queen.getQueenTypeMoves(_chessboardScript, _x, _z, Type);
    }
    public static FigureMoves getQueenTypeMoves(ChessboardScript chessboardScript, int xParam, int zParam, FigureColor figureColor)
    {
        FigureMoves figureMoves = new FigureMoves(new List<(int X, int Z)> { },
                                                    new List<(int X, int Z)> { });

        for (int x = -1; x < 2; x++)
        {
            for (int z = -1; z < 2; z++)
            {
                if (x == 0 && z == 0)
                    z = 1;

                int xPos = xParam + x;
                int zPos = zParam + z;

                for (; checkBounds(xPos, zPos); xPos += x, zPos += z)
                {
                    if (chessboardScript.checkPosition(xPos, zPos))
                    {
                        if (chessboardScript.checkFigureColor(xPos, zPos, figureColor))
                            figureMoves.AttackMoves.Add((xPos, zPos));
                        break;
                    }
                    else figureMoves.LegalMoves.Add((xPos, zPos));
                }
            }
        }

        return figureMoves;
    }
    private static bool checkBounds(int x, int z) => x < 8 && x > -1 && z < 8 && z > -1;
}
