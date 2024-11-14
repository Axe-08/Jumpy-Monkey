using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BasePlatform : MonoBehaviour
{

    public float despawnLimit = 10f;
   
    [SerializeField] Animation decoy;
    private Vector3 startPosition;
    private Vector3 cameraPosition;
    protected bool isDecoy = false;
    protected virtual void setDecoyTrue()
    {
        isDecoy = true;   
    }

    protected virtual void setDecoyFalse()
    {
        isDecoy=false;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        startPosition = transform.position;
        cameraPosition = Camera.main.transform.position;
    }
    protected virtual void Update()
    {
        checkDestroy();
    }
    protected void checkDestroy()
    {
        cameraPosition = Camera.main.transform.position;
        if (cameraPosition.y - transform.position.y > despawnLimit)
        {
            Destroy(gameObject);
        }
    }

    protected void decoyAnim()
    {
        
    }

}
