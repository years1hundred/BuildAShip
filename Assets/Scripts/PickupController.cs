using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public GameObject wings;
    public GameObject thruster;
    public GameObject weapon;

    public GameObject[] wingsList;
    public GameObject[] thrusterList;
    public GameObject[] weaponList;

    public string mostRecentPart;


    public void Awake()
    {
        wings.SetActive(false);
        thruster.SetActive(false);
        weapon.SetActive(false);
    }


    public void OnTriggerEnter(Collider other)
    {
        string partName = other.name;

        if (other.tag == "Wings")
        {
            EquipWings(partName);
        }
        else if (other.tag == "Thruster")
        {
            EquipThruster(partName);
        }
        else if (other.tag == "Weapon")
        {
            EquipWeapon(partName);
        }
    }


    public void EquipWeapon(string partName)
    {
        if (weapon.activeInHierarchy == false)
        {
            weapon.SetActive(true);
            DeactiveListComponents(weaponList);

            if (partName == "BurstCannon")
            {
                weaponList[0].SetActive(true);
            }
            else if (partName == "Interim_Cannon")
            {
                weaponList[1].SetActive(true);
            }
            else if (partName == "Interim_FlakCannons")
            {
                weaponList[2].SetActive(true);
            }
            else if (partName == "Interim_HeldBeamCannon")
            {
                weaponList[3].SetActive(true);
            }
            else if (partName == "Multicannon")
            {
                weaponList[4].SetActive(true);
            }
            else if (partName == "PulseCannon")
            {
                weaponList[5].SetActive(true);
            }
        }
        else
        {
            mostRecentPart = partName;
        }
    }

    
    public void EquipThruster(string partName)
    {
        if (thruster.activeInHierarchy == false)
        {
            thruster.SetActive(true);
            DeactiveListComponents(thrusterList);

            if (partName == "Thruster_LowSpeed")
            {
                thrusterList[0].SetActive(true);
            }
            else if (partName == "Thruster_MidSpeed")
            {
                thrusterList[1].SetActive(true);
            }
            else if (partName == "Thruster_HighSpeed")
            {
                thrusterList[2].SetActive(true);
            }
        }
        else
        {
            mostRecentPart = partName;
        }
    }


    public void EquipWings(string partName)
    {
        if (wings.activeInHierarchy == false)
        {
            wings.SetActive(true);
            DeactiveListComponents(wingsList);

            if (partName == "PlayerWing_LowTurnSpeed")
            {
                wingsList[0].SetActive(true);
            }
            else if (partName == "PlayerWing_MediumTurnSpeed")
            {
                wingsList[1].SetActive(true);
            }
            else if (partName == "PlayerWing_HighTurnSpeed")
            {
                wingsList[2].SetActive(true);
            }
        }
        else
        {
            mostRecentPart = partName;
        }
    }


    public void DeactiveListComponents(GameObject[] list)
    {
        for (int i = 0; i <= list.Length; ++i)
        {
            if (list[i].activeSelf == true)
            {
                list[i].SetActive(false);
            }
        }
    }
}
