using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : MonoBehaviour
{

    [SerializeField]
    float oil, rainforest, coal, naturalGas, toxicWasteDumped;
    [SerializeField]
    bool wasteDumping = true;

    [SerializeField]
    float politicalResistance;
    [SerializeField]
    float lobbyingPower;

    [SerializeField]
    int oilWells, loggingSites, coalMines, dumpingFacilities;

    [SerializeField]
    float co2Zone;

    [SerializeField]
    float co2Modifier;

    EventManager eventManager;

    [SerializeField]
    int oilFieldPrice, loggingCampPrice, coalMinePrice, wasteDumpingSitePrice, lobbyingPrice, lobbyingPriceStep;


    void Start()
    {
        eventManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<EventManager>();
        politicalResistance = 0.01f;
        lobbyingPower = 1f;
        oilFieldPrice = 250;
        loggingCampPrice = 250;
        coalMinePrice = 250;
        wasteDumpingSitePrice = 500;
        lobbyingPriceStep = 500;
    }


    void Update()
    {
        
            if (oil >= 0 && oilWells > 0)
            {
                PumpOil();
            }
            else if (oilWells > 0 && naturalGas <= 0 && oil <= 0)
            {
                eventManager.oilFieldEmpty.Invoke(oilWells);
                oilWells = 0;
            }
            if (rainforest >= 0 && loggingSites > 0 && politicalResistance <= lobbyingPower)
            {
                Deforestation();
            }
            else if (loggingSites > 0)
            {
                eventManager.rainforestEmpty.Invoke(loggingSites);
                loggingSites = 0;
            }
            if (coal >= 0 && coalMines > 0)
            {
                MineCoal();
            }
            else if (coalMines > 0)
            {
                eventManager.coalMineEmpty.Invoke(coalMines);
                coalMines = 0;
            }
            if (naturalGas >= 0)
                PumpNaturalGas();

       
            if (wasteDumping && politicalResistance <= lobbyingPower)
                DumpToxicWaste();

        if (politicalResistance >= lobbyingPower)
            wasteDumping = false;
        else
            wasteDumping = true;


    }


    void PumpOil()
    {
        oil -= 0.2f * oilWells;
        co2Zone += co2Modifier * oilWells * 0.0005f;
    }

    void Deforestation()
    {
        rainforest -= 0.1f * loggingSites;
        co2Modifier += 0.00000001f * loggingSites;
        politicalResistance += 0.0001f * loggingSites;
    }

    void MineCoal()
    {
        coal -= 0.3f * coalMines;
        co2Zone += co2Modifier * coalMines * 0.0008f;
    }

    void PumpNaturalGas()
    {
        naturalGas -= 0.1f * oilWells;
        co2Zone += co2Modifier * oilWells * 0.0001f;
    }

    void DumpToxicWaste()
    {
        toxicWasteDumped += dumpingFacilities * 0.03f;
        co2Modifier += 0.000001f * dumpingFacilities;
        politicalResistance += 0.01f * dumpingFacilities;
    }

    public void buyOilField(int arg)
    {
        if(politicalResistance <= lobbyingPower)
            oilWells++;
    }

    public void buyCoalMine(int arg)
    {
        if (politicalResistance <= lobbyingPower)
            coalMines++;
    }

    public void buyWasteDump(int arg)
    {
        if (politicalResistance <= lobbyingPower)
            dumpingFacilities++;
    }

    public void buyLoggingSite(int arg)
    {
        if (politicalResistance <= lobbyingPower)
            loggingSites++;
    }

    public void buyLobbyingPower(int arg)
    {
        lobbyingPrice += lobbyingPriceStep;
        lobbyingPower += 50;
    }


    public void requestWasteDumping()
    {
        if(politicalResistance < lobbyingPower)
        {
            wasteDumping = true;
        }
    }

    public int getOilFieldPrice()
    {
        return oilFieldPrice;
    }

    public int getCoalMinePrice()
    {
        return coalMinePrice;
    }
    public int getLoggingCampPrice()
    {
        return loggingCampPrice;
    }
    public int getWasteDumpingGroundPrice()
    {
        return wasteDumpingSitePrice;
    }
    public int getLobbyingPrice()
    {
        return lobbyingPrice;
    }

    public void SelectZone()
    {
        eventManager.SetMapZone(this);
    }


    public int getOilFields()
    {
        return oilWells;
    }

    public int getCoalMines()
    {
        return coalMines;
    }

    public int getLoggingCamps()
    {
        return loggingSites;
    }

    public int getDumpingGrounds()
    {
        return dumpingFacilities;
    }

    public float getPollution()
    {
        return co2Zone;
    }

    public float getLobbyingPower()
    {
        return lobbyingPower;
    }

    public float getPoliticalResistance()
    {
        return politicalResistance;
    }

    public float getOil()
    {
        return oil;
    }

    public float getCoal()
    {
        return coal;
    }

    public float getForest()
    {
        return rainforest;
    }

    public float getGas()
    {
        return naturalGas;
    }


}
