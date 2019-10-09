using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Image lives;
    public RawImage healthBar;
    public Image backgroundHealthImage;
    public int totalScraps;
    public string scraps = "Scraps: ";
    public Text scoreText;

    // private void Update()
    // {
    //     scoreText.text = scoreText + totalScraps.ToString();
    // }
}
