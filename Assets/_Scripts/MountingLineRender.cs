using UnityEngine;

namespace _Scripts
{
    public class MountingLineRender: MonoBehaviour
    {
        [SerializeField] private Transform mountingPoint;
        
        private LineRenderer _lineRenderer;
        
        
        public void Initialize()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = 2; 
        }

        private void Update()
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, mountingPoint.position);
        }

        public void TurnOn()
        {
            _lineRenderer.enabled = true;
        }
        
        public void TurnOff()
        {
            _lineRenderer.enabled = false;
        }
    }
}