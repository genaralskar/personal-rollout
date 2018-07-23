using UnityEngine;
using System.Collections;
public class RotateTowards : MonoBehaviour
{
    // The target marker.
    public Transform target;

    public StoreTransform playerTransform;
    // Angular speed in radians per sec.
    public float speed;

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
        transform.rotation = Quaternion.LookRotation(newDir);
        yield return new WaitForSeconds(.01f);
    }
}
}