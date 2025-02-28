using UnityEngine;

public class Pawn : Figure
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override (int X, int Z)[] getLegalMoves()
    {

        return new[] { (3, 4), (3, 5) };
    }
}
