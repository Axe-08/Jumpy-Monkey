using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : solidPlatform
{
    // Start is called before the first frame update
    public Vector2 targetCoordinate;
    public GameObject EntangledPortal;
    protected override void Start()
    {
        base.Start();   
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public void GlitchFixPortal()
    {
        StartCoroutine(PausePortal());
    }

    IEnumerator PausePortal()
    {
        EntangledPortal.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        EntangledPortal.GetComponent<BoxCollider2D>().enabled = true;
    }
   
}
