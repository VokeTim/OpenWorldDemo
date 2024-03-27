using UnityEngine;

[ExecuteInEditMode]
public class DrawTool : MonoBehaviour
{
    public Color circleColor = Color.red;

    public float radius = 5.0f;

    public int segments = 360;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = circleColor;

        Vector3 position = transform.position;

        float angleSize = 360.0f / segments;
        for (int i = 0; i < segments; i++) 
        {
            float angle1 = angleSize * i;
            float angle2 = angleSize * (i + 1);

            Vector3 pos1 = position + Quaternion.Euler(0, angle1, 0) * Vector3.right * radius;
            Vector3 pos2 = position + Quaternion.Euler(0, angle2, 0) * Vector3.right * radius;

            Gizmos.DrawLine(pos1, pos2);
        }
    }
}
