using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class AppManager: MonoBehaviour
    {
        [SerializeField] Menu menu;
        [SerializeField] PlanetaryGearbox planetaryGearbox;
        [SerializeField] ButtonsController buttons;
        public MountingManager mountingManager;

        
        private void Start()
        {
            menu.OnPlanetaryGearboxOpenButtonPressed += ChangeModelStatus;
            menu.OnDetailChosen += SelectDetail;
            menu.OnPointerEnterButton +=planetaryGearbox.OutlineDetail;
            menu.OnPointerExitButton +=planetaryGearbox.DeOutlineDetail;
            menu.OnToggleSwitched += mountingManager.ChangeMountingVisible;
            menu.OnLinesStatusChanges += mountingManager.ChangeLinesStatus;
        }

        private void ChangeModelStatus()
        {
            if(planetaryGearbox.IsOpened)
                planetaryGearbox.Close();
            else
                planetaryGearbox.Open();
        }
        
        private void SelectDetail(DetailType detailType)
        {
            planetaryGearbox.SelectDetail(detailType);
        }
        
        
    }
}