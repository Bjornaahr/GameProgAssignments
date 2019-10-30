using System.Collections;
using System.Collections.Generic;
using UnityEngine.Diagnostics;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    private static UIManager instance;
    private static UIManager Instance { get { return instance; } }

    PlayerManager playerManager;
    EventManager eventManager;
    MapZone[] mapZones;
    [SerializeField]
    GameObject worldMap;
    [SerializeField]
    TextMeshProUGUI money, zoneName, oilFields, coalMines, loggingCamps, dumpingSites, totalPollution;
    [SerializeField]
    TextMeshProUGUI lobbyPower, politicalResistance, oil, coal, forest, gas;

    [SerializeField]
    float pollution;


    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        eventManager = GetComponent<EventManager>();
        mapZones = worldMap.GetComponentsInChildren<MapZone>();
    }

    // Update is called once per frame
    void Update()
    {
        MapZone mapZone = eventManager.GetMapZone();

        money.text = "Money: " + playerManager.getMoney() + "$";
        zoneName.text = mapZone.gameObject.name;
        oilFields.text = "Oil Fields: " + mapZone.getOilFields().ToString();
        coalMines.text = "Coal Mines: " + mapZone.getCoalMines().ToString();
        loggingCamps.text = "Logging Camps: " + mapZone.getLoggingCamps().ToString();
        dumpingSites.text = "Dumping Sites: " + mapZone.getDumpingGrounds().ToString();
        foreach (MapZone mapZonee in mapZones)
            pollution += mapZonee.getPollution();

        totalPollution.text = "Pollution: " + pollution.ToString("F0");
        if (pollution > 2000)
        {
            Utils.ForceCrash(ForcedCrashCategory.FatalError);
        }
        pollution = 0;

        lobbyPower.text = "Lobby Power: " + mapZone.getLobbyingPower().ToString("F2");
        politicalResistance.text = "Political Resistance: " + mapZone.getPoliticalResistance().ToString("F2");
        oil.text = "Oil: " + mapZone.getOil().ToString("F0");
        coal.text = "Coal: " + mapZone.getCoal().ToString("F0");
        forest.text = "Trees: " + mapZone.getForest().ToString("F0");
        gas.text = "Gas: " + mapZone.getGas().ToString("F0");

      


    }

    public float getWorldPollution() 
    {
        return pollution;
    }
}
