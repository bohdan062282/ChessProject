using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private CinemachineFollow cinemachineFollow;
    [SerializeField] private CinemachineHardLookAt cinemachineHardLookAt;

    [SerializeField] private Transform cameraCenterObject;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask figureLayerMask;

    [SerializeField] private FigureColor playerColor;

    [SerializeReference] private ChessboardScript chessboardScript;

    private InputAction rotateAction;
    private InputAction clickAction;
    private InputAction escapeAction;

    private GameObject _focusItem;

    void Start()
    {
        rotateAction = InputSystem.actions.FindAction("rotate");
        clickAction = InputSystem.actions.FindAction("click");
        escapeAction = InputSystem.actions.FindAction("escape");


    }

    // Update is called once per frame
    void Update()
    {


        if (rotateAction.WasPressedThisFrame())
        {
            Vector2 cameraInputRotation = rotateAction.ReadValue<Vector2>();

            cameraCenterObject.Rotate(0.0f, 0.2f * cameraInputRotation.x, 0.0f, Space.World);
            cameraCenterObject.Rotate(-0.2f * cameraInputRotation.y, 0.0f, 0.0f);

        }
        else
        {
            checkOutline();

            if (clickAction.WasPerformedThisFrame() && _focusItem != null)
                _focusItem.GetComponent<Figure>().select();
            else if (escapeAction.WasPerformedThisFrame()) chessboardScript.unselectFigure();
                
        }



    }

    private void checkOutline()
    {
        GameObject newGameObject = getFocusFigure();

        if (_focusItem == null)
        {
            if (newGameObject != null && newGameObject.GetComponent<Figure>().Type == playerColor)
            {
                onFigureFocus(newGameObject);
                _focusItem = newGameObject;
            }
        }
        else if (newGameObject != _focusItem)
        {
            onFigureUnfocus(_focusItem);
            
            if (newGameObject == null || newGameObject.GetComponent<Figure>().Type != playerColor)
            {
                _focusItem = null;
            }
            else
            {
                onFigureFocus(newGameObject);
                _focusItem = newGameObject;
            }
            
        }
    }
    private GameObject getFocusFigure()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, figureLayerMask))
            return hit.collider.gameObject;
        else return null;

    }
    private void onFigureFocus(GameObject go)
    {
        go.GetComponent<Outline>().enabled = true;
    }
    private void onFigureUnfocus(GameObject go)
    {
        go.GetComponent<Outline>().enabled = false;
    }
}
