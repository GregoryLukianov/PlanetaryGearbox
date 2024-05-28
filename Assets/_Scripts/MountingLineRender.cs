using System;
using UnityEngine;

namespace _Scripts
{
    public class MountingLineRender: MonoBehaviour
    {
        public Transform mountingPoint;
        
        private Transform Center => transform;
        private LineRenderer _lineRenderer;

        
        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = 2; 
        }

        private void Update()
        {
            _lineRenderer.SetPosition(0, Center.position);
            _lineRenderer.SetPosition(1, mountingPoint.position);
        }
    }
}