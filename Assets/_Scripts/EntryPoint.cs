using UnityEngine;

namespace _Scripts
{
    public class EntryPoint: MonoBehaviour
    {
        [SerializeField] private Menu menu;
        [SerializeField] private PlanetaryGearbox planetaryGearbox;
        [SerializeField] private MountingManager mountingManager;

        
        private void Start()
        {
            menu.Initialize();
            planetaryGearbox.Initialize();
            mountingManager.Initialize();
            
            menu.OnPlanetaryGearboxOpenButtonPressed += planetaryGearbox.ChangePlanetaryGearboxStatus;
            menu.OnDetailChosen += planetaryGearbox.SelectDetail;
            menu.OnPointerEnterButton +=planetaryGearbox.OutlineDetail;
            menu.OnPointerExitButton +=planetaryGearbox.DeOutlineDetail;
            menu.OnToggleSwitched += mountingManager.ChangeMountingVisible;
            menu.OnLinesStatusChanges += mountingManager.ChangeLinesStatus;
        }
    }
}