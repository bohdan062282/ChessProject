using System;
using UnityEngine;

[Serializable]
public class ChessboardGenerator
{
    [SerializeField] public Transform leftBottomCorner;
    [SerializeField] public Transform rightTopCorner;

    [Space(10)]
    [Header("Element 1 - need to be null")]

    [SerializeField] public GameObject[] figurePrefabs;


    public static readonly int[,] BASIC_LAYOUT = new int[,] {   { 2, 1, 0, 0 ,0 ,0 ,7 ,8 },
                                                                { 3, 1, 0, 0 ,6 ,0 ,7 ,9 },
                                                                { 4, 1, 0, 0 ,0 ,0 ,7 ,10 },
                                                                { 5, 1, 0, 0 ,3 ,0 ,7 ,11 },
                                                                { 6, 1, 0, 0 ,0 ,0 ,7 ,12 },
                                                                { 4, 1, 0, 5 ,1 ,0 ,7 ,10 },
                                                                { 3, 1, 0, 0 ,0 ,0 ,7 ,9 },
                                                                { 2, 1, 0, 0 ,0 ,0 ,7 ,8 }};

    public void InitializeFigures(ChessboardScript chessboard, int[,] layout)
    {
        if (figurePrefabs.Length > 12)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (layout[i, j] != 0)
                    {
                        if (layout[i, j] < 7)
                            chessboard.getChessboard()[i, j].figure = 
                                InstantiateFigure(chessboard, figurePrefabs[layout[i, j]], FigureColor.WHITE, i, j);
                        else chessboard.getChessboard()[i, j].figure =
                                InstantiateFigure(chessboard, figurePrefabs[layout[i, j]], FigureColor.BLACK, i, j);
                    }
                }
            }
        }  
    }
    public static Figure InstantiateFigure(ChessboardScript chessboard, GameObject figurePrefab, FigureColor type, int x, int z)
    {
        GameObject gameObject = UnityEngine.GameObject.Instantiate(figurePrefab);
        Figure figure = gameObject.GetComponent<Figure>();
        figure.Initialize(chessboard, x, z, type);
        return figure;
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
