using UnityEngine;
using UnityEngine.UIElements;

public class ChessboardScript : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private Transform leftBottomCorner;
    [SerializeField] private Transform rightTopCorner;

    private (Object figure, Vector3 position)[,] _chessboard;

    void Start()
    {

        _chessboard = generateChessboard(leftBottomCorner, rightTopCorner);

        instantiateObjects();

    }
    void Update()
    {
        
    }
    private (Object figure, Vector3 position)[,] generateChessboard(Transform leftBottom, Transform rightTop)
    {
        (Object figure, Vector3 position)[,] generatedChessboard = new (Object figure, Vector3 position)[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                generatedChessboard[i, j] = (   new Object(), 
                                                getFieldPosition(leftBottom.position, rightTop.position, i, j)  );
            }
        }

        return generatedChessboard;
    }
    private Vector3 getFieldPosition(Vector3 leftBottomCorner, Vector3 rightTopCorner, int x, int z)
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

}
