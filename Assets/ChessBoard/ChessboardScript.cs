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

        highlighters.Initialize();

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

        Vector3[] legalPositions = new Vector3[figureMoves.LegalMoves.Count];
        Vector3[] attackPositions = new Vector3[figureMoves.AttackMoves.Count];

        for (int i = 0; i < figureMoves.LegalMoves.Count; i++)
            legalPositions[i] = _chessboard[figureMoves.LegalMoves[i].X, figureMoves.LegalMoves[i].Z].position;

        for (int i = 0; i < figureMoves.AttackMoves.Count; i++)
            attackPositions[i] = _chessboard[figureMoves.AttackMoves[i].X, figureMoves.AttackMoves[i].Z].position;

        highlighters.setPoolLegal(legalPositions);
        highlighters.setPoolAttack(attackPositions);

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
