using UnityEngine;

namespace _Project.Scripts
{
    public class CubeParticlesInitializer : MonoBehaviour
    {
        [SerializeField] private CubeController redCubeController;
        [SerializeField] private CubeController greenCubeController;
    
        private void Start()
        {
            redCubeController.ParticleController.Initialize(greenCubeController.Model);
            greenCubeController.ParticleController.Initialize(redCubeController.Model);
        }
    }
}
