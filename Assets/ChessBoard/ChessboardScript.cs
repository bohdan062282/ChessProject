using UnityEngine;
using UnityEngine.UIElements;

public class ChessboardScript : MonoBehaviour
{


    [SerializeField] private ChessboardGenerator chessboardGenerator;

    private (Figure figure, Vector3 position)[,] _chessboard;

    void Start()
    {

        _chessboard = ChessboardGenerator.generateChessboard(   chessboardGenerator.leftBottomCorner, 
                                                                chessboardGenerator.rightTopCorner      );

        chessboardGenerator.InitializeFigures(this, ChessboardGenerator.BASIC_LAYOUT);

    }
    void Update()
    {
        
    }
   
    public (Figure figure, Vector3 position)[,] getChessboard() => _chessboard;

}
