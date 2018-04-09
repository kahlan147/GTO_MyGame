using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBarManager : MonoBehaviour {

    public GameObject AttackBar;

    public Attack attack;
    private List<GameObject> AttackBars;
    private List<Attack> attacks;
    private int ApUsed = 0;
    private int MaxAp = 8;

	// Use this for initialization
	void Start () {
        AttackBars = new List<GameObject>();
        attacks = new List<Attack>();
        for (int x = 0; x < MaxAp; x++)
        {
            AddAttack(attack);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddAttack(Attack attack)
    {
        if (ApUsed < MaxAp && (ApUsed + attack.APCost) <= MaxAp)
        {
            GameObject attackBarUI = Instantiate(AttackBar, this.transform);
            RectTransform attackBarRT = attackBarUI.GetComponent<RectTransform>();
            attackBarRT.anchoredPosition = CalcLocation(attack.APCost);
            AttackBars.Add(attackBarUI);
            attackBarUI.GetComponent<Text>().text = attack.AttackName;
            attackBarRT.sizeDelta = new Vector2(attackBarRT.rect.width * attack.APCost, attackBarRT.rect.height);
            attacks.Add(attack);
            ApUsed += attack.APCost;

        }
    }

    public void RemoveAttack()
    {
        if (attacks.Count > 0)
        {
            int location = attacks.Count - 1;
            Attack toBeRemovedAttack = attacks[location];
            ApUsed -= toBeRemovedAttack.APCost;
            attacks.RemoveAt(location);
            GameObject attackBarUI = AttackBars[location];
            AttackBars.RemoveAt(location);
            Destroy(attackBarUI);

            //working on
        }
    }

    private Vector3 CalcLocation(int ApCost)
    {
        float x = -160 + (46 * ApUsed) + 22.8f * (ApCost-1);
        
        return new Vector3(x, 0, 0);
    }
}
