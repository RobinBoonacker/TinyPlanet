using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenBuyer : MonoBehaviour {

    public GameObject chickenPrefab;
    public GameObject chickenFolder;
    public Text countText;
    public GameObject batteryPrefab;
    public LayerMask mask;
    public int chickenCost;

    private bool CanBuyChicken;
    private Vector3 Spawn;

    private void Update()
    {
        if (Input.GetKeyDown("e") && this.CanBuyChicken)
        {
            int count = int.Parse(countText.text);
            if (count >= chickenCost)
            {
                count -= chickenCost;
                countText.text = "" + count;
                SpawnChicken();
            }
        }
    }

    public void SetAbleToBuy(bool state, Vector3 spawn)
    {
        CanBuyChicken = state;
        this.Spawn = spawn;
    }

    void SpawnChicken()
    {
        GameObject clone = Instantiate(chickenPrefab, Spawn, Quaternion.identity);
        clone.transform.parent = chickenFolder.transform;
        clone.layer = mask;

        clone.transform.position = Spawn;
        clone.transform.localScale = new Vector3(45f, 45f, 45f);
        clone.transform.localEulerAngles = new Vector3(0, 0, 0);
        clone.name = "Chicken";

        SphereCollider sphereCollider = clone.AddComponent<SphereCollider>() as SphereCollider;
        Rigidbody rigidBody = clone.AddComponent<Rigidbody>() as Rigidbody;
        rigidBody.useGravity = false;
        GravityBody gravityBody = clone.AddComponent<GravityBody>() as GravityBody;
        gravityBody.fixRotation = true;
        WanderAround wanderAround = clone.AddComponent<WanderAround>() as WanderAround;
        wanderAround.speed = 2f;
        wanderAround.rotation = 3f;
        wanderAround.maxRotation = 10f;

        GameObject batterySpawner = Instantiate(new GameObject(), new Vector3(0f, 0f, 0f), Quaternion.identity);
        batterySpawner.transform.parent = clone.transform;
        batterySpawner.name = "BatterySpawner";

        batterySpawner.transform.localPosition = new Vector3(0f, 0f, 0f);
        batterySpawner.transform.localScale = new Vector3(1f, 1f, 1f);
        batterySpawner.transform.localEulerAngles = new Vector3(0, 0, 0);

        BatterySource batterySource = batterySpawner.AddComponent<BatterySource>() as BatterySource;
        batterySource.countText = countText;
        batterySource.batteryPrefab = batteryPrefab;
        batterySource.batteryScaleX = 2f;
        batterySource.batteryScaleY = 4.5f;
        batterySource.batteryScaleZ = 2f;
        batterySource.batteryTriggerScaleX = 0.4f;
        batterySource.batteryTriggerScaleY = 0.2f;
        batterySource.batteryTriggerScaleZ = 0.4f;
        batterySource.speed = 2f;
        batterySource.velocity = 0.5f;
        batterySource.layingPercentage = 0.4f;
    }
}
