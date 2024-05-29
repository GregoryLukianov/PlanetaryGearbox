using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class Mounting: MonoBehaviour
    {
        public List<DetailType> detailTypes;

        public List<MountingLineRender> mountingLineRenders;
        
        public bool IsActive { get; private set; }

        private void Start()
        {
            IsActive = true;
        }

        public void Change()
        {
            if (IsActive)
            {
                Off();
            }
            else
            {
                On();
            }
        }
        
        public void On()
        {
            foreach (var mountingLineRender in mountingLineRenders)
            {
                mountingLineRender.TurnOn();
            }
            IsActive = true;
        }

        public void Off()
        {
            foreach (var mountingLineRender in mountingLineRenders)
            {
                mountingLineRender.TurnOff();
            }
            IsActive = false;
        }
    }
}