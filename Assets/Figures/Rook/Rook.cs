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



        return figureMoves;
    }
}
