using System;
using UnityEngine;

namespace _Scripts
{
    public class Model: MonoBehaviour
    {
        [SerializeField] Detail[] details;

        private bool _isOpened;

        
        private void Start()
        {
            _isOpened = false;
            foreach (var detail in details)
            {
                detail.Initialize();
            }
        }

        public void ChangeModel()
        {
            if(_isOpened)
                Close();
            else
                Open();
        }
        
        public void Open()
        {
            foreach (var detail in details)
            {
                detail.Open();
            }

            _isOpened = true;
        }
        
        public void Close()
        {
            foreach (var detail in details)
            {
                detail.Close();
            }

            _isOpened = false;
        }
        
        
    }
}