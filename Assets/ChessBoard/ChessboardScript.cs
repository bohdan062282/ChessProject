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

            _chessboard[figure.X, figure.Z].figure = null;

            if (_chessboard[x, z].figure != null)
                _chessboard[x, z].figure.rip();

            _chessboard[x, z].figure = figure;

            unselectFigure();

            figure.setCoord(x, z);
            figure.setTransformPosition();
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
   
    public (Figure figure, Vector3 position)[,] getChessboard() => _chessboard;

}
