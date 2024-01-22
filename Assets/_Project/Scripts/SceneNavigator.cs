using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts
{
    public class SceneNavigator : MonoBehaviour
    {
        [SerializeField] private DistanceController distanceController;
        
        private void OnEnable()
        {
            distanceController.OnDistanceConditionMet += MoveToScene2;
        }
        private void OnDisable()
        {
            distanceController.OnDistanceConditionMet -= MoveToScene2;
        }

        private void MoveToScene2()
        {
            SceneManager.LoadScene("Scene 2");
        }
    }
}