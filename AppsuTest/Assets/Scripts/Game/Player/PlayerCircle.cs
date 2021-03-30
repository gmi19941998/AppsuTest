using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace AppsuTest
{
    public class PlayerCircle : Player, IDestroyFigure, IMovable
    {
        private FingerController _fingerController => gameObject.GetComponent<FingerController>();
        [SerializeField] private float _speed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _timeFromZeroToMax;
        [SerializeField] private float _timeFromMaxToZero;
        [SerializeField] private float _distanceToStop;
         public bool isMove { get; set; }
         private int _currentTargets;
         private Vector2 _lastPosition;
        [SerializeField] private List<Vector3> _targets;
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
            if (_targets.Any() && isMove)
            {
                Move();
                CountTotalDistance();
            }
        }

        public void Move()
        {
            var step = _speed * Time.deltaTime;
            var targetPosition = _targets[_currentTargets];
            var distance =  Math.Round(Distance(transform.position,targetPosition),2);
            bool _checkStopDistance =Distance(transform.position, _targets[_targets.Count-1])<_distanceToStop;
            if ((_targets.Count-6<_currentTargets)&&_checkStopDistance)
            {
                _speed = Mathf.MoveTowards (_speed, 1, Deceleration());
            }
            else
            {
                _speed = Mathf.MoveTowards(_speed, _maxSpeed, Acceleration());
            }

            if (distance == 0f)
            {
                _currentTargets++;
                if (_currentTargets == _targets.Count)
                {
                    StopMoving();
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }


        float Acceleration()
        {
          return 1 / _timeFromZeroToMax * Time.deltaTime; 
        }

        float Deceleration()
        {
            return  1 / _timeFromMaxToZero * Time.deltaTime;
        }
        private void AddTarget(Vector3 targetPosition)
        {
            isMove = true;
            _targets.Add(targetPosition);
        }

        private void OnPlayerHit()
        {
            StopMoving();
        }

        public void StopMoving()
        {
            isMove = false;
            _targets.Clear();
            _currentTargets = 0;
            _speed = 0; 
        }
        private float Distance(Vector3 _current,Vector3 _target)
        {
            return Vector3.Distance(_current, _target);
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