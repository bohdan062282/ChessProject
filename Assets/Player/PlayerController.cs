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
    [SerializeField] private LayerMask highlighterLayerMask;

    [SerializeField] private FigureColor playerColor;

    [SerializeReference] private ChessboardScript chessboardScript;

    private InputAction rotateAction;
    private InputAction clickAction;
    private InputAction escapeAction;

    private IFocusable _focusItem;
    private IFocusable _focusField;

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
            _focusField = setFocusable(_focusField, highlighterLayerMask);
            HighlighterScript highlighter = _focusField as HighlighterScript;

            _focusItem = setFocusable(_focusItem, figureLayerMask);
            Figure selectedFigure = _focusItem as Figure;

            if (clickAction.WasPerformedThisFrame())
            {
                if (_focusField != null)
                    highlighter.select();
                else if (_focusItem != null)
                    selectedFigure.select();
            }
            else if (escapeAction.WasPerformedThisFrame()) chessboardScript.unselectFigure();

        }



    }
    private IFocusable setFocusable(IFocusable currentObject, int layerMask)
    {
        GameObject focusObj = getFocusObject(layerMask);
        IFocusable newGameObject = focusObj == null ? null : focusObj.GetComponent<IFocusable>();
        IFocusable gameObject = null;

        if (currentObject == null || currentObject as Object == null)
        {
            if (newGameObject != null)
            {
                newGameObject.onFocusEnter();
                gameObject = newGameObject;
            }
        }
        else if (newGameObject != currentObject)
        {
            currentObject.onFocusExit();

            if (newGameObject == null) gameObject = null;
            else
            {
                newGameObject.onFocusEnter();
                gameObject = newGameObject;
            }
        }
        else gameObject = currentObject;

        return gameObject;
    }
    private GameObject getFocusObject(int layerMask)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            return hit.collider.gameObject;
        else return null;

    }

}
