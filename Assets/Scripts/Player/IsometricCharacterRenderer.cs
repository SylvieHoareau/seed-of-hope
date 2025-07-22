using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
{
    public static readonly string[] staticDirections = { "Static N", "Static W", "Static S", "Static E" };
    public static readonly string[] runDirections = { "Run N", "Run W", "Run S", "Run E" };

    Animator animator;
    int lastDirection;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;

        if (direction.magnitude < .01f)
        {
            directionArray = staticDirections;
        }
        else
        {
            directionArray = runDirections;
            lastDirection = DirectionToIndex(direction, 4); 
        }

        string animationName = directionArray[lastDirection];
        animator.Play(Animator.StringToHash(animationName));
    }

    int DirectionToIndex(Vector2 direction, int sliceCount)
    {
        Vector2 normDirection = direction.normalized;
        float step = 360f / sliceCount;
        float angle = Vector2.SignedAngle(Vector2.up, normDirection);
        angle += step / 2f;

        if (angle < 0)
            angle += 360;

        return Mathf.FloorToInt(angle / step);
    }

    void Update()
    {
        
    }
}
