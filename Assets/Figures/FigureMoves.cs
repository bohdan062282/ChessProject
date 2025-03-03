using System.Collections.Generic;
using UnityEngine;

public struct FigureMoves
{

    public List<(int X, int Z)> LegalMoves { get; set; }
    public List<(int X, int Z)> AttackMoves { get; set; }

    public FigureMoves( List<(int X, int Z)> legalMoves,
                        List<(int X, int Z)> attackMoves)
    {
        LegalMoves = legalMoves;
        AttackMoves = attackMoves;
    }


}
