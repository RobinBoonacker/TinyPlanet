using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenShop : MonoBehaviour {

    public Text countText;
    public Text promptText;
    public GameObject buyer;
    public GameObject spawn;
    
	void Start () {
	}
	
	void Update () {
	}

    private void OnMouseEnter()
    {
        promptText.color = new Color(1f, 1f, 1f, 1f);
        buyer.GetComponent<ChickenBuyer>().SetAbleToBuy(true, this.spawn.transform.position);
    }

    private void OnMouseExit()
    {
        promptText.color = new Color(1f, 1f, 1f, 0f);
        buyer.GetComponent<ChickenBuyer>().SetAbleToBuy(false, this.spawn.transform.position);
    }
}
