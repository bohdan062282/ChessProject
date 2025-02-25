using System;
using UnityEngine;

[Serializable]
public class ChessboardGenerator
{
    [SerializeField] public Transform leftBottomCorner;
    [SerializeField] public Transform rightTopCorner;

    [SerializeField] private GameObject pawnPrefab;
    [SerializeField] private GameObject rookPrefab;

    public static readonly int[,] BASIC_LAYOUT = new int[,] {   { 0, 1, 0, 0 ,0 ,0 ,0 ,0 },
                                                                { 0, 1, 0, 0 ,0 ,0 ,0 ,0 },
                                                                { 0, 1, 0, 0 ,0 ,0 ,0 ,0 },
                                                                { 0, 1, 0, 0 ,0 ,0 ,0 ,0 },
                                                                { 0, 1, 0, 0 ,0 ,0 ,0 ,0 },
                                                                { 0, 1, 0, 0 ,0 ,0 ,0 ,0 },
                                                                { 0, 1, 0, 0 ,0 ,0 ,0 ,0 },
                                                                { 0, 1, 0, 0 ,0 ,0 ,0 ,0 }};

    public void InitializeFigures(ChessboardScript chessboard, int[,] layout)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                switch (layout[i,j])
                {
                    case 1:
                        {
                            InstantiateFigure(chessboard, pawnPrefab, i, j);
                            break;
                        }
                    case 2:
                        {
                            InstantiateFigure(chessboard, rookPrefab, i, j);
                            break;
                        }
                }
            }
        }
    }
    private static void InstantiateFigure(ChessboardScript chessboard, GameObject figurePrefab, int x, int z)
    {
        GameObject gameObject = UnityEngine.GameObject.Instantiate(figurePrefab);
        chessboard.getChessboard()[x, z].figure = gameObject.GetComponent<Figure>();
        chessboard.getChessboard()[x, z].figure.Initialize(chessboard, x, z);
    }
    public static (Figure figure, Vector3 position)[,] generateChessboard(Transform leftBottom, Transform rightTop)
    {
        (Figure figure, Vector3 position)[,] generatedChessboard = new (Figure figure, Vector3 position)[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                generatedChessboard[i, j] = (   null,
                                                generateFieldPosition(leftBottom.position, rightTop.position, i, j) );
            }
        }
        return generatedChessboard;
    }
    private static Vector3 generateFieldPosition(Vector3 leftBottomCorner, Vector3 rightTopCorner, int x, int z)
    {
        float xSize = (rightTopCorner.x - leftBottomCorner.x) / 8;
        float zSize = (rightTopCorner.z - leftBottomCorner.z) / 8;

        return new Vector3(leftBottomCorner.x + (x * xSize) + (xSize / 2),
                            leftBottomCorner.y,
                            leftBottomCorner.z + (z * zSize) + (zSize / 2));
    }
}
