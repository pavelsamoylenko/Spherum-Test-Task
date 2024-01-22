using UniRx;
using UnityEngine;

namespace _Project.Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private float speed;
    
        [SerializeField] private Camera cam;
        [SerializeField] private CubeController redCubeController;
        [SerializeField] private CubeController greenCubeController;

        private void Awake() {
            Observable
                .EveryUpdate()
                .Subscribe(_ => PollInput())
                .AddTo(this);
        }

        private void PollInput()
        {
            Vector3 forward = GetCameraForward();
            Vector3 right = GetCameraRight();
            
            redCubeController.Move(forward * Input.GetAxis("Vertical2") * speed);
            redCubeController.Move(right * Input.GetAxis("Horizontal2") * speed);
            
            greenCubeController.Move(forward * Input.GetAxis("Vertical") * speed);
            greenCubeController.Move(right * Input.GetAxis("Horizontal") * speed);
        }

        
        private Vector3 GetCameraForward()
        {
            Vector3 forward = cam.transform.forward;
            forward.y = 0;
            return forward.normalized;
        }

        private Vector3 GetCameraRight()
        {
            Vector3 right = cam.transform.right;
            right.y = 0;
            return right.normalized;
        }
    }
}