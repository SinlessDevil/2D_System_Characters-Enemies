using UnityEngine;

namespace FollowerSystem
{
    public abstract class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Vector3 _offcet;
        [SerializeField] private float _smoothing = 1f;

        private void Awake()
        {
            if (_targetTransform == null)
                throw new System.Exception($"There is no targetTransform component on the object: {gameObject.name}");
        }

        protected void MoveTo(float deltaTime)
        {
            var nextPosition = Vector3.Lerp(transform.position, _targetTransform.position + _offcet, deltaTime * _smoothing);

            transform.position = nextPosition;
        }
    }
}