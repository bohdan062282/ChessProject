using UnityEngine;

public class Figure : MonoBehaviour
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
    public void Initialize(ChessboardScript chessboardScript, int x, int z, FigureColor type)
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

        setPosition();
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
    public virtual FigureMoves getLegalMoves()
    {

        return new FigureMoves(  new (int X, int Z)[] { (3, 4), (4, 4) },
                                 new (int X, int Z)[] { (3, 5) });
    }
    private void setPosition()
    {
        transform.position = _chessboardScript.getChessboard()[_x, _z].position;
    }

    public FigureColor Type { get; private set; }

}
public enum FigureColor { WHITE, BLACK };
