using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private CinemachineFollow cinemachineFollow;
    [SerializeField] private CinemachineHardLookAt cinemachineHardLookAt;

    [SerializeField] private Transform cameraCenterObject;

    private InputAction action;

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

            
            cameraCenterObject.Rotate(0.2f * cameraInputRotation.y, 0.2f * cameraInputRotation.x, 0.0f);
        }



    }
}
