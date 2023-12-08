using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string suit;
    public int rank;
    public bool isFaceUp;
    public void Init()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = name;
    }
}
