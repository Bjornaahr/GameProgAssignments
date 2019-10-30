using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    int money = 10000;

    int totalOilFields, totalCoalMines, totalLoggingCamps, totalDumpingSites;


    void Start()
    {
        StartCoroutine(CashFlow());
    }



    public void buyOilField(int price)
    {
        money -= price;
        totalOilFields++;
    }

    public void buyCoalMine(int price)
    {
        money -= price;
        totalCoalMines++;
    }

    public void buyLoggingCamp(int price)
    {
        money -= price;
        totalLoggingCamps++;
    }

    public void buyWasteDumpingSite(int price)
    {
        money -= price;
        totalDumpingSites++;
    }
    public void buyLobbingPower(int price)
    {
        money -= price;
    }

    public int getMoney()
    {
        return money;
    }

    public void removeOilFields(int nrToRemove)
    {
        totalOilFields -= nrToRemove;
    }

    public void removeCoalMines(int nrToRemove)
    {
        totalCoalMines -= nrToRemove;
    }

    public void removeLoggingCamps(int nrToRemove)
    {
        totalLoggingCamps -= nrToRemove;
    }


    IEnumerator CashFlow()
    {
        for(; ; ) { 
            money += 10 * totalOilFields + 2 * totalCoalMines;
            
            yield return new WaitForSeconds(3f);
        }
    }

}
