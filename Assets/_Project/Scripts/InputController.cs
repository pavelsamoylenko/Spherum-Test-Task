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
                .Subscribe(_ => CheckInput())
                .AddTo(this);
        }

        private void CheckInput()
        {
            Vector3 forward = GetCameraForward();
            Vector3 right = GetCameraRight();
        
            if (Input.GetKey(KeyCode.W)) redCubeController.Move(forward * speed);
            if (Input.GetKey(KeyCode.A)) redCubeController.Move(-right * speed);
            if (Input.GetKey(KeyCode.S)) redCubeController.Move(-forward * speed);
            if (Input.GetKey(KeyCode.D)) redCubeController.Move(right * speed);

            if (Input.GetKey(KeyCode.UpArrow)) greenCubeController.Move(forward * speed);
            if (Input.GetKey(KeyCode.LeftArrow)) greenCubeController.Move(-right * speed);
            if (Input.GetKey(KeyCode.DownArrow)) greenCubeController.Move(-forward * speed);
            if (Input.GetKey(KeyCode.RightArrow)) greenCubeController.Move(right * speed);
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