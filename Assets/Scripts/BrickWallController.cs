using UnityEngine;

public class BrickWallController : MonoBehaviour
{
    public GameObject brickPrefab;

    [Header("Brick wall parameters")]
    public Vector3 initialBrickPosition;
    public float horizontalSpacing;
    public float verticalSpacing;
    public float columnCount;
    public float lineCount;

    void Start()
    {
        for(int line = 0; line < lineCount; line++)
        {
            for(int column = 0; column < columnCount; column++)
            {
                Vector3 newPosition = initialBrickPosition + new Vector3(column * horizontalSpacing, -line * verticalSpacing, 0);
                Instantiate(brickPrefab, newPosition, Quaternion.identity);
            }
        }
    }    
}
