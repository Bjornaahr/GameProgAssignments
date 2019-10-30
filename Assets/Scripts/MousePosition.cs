using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    // Start is called before the first frame update
    private DrawColliderBounds[] _zones;
    MapZone mapZone;
    EventManager eventManager;

    void Start()
    {
        _zones = GetComponentsInChildren<DrawColliderBounds>();
        eventManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        //If something was hit, the RaycastHit2D.collider will not be null.
        if (hit.collider != null)
        {
            foreach (DrawColliderBounds zone in _zones)
            {
            //Debug.Log(hit.collider.name);
                // Changes color of zone you've select to selected color
                // Changes any other zone to not have selected color
                // Also changes selected zone to be in focus for the event manager
                if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.collider.gameObject == zone.gameObject)
                    {
                        zone._selectedB = true;
                        zone.gameObject.GetComponent<MapZone>().SelectZone();
                    } else 
                    {
                        zone._selectedB = false;
                    }
                
                // Changes color of zone you're hovering over to the hover color
                // Changes any other zone to not have hover color
                } else {
                    if (hit.collider.gameObject == zone.gameObject && ! zone._selectedB)
                    {
                        zone._hoverB = true;
                    } else 
                    {
                        zone._hoverB = false;
                    }
                
                }
            }
        }
    }
}
