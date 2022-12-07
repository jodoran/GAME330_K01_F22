using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GGSFPSIntegrationTool.Scripts.Player;
using GGSFPSIntegrationTool.Scripts;
using GGSFPSIntegrationTool.Scripts.NonPlayer;

public class ButtonChangeSettings : MonoBehaviour
{
    public Weapon newWeapon;
    public Health newHealth;
    public PlayerHUD newHud;
    public NonPlayerDamageInfliction newDamage;
    Text hundred;
    public void Heal()
    {
        hundred.text = "100";
        newHud._HealthText = hundred;
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
