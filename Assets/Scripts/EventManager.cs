using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


[System.Serializable] public class UnityEventInt : UnityEvent<int> {}

public class EventManager : MonoBehaviour
{

    PlayerManager playerManager;
    [SerializeField]
    MapZone mapZone;
    public UnityEventInt buyOilField;
    public UnityEventInt buyCoalMine;
    public UnityEventInt buyLoggingCamp;
    public UnityEventInt buyWasteDumpingSite;
    public UnityEventInt oilFieldEmpty;
    public UnityEventInt coalMineEmpty;
    public UnityEventInt rainforestEmpty; // pepehands
    public UnityEventInt buyLobbyingPower;


    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }


    public void BuyOilField()
    {
        if(playerManager.getMoney() >= mapZone.getOilFieldPrice() && mapZone.getPoliticalResistance() <= mapZone.getLobbyingPower())
            buyOilField.Invoke(mapZone.getOilFieldPrice());
    }

    public void BuyCoalMine()
    {
        if (playerManager.getMoney() >= mapZone.getCoalMinePrice() && mapZone.getPoliticalResistance() <= mapZone.getLobbyingPower())
            buyCoalMine.Invoke(mapZone.getCoalMinePrice());
    }


    public void BuyLoggingCamp()
    {
        if (playerManager.getMoney() >= mapZone.getLoggingCampPrice() && mapZone.getPoliticalResistance() <= mapZone.getLobbyingPower())
            buyLoggingCamp.Invoke(mapZone.getLoggingCampPrice());
    }


    public void BuyWasteDumpingSite()
    {
        if (playerManager.getMoney() >= mapZone.getWasteDumpingGroundPrice() && mapZone.getPoliticalResistance() <= mapZone.getLobbyingPower())
            buyWasteDumpingSite.Invoke(mapZone.getWasteDumpingGroundPrice());
    }

    public void BuyLobbingPower()
    {
        if (playerManager.getMoney() >= mapZone.getLobbyingPrice())
            buyLobbyingPower.Invoke(mapZone.getLobbyingPrice());
    }

    //Set the new zone that is selected
    public void SetMapZone(MapZone newZone)
    {
        buyOilField.RemoveListener(mapZone.buyOilField);
        buyCoalMine.RemoveListener(mapZone.buyCoalMine);
        buyLoggingCamp.RemoveListener(mapZone.buyLoggingSite);
        buyLobbyingPower.RemoveListener(mapZone.buyLobbyingPower);
        buyWasteDumpingSite.RemoveListener(mapZone.buyWasteDump);

        mapZone = newZone;

        buyOilField.AddListener(newZone.buyOilField);
        buyCoalMine.AddListener(newZone.buyCoalMine);
        buyLoggingCamp.AddListener(newZone.buyLoggingSite);
        buyWasteDumpingSite.AddListener(newZone.buyWasteDump);
        buyLobbyingPower.AddListener(newZone.buyLobbyingPower);
    }

    public MapZone GetMapZone()
    {
        return mapZone;
    }

}
