using System;
using UnityEngine;

namespace _Scripts
{
    public class PlanetaryGearbox: MonoBehaviour
    {
        [SerializeField] private CameraRotation cameraRotation;
        [SerializeField] private Detail[] details;
        
        private bool _isOpened;
        
        
        public void Initialize()
        {
            _isOpened = false;
            foreach (var detail in details)
            {
                detail.Initialize();
                detail.OutlineOff();
            }
        }

        public void ChangePlanetaryGearboxStatus()
        {
            if(_isOpened)
                Close();
            else
                Open();
        }

        public void SelectDetail(DetailType detailType)
        {
            var activeDetail = Array.Find(details, x => x.DetailType == detailType);
            if (activeDetail.IsInspecting)
            {
                ShowDetails();
                activeDetail.StopInspect();
                cameraRotation.CameraOn();
            }
            else
            {
                HideDetails();
                activeDetail.StartInspect();
                cameraRotation.CameraOff();
            }
        }
        
        public void OutlineDetail(DetailType detailType)
        {
            var activeDetail = Array.Find(details, x => x.DetailType == detailType);
            activeDetail.OutlineOn();
        }

        public void DeOutlineDetail(DetailType detailType)
        {
            var activeDetail = Array.Find(details, x => x.DetailType == detailType);
            activeDetail.OutlineOff();
        }
        
        private void Open()
        {
            foreach (var detail in details)
            {
                detail.Open();
            }

            _isOpened = true;
        }
        
        private void Close()
        {
            foreach (var detail in details)
            {
                detail.Close();
            }

            _isOpened = false;
        }

        private void HideDetails()
        {
            foreach (var detail in details)
                detail.Hide();
        }

        private void ShowDetails()
        {
            foreach (var detail in details)
                detail.Show();
        }
    }
}