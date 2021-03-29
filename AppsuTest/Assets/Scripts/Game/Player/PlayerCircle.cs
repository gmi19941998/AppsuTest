using System;

using System.Collections.Generic;
using System.Linq;

using UnityEngine;


namespace AppsuTest
{
    public class PlayerCircle :Player,IDestroyFigure,IMoveable
    {

        private FingerController _fingerController=>gameObject.GetComponent<FingerController>();
        
        
        
        
        [SerializeField] private float _speed;
        public bool isMove { get; set; }
        [SerializeField] private Vector2 _lastPosition;


        [SerializeField] private List<Vector3> _targets;
         private int _currentTargets=0;
   


        public override event Action<float> UpdateDistanceCount;
        public override event Action<int> UpdateScoreCount;
        public override event Action<Figure> DestroyFigure;
        



        void Start()
        {
            if (_fingerController != null)
            {
                _fingerController.OnPlayerHit += OnPlayerHit;
                _fingerController.OnGroundHit += AddTarget;
            }

            _lastPosition = transform.position;
        }


        void Update()
        {

            if (_targets.Any()&&isMove)
            {
                Move();
                CountTotalDistance();
            }

        }

        public void Move()
        {
            var step = _speed * Time.fixedDeltaTime;
            var targetPosition = _targets[_currentTargets];
            targetPosition=new Vector3((float) Math.Round(targetPosition.x,2),(float) Math.Round(targetPosition.y,2));
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            var distance = Math.Round(Distance(targetPosition),2);

            if (distance == 0f)
            {
                _targets.RemoveAt(_currentTargets);
            }

        }

        private void AddTarget(Vector3 targetPosition)
        {
            isMove =true;
            _targets.Add(targetPosition);
        }

        private void OnPlayerHit()
        {
            isMove =false;
            _targets.Clear();
        }
        
        private float Distance(Vector3 _target)
        {
            return Vector3.Distance(transform.position, _target);
        }

        private void CountTotalDistance()
        {
            var position = transform.position;
            var distance = Vector3.Distance(_lastPosition, position);
            UpdateDistanceCount?.Invoke(distance);
            _lastPosition = position;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.GetComponent<Figure>())
            {
                UpdateScoreCount?.Invoke(1);
                DestroyFigure?.Invoke(other.collider.GetComponent<Figure>());
                Destroy(other.gameObject);

            }
        }


    }
}