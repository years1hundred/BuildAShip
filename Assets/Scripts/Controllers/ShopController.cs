using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using LD45Jam;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class ShopController : MonoBehaviour
{
    public Player player;
    
    //Stats text
    public Text curHealth;
    public Text curArmor;
    public Text curShield;
    public Text curRechargeRate;
    public Text curMove;
    public Text curTurn;

    //Purchase Button Text
    public Text health;
    public Text armor;
    public Text shieldRecharge;
    public Text move;
    public Text turn;
    public Text repair;
   
    //Stat Modifiers (on Shop Canvas)
    public int healthModifer;
    public int armorModifier;
    public int shieldModifier;
    public int moveModifier;
    public int turnModifier;

    public int upgradeCost;

    public int repairCost;
    // Update is called once per frame
    void Awake()
    {
        SetButtonText();
        RefreshStats();
    }

    private void RefreshStats()
    {
        curHealth.text = "Health: " + player.Health;
        curArmor.text = "Damage Reduction: " + player.Armor;
        curShield.text = "Shield: " + player.Shields;
        curRechargeRate.text = "Shield Recharge Rate: " + player.ShieldRechargeSpeed;
        curMove.text = "Move Speed: " + player.MoveSpeed;
        curTurn.text = "Turn Speed: " + player.TurnSpeed;
    }

    private void SetButtonText()
    {
        health.text = "+ " + healthModifer + " Health";
        armor.text = "+ " + armorModifier + " Damage Reduction";
        shieldRecharge.text = "- " + shieldModifier + " Shield Recharge Time";
        move.text = "+ " + moveModifier + " Move Speed";
        turn.text = "+ " + turnModifier + " Turn Speed";
        repair.text = "- " + repairCost + " to repair fully";
    }

    public void PurchaseHealth()
    {
        if (player.Scrap < upgradeCost) return;
        player.Scrap -= upgradeCost;
        player.HealthBase += healthModifer;
        RefreshStats();
    }

    public void PurchaseArmor()
    {
        if (player.Scrap < upgradeCost) return;
        player.Scrap -= upgradeCost;
        player.ArmorBase += armorModifier;
        RefreshStats();
    }

    public void PurchaseShield()
    {
        if (player.Scrap < upgradeCost) return;
        player.Scrap -= upgradeCost;
        player.ShieldBase += shieldModifier;
        RefreshStats();
    }

    public void PurchaseMove()
    {
        if (player.Scrap < upgradeCost) return;
        player.Scrap -= upgradeCost;
        player.MoveSpeedBase += moveModifier;
        RefreshStats();
    }

    public void PurchaseTurn()
    {
        if (player.Scrap < upgradeCost) return;
        player.Scrap -= upgradeCost;
        player.TurnSpeedBase += turnModifier;
        RefreshStats();
    }

    public void PurchaseRepair()
    {
        if (player.Scrap < repairCost) return;
        if(player)
        player.Scrap -= repairCost;
        player.Health += repairCost;

    }
}