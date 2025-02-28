using UnityEngine;
using UnityEngine.UIElements;

public class ChessboardScript : MonoBehaviour
{
    [SerializeField] private ChessboardGenerator chessboardGenerator;

    [SerializeField] private GameObject highlightFieldPrefab;


    private (Figure figure, Vector3 position)[,] _chessboard;
    private Figure _selectedFigure;

    void Start()
    {

        _chessboard = ChessboardGenerator.generateChessboard(   chessboardGenerator.leftBottomCorner, 
                                                                chessboardGenerator.rightTopCorner      );

        chessboardGenerator.InitializeFigures(this, ChessboardGenerator.BASIC_LAYOUT);

    }
    void Update()
    {
        
    }
    public void selectFigure(Figure figure)
    {
        _selectedFigure = figure;
    }
   
    public (Figure figure, Vector3 position)[,] getChessboard() => _chessboard;

}
