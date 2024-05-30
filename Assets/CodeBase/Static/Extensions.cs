using UnityEngine;
using Random = UnityEngine.Random;

public static class Extensions
{
    public static void SetRandomXOnScreen(this Vector3 position)
    {
        float minX = Camera.main.ScreenToWorldPoint(Vector2.zero).x;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;

        position.x = Random.Range(minX, maxX);
    }

    public static void SetY(this Vector3 position, float yValue)
    {
        position = new Vector3(position.x, yValue, position.z);
    }
}
