using UnityEngine;

public class Figure : MonoBehaviour
{
    private ChessboardScript _chessboardScript;
    private int _x;
    private int _z;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Initialize(ChessboardScript chessboardScript, int x, int z)
    {
        _chessboardScript = chessboardScript;
        _x = x;
        _z = z;

        setPosition();
    }
    private void setPosition()
    {
        transform.position = _chessboardScript.getChessboard()[_x, _z].position;
    }

}
