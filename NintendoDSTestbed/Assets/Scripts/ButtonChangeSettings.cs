using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GGSFPSIntegrationTool.Scripts.Player;
using GGSFPSIntegrationTool.Scripts;

public class ButtonChangeSettings : MonoBehaviour
{
    public Weapon newWeapon;
    public Health newHealth;
    public PlayerHUD newHud;

    public void Heal()
    {
        newHealth.ResetHealth();
        Debug.Log("CLICKED");
    }

    public void ChangeToAuto()
    {
        newWeapon.FiringTypeProperty = Weapon.FiringType.Automatic;
    }

    public void ChangeToSemi()
    {
        newWeapon.FiringTypeProperty = Weapon.FiringType.SemiAutomatic;
    }
}
