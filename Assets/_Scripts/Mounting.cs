using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class Mounting: MonoBehaviour
    {
        [SerializeField] private List<DetailType> detailTypes;
        [SerializeField] private List<MountingLineRender> mountingLineRenders;

        private bool _isActive;
        
        public List<DetailType> DetailTypes=> detailTypes;
        

        public void Initialize()
        {
            _isActive = true;

            foreach (var mountingLineRender in mountingLineRenders)
                mountingLineRender.Initialize();
        }

        public void Change()
        {
            if (_isActive)
                Off();
            else
                On();
        }
        
        public void On()
        {
            foreach (var mountingLineRender in mountingLineRenders)
                mountingLineRender.TurnOn();
            
            _isActive = true;
        }

        public void Off()
        {
            foreach (var mountingLineRender in mountingLineRenders)
                mountingLineRender.TurnOff();
            
            _isActive = false;
        }
    }
}