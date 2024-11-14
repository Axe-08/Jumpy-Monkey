using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlatformControl : BasePlatform
{
    Vector2 portalOnePosition;
    Vector2 portalTwoPosition;
    GameObject portalOne;
    GameObject portalTwo;
    protected override void Start()
    {
        portalOne = GameObject.Find("Entry");
        portalTwo = GameObject.Find("Exit");
        portalOnePosition = portalOne.transform.position;
        portalTwoPosition = portalTwo.transform.position;
        PortalEntanglement();
        AssignPosition(portalOnePosition, new Vector2(Random.Range(-3f,3f),portalOnePosition.y+Random.Range(1f,4f)));
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
    public void AssignPosition(Vector2 entryPosition,Vector2 exitPosition)
    {
        portalOne.transform.position = entryPosition;
        portalTwo.transform.position = exitPosition;
        portalOnePosition = entryPosition;
        portalTwoPosition = exitPosition;
        EntangleTeleportPosition();
    }

    void PortalEntanglement()
    {
        portalOne.GetComponent<PortalScript>().EntangledPortal = portalTwo;
        portalTwo.GetComponent<PortalScript>().EntangledPortal = portalOne;

    }

    void EntangleTeleportPosition()
    {
        portalOne.GetComponent<PortalScript>().targetCoordinate = portalTwoPosition;
        portalTwo.GetComponent<PortalScript>().targetCoordinate= portalOnePosition;
    }
}
