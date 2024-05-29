using System;
using UnityEngine;

namespace _Scripts
{
    public class MountingManager: MonoBehaviour
    {
        public Mounting[] mountings;
        
        public bool IsActive { get; private set; }

        private void Start()
        {
            IsActive = true;
        }

        public void ChangeMountingVisible(DetailType detailType)
        {
            if (!IsActive)
                return;
            
            foreach (var mounting in mountings)
            {
                foreach (var detailTypeInMounting in mounting.detailTypes)
                {
                    if (detailTypeInMounting != detailType)
                        continue;
                    
                    mounting.Change();
                }
            }
        }

        public void ChangeLinesStatus()
        {
            if (IsActive)
                TurnOff();
            else
            {
                TurnOn();
            }
        }

        private void TurnOff()
        {
            foreach (var mounting in mountings)
            {
                mounting.Off();
            }

            IsActive = false;
        }

        private void TurnOn()
        {
            foreach (var mounting in mountings)
            {
                mounting.On();
            }

            IsActive = true;
        }
    }
}