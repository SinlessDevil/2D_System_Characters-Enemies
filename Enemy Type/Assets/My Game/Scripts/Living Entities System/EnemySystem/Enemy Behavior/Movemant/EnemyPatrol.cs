using UnityEngine;
using System.Collections;

namespace EnemySystem.EnemyBehavior.Movemant
{
    public class EnemyPatrol : EnemyMovemant{
        [SerializeField] private Transform[] _points;
        [SerializeField] private float waitTime = 2f;

        private bool _isWaitTo = false;
        private int _currentPoint = 0;

        public void Patroling(){
            MoveTo(_points[_currentPoint]);
            if (transform.position == _points[_currentPoint].position){
                if (_isWaitTo) return;
                StartCoroutine(WaitToNextPointRoutine());
            }
        }

        public bool IsWaitTo { get => _isWaitTo; private set => _isWaitTo = value; }
        private IEnumerator WaitToNextPointRoutine(){
            IsWaitTo = true;
            yield return new WaitForSeconds(waitTime);
            IsWaitTo = false;
            if(_currentPoint == _points.Length - 1)
                _currentPoint = 0;
            else
                _currentPoint++;
        }
    }
}