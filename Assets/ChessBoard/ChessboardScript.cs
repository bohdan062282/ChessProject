using UnityEngine;
using UnityEngine.UIElements;

public class ChessboardScript : MonoBehaviour
{
    [SerializeField] private ChessboardGenerator chessboardGenerator;

    [SerializeField] private GameObject highlightFieldPrefab;

    [SerializeField] private HighlightersPool highlighters;


    private (Figure figure, Vector3 position)[,] _chessboard;
    private Figure _selectedFigure;

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


        (int X, int Z)[] legalMoves = _selectedFigure.getLegalMoves();

        Vector3[] legalPositions = new Vector3[legalMoves.Length]; 

        for (int i = 0; i < legalMoves.Length; i++)
        {
            legalPositions[i] = _chessboard[legalMoves[i].X, legalMoves[i].Z].position;
        }

        highlighters.setPool(legalPositions);

    }
    public void unselectFigure()
    {
        _selectedFigure.unselect();

        highlighters.disablePool();
    }
   
    public (Figure figure, Vector3 position)[,] getChessboard() => _chessboard;

}
