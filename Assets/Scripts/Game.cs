using UnityEngine;

public class Game
{
    public static readonly LayerMask WHITE = LayerMask.GetMask("White");
    public static readonly LayerMask BLACK = LayerMask.GetMask("Black");


    private LayerMask _currentPlayerColor;

    public Game()
    {
        _currentPlayerColor = Game.BLACK;
    }




    public LayerMask getColor() => _currentPlayerColor;
    
}
