using UnityEngine;

namespace EnemySystem.EnemyBehavior.Movemant
{
    public abstract class EnemyMovemant : MonoBehaviour, IEnemyMovemant{
        [SerializeField] protected float _speed;
        [SerializeField] protected Transform _bodyEnemy;

        private Vector3 _lookRight;
        private Vector3 _lookLeft;

        private void Start(){
            SetVectorFlipBody();
        }

        public virtual void MoveTo(Transform target){
            transform.position = Vector3.MoveTowards(transform.position, 
                target.position, _speed);

            FlipBody(target);
        }

        private void SetVectorFlipBody(){
            _lookRight = new Vector3(0, 0, 0);
            _lookLeft = new Vector3(0, 180, 0);
        }
        private void FlipBody(Transform target){
            if (transform.position.x <= target.position.x)
                _bodyEnemy.eulerAngles = _lookRight;
            else
                _bodyEnemy.eulerAngles = _lookLeft;
        }
    }
}