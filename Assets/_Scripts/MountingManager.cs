using UnityEngine;

namespace _Scripts
{
    public class MountingManager: MonoBehaviour
    {
        [SerializeField] private Mounting[] mountings;

        private bool _isActive;

        
        public void Initialize()
        {
            _isActive = true;
            
            foreach (var mounting in mountings)
                mounting.Initialize();
        }

        public void ChangeMountingVisible(DetailType detailType)
        {
            if (!_isActive)
                return;
            
            foreach (var mounting in mountings)
                foreach (var detailTypeInMounting in mounting.DetailTypes)
                {
                    if (detailTypeInMounting != detailType)
                        continue;
                    
                    mounting.Change();
                }
        }

        public void ChangeLinesStatus()
        {
            if (_isActive)
                TurnOff();
            else
                TurnOn();
        }

        private void TurnOff()
        {
            foreach (var mounting in mountings)
                mounting.Off();

            _isActive = false;
        }

        private void TurnOn()
        {
            foreach (var mounting in mountings)
                mounting.On();

            _isActive = true;
        }
    }
}