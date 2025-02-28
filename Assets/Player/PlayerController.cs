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

    private InputAction action;

    private GameObject _focusItem;

    void Start()
    {
        action = InputSystem.actions.FindAction("actioner");


    }

    // Update is called once per frame
    void Update()
    {


        if (action.WasPressedThisFrame())
        {
            Vector2 cameraInputRotation = action.ReadValue<Vector2>();

            cameraCenterObject.Rotate(0.0f, 0.2f * cameraInputRotation.x, 0.0f, Space.World);
            cameraCenterObject.Rotate(-0.2f * cameraInputRotation.y, 0.0f, 0.0f);

        }
        else checkOutline();



    }

    private void checkOutline()
    {
        GameObject newGameObject = getFocusFigure();

        if (_focusItem == null)
        {
            if (newGameObject != null)
            {
                onFigureFocus(newGameObject);
                _focusItem = newGameObject;
            }
        }
        else if (newGameObject != _focusItem)
        {
            onFigureUnfocus(_focusItem);
            
            if (newGameObject == null)
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
