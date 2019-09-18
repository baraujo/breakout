using UnityEngine;

public class BrickWallController : MonoBehaviour
{
    public GameObject brickPrefab;

    [Header("Brick wall parameters")]    
    public float horizontalSpacing;
    public float verticalSpacing;
    public float columnCount;
    public float lineCount;
    public int brickCount;

    private Vector3 initialBrickPosition;    

    void Start()
    {
        initialBrickPosition = transform.position;
        for(int line = 0; line < lineCount; line++)
        {
            for(int column = 0; column < columnCount; column++)
            {
                Vector3 newPosition = initialBrickPosition + new Vector3(column * horizontalSpacing, -line * verticalSpacing, 0);
                Instantiate(brickPrefab, newPosition, Quaternion.identity);
                brickCount++;
            }
        }
    }    
}
