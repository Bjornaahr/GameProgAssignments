using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollution : MonoBehaviour
{


    ParticleSystem _ps;
    ParticleSystem.MainModule _main;
    ParticleSystem.EmissionModule _emission;
    GameObject worldMap;
    MapZone[] _mapZones;


    float _pollution;
    // Start is called before the first frame update
    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        _mapZones = GameObject.FindGameObjectWithTag("Map").GetComponentsInChildren<MapZone>();
        _main = _ps.main;
        _emission = _ps.emission;
    }

    // Update is called once per frame
    void Update()
    {   
        _pollution = 0;
        // Increases the amount of particles released over time depending on global pollution levels
        foreach (MapZone mapZone in _mapZones)
        {
            _pollution += mapZone.getPollution();
        }
        _emission.rateOverTime = _pollution;

        // Changes color of particles from invisible and white to black depening on pollution levels
        // Normalized to a range of 2k
        int maxP = (int)(_pollution * 10);
        if (maxP < 500000)
        {
            _main.maxParticles = maxP;
        }else
        {
            _main.maxParticles = 500000;
        }
        float scaledPollution = (_pollution - 0) / ( 2000-0);
        _main.startColor = new Color(1 - scaledPollution, 1 - scaledPollution, 1 - scaledPollution, scaledPollution);
            
            
        
        _pollution = 0;
    }
}
