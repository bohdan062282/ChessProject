using UnityEngine;

public class HighlighterScript : MonoBehaviour, IFocusable
{

    [SerializeField] MeshRenderer m_Renderer;

    [HideInInspector] public int X;
    [HideInInspector] public int Z;

    private Color _color;

    void Start()
    {
        
        _color = m_Renderer.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onFocusEnter()
    {
        m_Renderer.material.color = new Color(_color.r + 0.2f, _color.g + 0.2f, _color.b + 0.2f, _color.a);
    }
    public void onFocusExit()
    {
        m_Renderer.material.color = _color;
    }
    public void select()
    {

    }
}
