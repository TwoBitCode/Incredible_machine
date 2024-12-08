using UnityEngine;
using TMPro;

public class FinalTrigger : MonoBehaviour
{
    public TextMeshProUGUI levelCompleteText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Domino"))
        {
            Debug.Log("Level 2 Complete!");
            if (levelCompleteText != null)
            {
                levelCompleteText.gameObject.SetActive(true);
            }
        }
    }
}
