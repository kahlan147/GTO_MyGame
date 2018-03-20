using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {

    public Slider P1ChargeBar;
    public Slider P2ChargeBar;
    public RawImage ChargebarNotifier;

    private int AmountOfCharges = 8;

    private bool[] P1Charges;
    private bool[] P2Charges;

    private float P1Charge = 0;
    private float P2Charge = 0;

    // Use this for initialization
    void Start () {
        P1Charges = new bool[AmountOfCharges];
        P2Charges = new bool[AmountOfCharges];

        for (int x = 1; x < AmountOfCharges; x++)
        {
            float location = -120f + (240f / AmountOfCharges * x);
            RawImage image1 = Instantiate(ChargebarNotifier, P1ChargeBar.transform);
            RawImage image2 = Instantiate(ChargebarNotifier, P2ChargeBar.transform);
            image1.transform.position = P1ChargeBar.transform.position + new Vector3(location, 0, 0);
            image2.transform.position = P2ChargeBar.transform.position + new Vector3(location, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update (){
        Charge(ref P1ChargeBar, ref P1Charges, ref P1Charge, 0.17f);
        Charge(ref P2ChargeBar, ref P2Charges, ref P2Charge, 0.1f);
    }

    private void Charge(ref Slider ChargeBar, ref bool[] Charges, ref float Charge, float ChargeSpeed)
    {
        if (Charge < 1)
        {
            Charge += ChargeSpeed * Time.deltaTime;
            if (Charge > 1)
            {
                Charge = 1;
            }
            ChargeBar.value = Charge;

            CalcCharges(Charge, Charges);
        }
    }

    private void CalcCharges(float currentCharge, bool[] Charges)
    {
        int amount = numberOfBarsCharged(Charges);        
        if (currentCharge >= (1.0f / AmountOfCharges) * amount + (1.0f / AmountOfCharges))
        {
            if (amount < Charges.Length) //neccesary to avoid array out of bounds exception
            {
                Charges[amount] = true;
            }
        }
    }

    private int numberOfBarsCharged(bool[] Charges) {
        int amount = 0;
        foreach (bool check in Charges)
        {
            if (check)
            {
                amount++;
            }
        }
        return amount;

    }

    public void P1Attack()
    {
        
    }

    public void P2Attack()
    {

    }
}
