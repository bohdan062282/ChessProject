using UnityEngine;

public class Game
{
    public static readonly LayerMask WHITE = LayerMask.GetMask("White");
    public static readonly LayerMask BLACK = LayerMask.GetMask("Black");


    private FigureColor _currentPlayerColor;
    private ChessboardScript _chessboard;

    public Game(ChessboardScript chessboard)
    {
        _currentPlayerColor = FigureColor.BLACK;
        _chessboard = chessboard;
    }
    public void makeMove()
    {
        changeColor();

        if (_chessboard.isEnd(_currentPlayerColor)) Debug.Log("MAT!!");
    }
    private void changeColor() => _currentPlayerColor = _currentPlayerColor == FigureColor.WHITE ? FigureColor.BLACK : FigureColor.WHITE;




    public LayerMask getColorMask() => _currentPlayerColor == FigureColor.WHITE ? Game.WHITE : Game.BLACK;
    public FigureColor getColor() => _currentPlayerColor;
    
}
