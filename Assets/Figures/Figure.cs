using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour, IFocusable
{
    protected ChessboardScript _chessboardScript;
    protected int _x;
    protected int _z;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void Initialize(ChessboardScript chessboardScript, int x, int z, FigureColor type)
    {
        _chessboardScript = chessboardScript;
        _x = x;
        _z = z;

        Type = type;

        Outline outline = gameObject.GetComponent<Outline>();
        outline.OutlineColor = Color.magenta;
        outline.enabled = false;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineWidth = 3.0f;

        setTransformPosition();
    }
    public void select()
    {
        _chessboardScript.selectFigure(this);

        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + 0.5f, pos.z);

    }
    public void unselect()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y - 0.5f, pos.z);
    }
    public void rip()
    {
        Destroy(gameObject);
    }
    public virtual FigureMoves getMoves()
    {

        return new FigureMoves(new List<(int X, int Z)> { (3, 4), (4, 4) },
                                 new List<(int X, int Z)> { (3, 5) });
    }
    public virtual void move()
    {
        
    }
    public void setCoord(int x, int z)
    {
        _x = x; _z = z;
    }
    public void setTransformPosition()
    {
        transform.position = _chessboardScript.getChessboard()[_x, _z].position;
    }
    public void onFocusEnter()
    {
        gameObject.GetComponent<Outline>().enabled = true;
    }
    public void onFocusExit()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }

    public FigureColor Type { get; private set; }
    public int X { get => _x; }
    public int Z { get => _z; }

}
public enum FigureColor { WHITE, BLACK };
