using UnityEngine;

/// <summary>
/// http://algorithmicbotany.org/papers/abop/abop-ch4.pdf
/// </summary>
/// 
public class Phyllotaxis : MonoBehaviour
{
    public int FloretNum = 100;
    public float AngleOfDivergence = 137.5f;
    public int scale = 4;
    public float dotsize = 2;

    Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);

    int currentFloretCount = 0;
    float angle;
    float radius;
    float posX;
    float posY;

    void Update()
    {
        angle = currentFloretCount * AngleOfDivergence;
        radius = scale * Mathf.Sqrt(currentFloretCount);
        posX = radius * Mathf.Cos(angle) + center.x;
        posY = radius * Mathf.Sin(angle) + center.y;

        if (currentFloretCount < FloretNum)
        {
            currentFloretCount++;
        }
    }

    void OnGUI()
    {
        _2DExtension.SetBGColor(Color.black);

        Color32 color = Color.HSVToRGB(((angle - radius) % 255)/255, 1, 1);
        _2DExtension.DrawDot(new Vector2(posX, posY), new Vector2(dotsize, dotsize), color, Color.black);
    }
}
