using UnityEngine;
using UnityEngine.UIElements;

public class ChessboardScript : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private Transform leftBottomCorner;
    [SerializeField] private Transform rightTopCorner;

    [SerializeField] private GameObject pawnPrefab;

    private (Figure figure, Vector3 position)[,] _chessboard;

    void Start()
    {

        _chessboard = generateChessboard(leftBottomCorner, rightTopCorner);

        instantiateObjects();


        GameObject gameObject = Instantiate(pawnPrefab);
        _chessboard[0, 1].figure = gameObject.GetComponent<Figure>();
        _chessboard[0, 1].figure.Initialize(this, 0, 1);

    }
    void Update()
    {
        
    }
    private (Figure figure, Vector3 position)[,] generateChessboard(Transform leftBottom, Transform rightTop)
    {
        (Figure figure, Vector3 position)[,] generatedChessboard = new (Figure figure, Vector3 position)[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                generatedChessboard[i, j] = (   null, 
                                                generateFieldPosition(leftBottom.position, rightTop.position, i, j)  );
            }
        }

        return generatedChessboard;
    }
    private Vector3 generateFieldPosition(Vector3 leftBottomCorner, Vector3 rightTopCorner, int x, int z)
    {
        float xSize = (rightTopCorner.x - leftBottomCorner.x) / 8;
        float zSize = (rightTopCorner.z - leftBottomCorner.z) / 8;

        return new Vector3( leftBottomCorner.x + (x * xSize) + (xSize / 2),
                            leftBottomCorner.y,
                            leftBottomCorner.z + (z * zSize) + (zSize / 2) );
    }

    private void instantiateObjects()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject go = GameObject.Instantiate(prefab);
                go.transform.position = _chessboard[i, j].position;
            }
        }
    }
    public (Figure figure, Vector3 position)[,] getChessboard() => _chessboard;

}
