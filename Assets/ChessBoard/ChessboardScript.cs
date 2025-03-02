using UnityEngine;
using UnityEngine.UIElements;

public class ChessboardScript : MonoBehaviour
{
    [SerializeField] private ChessboardGenerator chessboardGenerator;

    [SerializeField] private GameObject highlightFieldPrefab;

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
    public void selectFigure(Figure figure)
    {
        if (_selectedFigure != null) unselectFigure();

        _selectedFigure = figure;


        FigureMoves figureMoves = _selectedFigure.getLegalMoves();

        Vector3[] legalPositions = new Vector3[figureMoves.LegalMoves.Length]; 

        for (int i = 0; i < figureMoves.LegalMoves.Length; i++)
        {
            legalPositions[i] = _chessboard[figureMoves.LegalMoves[i].X, figureMoves.LegalMoves[i].Z].position;
        }

        highlighters.setPool(legalPositions);

    }
    public void unselectFigure()
    {
        if (_selectedFigure != null)
        {
            _selectedFigure.unselect();

            _selectedFigure = null;

            highlighters.disablePool();
        }
    }
   
    public (Figure figure, Vector3 position)[,] getChessboard() => _chessboard;

}
