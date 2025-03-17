using UnityEngine;

public class Game
{
    public static readonly LayerMask WHITE = LayerMask.GetMask("White");
    public static readonly LayerMask BLACK = LayerMask.GetMask("Black");


    private FigureColor _currentPlayerColor;
    private ChessboardScript _chessboard;
    private PlayerController _playerController;

    public Game(ChessboardScript chessboard, PlayerController playerController)
    {
        _currentPlayerColor = FigureColor.WHITE;
        _chessboard = chessboard;
        _playerController = playerController;
    }
    public void makeMove()
    {
        if (_currentPlayerColor == FigureColor.WHITE)
        {
            _currentPlayerColor = FigureColor.BLACK;
            _playerController.setCameraBlack();
        }
        else
        {
            _currentPlayerColor = FigureColor.WHITE;
            _playerController.setCameraWhite();
        }

        if (_chessboard.isEnd(_currentPlayerColor)) Debug.Log("MAT!!");
    }

    public LayerMask getColorMask() => _currentPlayerColor == FigureColor.WHITE ? Game.WHITE : Game.BLACK;
    public FigureColor getColor() => _currentPlayerColor;
    
}
