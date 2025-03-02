using UnityEngine;

public struct FigureMoves
{

    public (int X, int Z)[] LegalMoves { get; set; }
    public (int X, int Z)[] AttackMoves { get; set; }

    public FigureMoves( (int X, int Z)[] legalMoves,
                        (int X, int Z)[] attackMoves)
    {
        LegalMoves = legalMoves;
        AttackMoves = attackMoves;
    }


}
