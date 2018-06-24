using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {
    
    public Text countText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            AddToCount();
            Destroy(gameObject);
        }
    }

    void AddToCount()
    {
        int count = int.Parse(countText.text);
        count += 1;
        countText.text = "" + count;
    }
}