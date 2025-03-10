using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChessboardScript : MonoBehaviour
{
    [SerializeField] private ChessboardGenerator chessboardGenerator;

    [SerializeField] private HighlightersPool highlighters;


    private Figure _selectedFigure;
    private (Figure figure, Vector3 position)[,] _chessboard;

    void Start()
    {

        _chessboard = ChessboardGenerator.generateChessboard(   chessboardGenerator.leftBottomCorner, 
                                                                chessboardGenerator.rightTopCorner      );

        chessboardGenerator.InitializeFigures(this, ChessboardGenerator.BASIC_LAYOUT);

        highlighters.Initialize(this);

    }
    void Update()
    {
        
    }
    public bool checkPosition(int x, int z)
    {
        if (_chessboard[x, z].figure == null) return false;
        else return true;
    }
    public bool checkPosition(int x, int z, FigureColor figureColor)
    {
        if (_chessboard[x, z].figure != null) return checkFigureColor(x, z, figureColor);
        else return false;
    }
    public bool checkFigureColor(int x, int z, FigureColor figureColor)
    {
        if (_chessboard[x, z].figure.Type != figureColor)
            return true;
        else return false;
    }
    public void selectFigure(Figure figure)
    {
        if (_selectedFigure != null) unselectFigure();

        _selectedFigure = figure;

        FigureMoves figureMoves = _selectedFigure.getMoves();

        highlighters.setPoolLegal(figureMoves.LegalMoves, this);
        highlighters.setPoolAttack(figureMoves.AttackMoves, this);

    }
    public void moveTo(int x, int z)
    {
        if (_selectedFigure != null)
        {
            Figure figure = _selectedFigure;
            figure.move();

            _chessboard[figure.X, figure.Z].figure = null;

            if (_chessboard[x, z].figure != null)
                _chessboard[x, z].figure.rip();

            unselectFigure();

            Figure newFigure = checkPawnMove(figure, x, z);
            if (newFigure != null)
            {
                figure.rip();
                _chessboard[x, z].figure = newFigure;
            }
            else
            {
                _chessboard[x, z].figure = figure;
                figure.setCoord(x, z);
                figure.setTransformPosition();
            }

            Debug.Log(checkKingDanger(WhiteKing, 2, 4));

        }
    }
    public void unselectFigure()
    {
        if (_selectedFigure != null)
        {
            _selectedFigure.unselect();

            _selectedFigure = null;

            highlighters.disablePoolLegal();
            highlighters.disablePoolAttack();
        }
    }
    private Figure checkPawnMove(Figure figure, int x, int z)
    {
        if (figure is Pawn)
        {
            Pawn pawn = _selectedFigure as Pawn;
            if (z == 7 && figure.Type == FigureColor.WHITE)
                return ChessboardGenerator.InstantiateFigure(this, chessboardGenerator.figurePrefabs[5], FigureColor.WHITE, x, z);
            else if (z == 0 && figure.Type == FigureColor.BLACK)
                return ChessboardGenerator.InstantiateFigure(this, chessboardGenerator.figurePrefabs[11], FigureColor.BLACK, x, z);
            else return null;
        }
        else return null;
    }
    private bool checkKingDanger(Figure king, int x, int z)
    {
        Figure tmpDelFigure = _chessboard[x, z].figure;
        _chessboard[king.X, king.Z].figure = null;
        _chessboard[x, z].figure = king;

        List<(int X, int Z)> moves;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Figure figure = _chessboard[i, j].figure;
                if (figure != null && figure.Type != king.Type)
                {
                    moves = figure.getMoves().AttackMoves;
                    if (moves.Contains((x, z)))
                    {
                        _chessboard[king.X, king.Z].figure = king;
                        _chessboard[x, z].figure = tmpDelFigure;

                        return true;
                    }
                }
                
            }
        }
        _chessboard[king.X, king.Z].figure = king;
        _chessboard[x, z].figure = tmpDelFigure;

        return false;
    }
   
    public (Figure figure, Vector3 position)[,] getChessboard() => _chessboard;
    public Figure WhiteKing { get; set; }
    public Figure BlackKing { get; set; }

}
