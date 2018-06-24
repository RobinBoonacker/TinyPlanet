using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class BatterySource : MonoBehaviour {

    public Text countText;

    public float batteryScaleX = 2f;
    public float batteryScaleY = 4.5f;
    public float batteryScaleZ = 2f;

    public float batteryTriggerScaleX = 0.2f;
    public float batteryTriggerScaleY = 0.1f;
    public float batteryTriggerScaleZ = 0.2f;

    public float speed;
    public GameObject batteryPrefab;

    [Range(0f, 100f)]
    public float layingPercentage;

    public float velocity;

    Vector3 startPos;
    Vector3 startVelocity;

    void Start () {
        startPos = transform.position;
        startVelocity = transform.forward * speed;
    }
	
	void Update () {
        if (Random.Range(0, 100f) <= layingPercentage)
        {
            SpawnBattery();
        }
	}

    void SpawnBattery()
    {
        GameObject clone = Instantiate(batteryPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        clone.transform.localPosition = new Vector3(0, 0, 0);
        clone.transform.localScale = new Vector3(batteryScaleX, batteryScaleY, batteryScaleZ);
        clone.transform.localEulerAngles = new Vector3(0, 0, 0);

        clone.transform.position = transform.position;
        clone.transform.rotation = Random.rotation;
        clone.name = "LayedBattery";

        BoxCollider boxCollider = clone.AddComponent<BoxCollider>() as BoxCollider;
        Rigidbody rigidBody = clone.AddComponent<Rigidbody>() as Rigidbody;
        rigidBody.useGravity = false;
        rigidBody.velocity = new Vector3(Random.Range(-velocity, velocity), 2, Random.Range(-velocity, velocity));
        GravityBody gravityBody = clone.AddComponent<GravityBody>() as GravityBody;
        Pickable pickable = clone.AddComponent<Pickable>() as Pickable;
        pickable.countText = countText;
        BoxCollider triggerCollider = clone.AddComponent<BoxCollider>() as BoxCollider;
        triggerCollider.isTrigger = true;
        triggerCollider.size = new Vector3(batteryTriggerScaleX, batteryTriggerScaleY, batteryTriggerScaleZ);

        // Negate the constraints set by the GravityBody component.
        gravityBody.fixRotation = false;
        rigidBody.constraints = RigidbodyConstraints.None;
    }
}