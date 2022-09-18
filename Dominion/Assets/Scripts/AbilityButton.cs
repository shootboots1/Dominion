using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    public enum ButtonAbility
    {
        Duplicate,
        Dismantle,
        Enlarge,
        Rush,
        CellRush
    }
    public AbilityManager abilityManager;

    public ButtonAbility buttonAbility;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCurrentAbility()
    {
        if(buttonAbility == ButtonAbility.Duplicate)
        {
            abilityManager.currentAbility = CurrentAbility.Duplicate;
        }
        if (buttonAbility == ButtonAbility.Dismantle)
        {
            abilityManager.currentAbility = CurrentAbility.Dismantle;
        }
        if (buttonAbility == ButtonAbility.Enlarge)
        {
            abilityManager.currentAbility = CurrentAbility.Enlarge;
        }
        if (buttonAbility == ButtonAbility.Rush)
        {
            abilityManager.currentAbility = CurrentAbility.Rush;
        }
        if (buttonAbility == ButtonAbility.CellRush)
        {
            abilityManager.currentAbility = CurrentAbility.CellRush;
        }
    }

}
