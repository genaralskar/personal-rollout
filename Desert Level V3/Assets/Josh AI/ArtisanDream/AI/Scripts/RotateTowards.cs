using UnityEngine;
using System.Collections;
public class RotateTowards : MonoBehaviour
{
    // The target marker.
    public Transform target;

    public StoreTransform playerTransform;
    // Angular speed in radians per sec.
    public float speed;

    public Vector3 directionLimits;
    public float xOffset;

private void OnTriggerEnter(Collider other)
{
	StartCoroutine ("ToretRoation");
}

private void OnTriggerExit(Collider other)
{
    StopAllCoroutines();
}

  IEnumerator ToretRoation() {
    while(true){
        Vector3 targetDir = playerTransform.transform.position - transform.position;
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        
        
        newDir = new Vector3(newDir.x, 0, newDir.z);
        
//        Debug.DrawRay(transform.position, newDir, Color.red);
        // Move our position a step closer to the target.
        Quaternion newTransform = Quaternion.LookRotation(newDir);
        Vector3 newRot = newTransform.eulerAngles;
//        print("newRot = " + newRot);
        
        //print("modulo or whataver: " + -directionLimits.y % 360);
        
        newRot.x = Mathf.Clamp(newRot.x, -directionLimits.x, directionLimits.x);
        newRot.x += xOffset;
        newRot.y = Mathf.Clamp(newRot.y, -directionLimits.y, directionLimits.y);
        newRot.z = Mathf.Clamp(newRot.z, -directionLimits.z, directionLimits.z);
        
        

        //transform.rotation = Quaternion.Euler(newRot);
        transform.rotation = Quaternion.LookRotation(newDir);
        yield return new WaitForSeconds(.01f);
    }
}
}