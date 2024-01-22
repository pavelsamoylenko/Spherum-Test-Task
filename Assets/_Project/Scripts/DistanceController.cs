using System;
using _Project.Scripts.UI;
using UnityEngine;

namespace _Project.Scripts
{
    public class DistanceController : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField, Range(0, 10)] private float distanceToShowSpheres = 2f;
        [SerializeField, Range(0, 2)] private float distanceToChangeScene = 1f;
        
        [Header("Dependencies")]
        [SerializeField] private Collider redCollider;
        [SerializeField] private Collider greenCollider;
        [SerializeField] private GameObject spheresParent;
        [SerializeField] private DistanceView distanceView;
        
        public event Action OnDistanceConditionMet;

        private void Awake()
        {
            spheresParent.SetActive(false);
        }

        private void Update()
        {
            var redClosestPoint = redCollider.ClosestPoint(greenCollider.transform.position);
            var greenClosestPoint = greenCollider.ClosestPoint(redCollider.transform.position);
            
            float distance = Vector3.Distance(redClosestPoint, greenClosestPoint);

            distanceView.SetDistanceValue(distance);

            if (distance > distanceToShowSpheres)
            {
                spheresParent.SetActive(false);
            }
            else if(distance <= distanceToShowSpheres && distance > distanceToChangeScene)
            {
                spheresParent.SetActive(true);
            }
            else
            {
                Debug.Log($"Distance is less then {distanceToChangeScene.ToString()}");
                OnDistanceConditionMet?.Invoke();
            }
        }
    }
}