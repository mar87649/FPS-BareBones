using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : UnitScript
{
    private List<GameObject> abilityList = new List<GameObject>();
    public override void Start()
    {
        base.Start();

        abilityList.Add(MovementAblitity);
        abilityList.Add(OffenceAblitity);
        abilityList.Add(DefenceAblitity);
        abilityList.Add(HealingAblitity);
        abilityList.Add(UntimateAblitity);

        SetAbilities();
    }
    private void SetAbilities()
    {
        if (MovementAblitity != null)
        {
            GameObject temp = Instantiate(MovementAblitity, transform.Find("Abilities"));
            MovementAblitity = temp;
            MovementAblitity.GetComponent<Ability>().User = transform.gameObject;
        }
        if (OffenceAblitity != null)
        {
            GameObject temp = Instantiate(OffenceAblitity, transform.Find("Abilities"));
            OffenceAblitity = temp;
            OffenceAblitity.GetComponent<Ability>().User = transform.gameObject;
        }
        if (HealingAblitity != null)
        {
            GameObject temp = Instantiate(HealingAblitity, transform.Find("Abilities"));
            HealingAblitity = temp;
            HealingAblitity.GetComponent<Ability>().User = transform.gameObject;
        }
    }
    public override GameObject InitWeapon(GameObject _weapon)
    {
        base.InitWeapon(_weapon);
        Weapon.GetComponent<Weapon>().POV = PointOfViewObject;
        return Weapon;
    }

    public override void Die()
    {
        Debug.Log("Play death animation");        
        GameManager.Instance.GameOverLogic();
    }


}