using System;
using UnityEngine;

namespace _Scripts
{
    public class PlanetaryGearbox: MonoBehaviour
    {
        public CameraRotation cameraRotation;
        
        [SerializeField] Detail[] details;

        public bool IsOpened { get; private set; }

        private Detail[] _details;

        
        private void Start()
        {
            IsOpened = false;
            foreach (var detail in details)
            {
                detail.Initialize();
                detail.OutlineOff();
            }
        }

        public void ChangePlanetaryGearboxStatus()
        {
            if(IsOpened)
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

            IsOpened = true;
        }
        
        public void Close()
        {
            foreach (var detail in details)
            {
                detail.Close();
            }

            IsOpened = false;
        }

        public void SelectDetail(DetailType detailType)
        {
            var activeDetail = Array.Find(details, x => x.detailType == detailType);
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

        public void HideDetails()
        {
            foreach (var detail in details)
                detail.Hide();
        }

        public void ShowDetails()
        {
            foreach (var detail in details)
                detail.Show();
        }
        
        public void OutlineDetail(DetailType detailType)
        {
            var activeDetail = Array.Find(details, x => x.detailType == detailType);
            activeDetail.OutlineOn();
        }

        public void DeOutlineDetail(DetailType detailType)
        {
            var activeDetail = Array.Find(details, x => x.detailType == detailType);
            activeDetail.OutlineOff();
        }
    }
}