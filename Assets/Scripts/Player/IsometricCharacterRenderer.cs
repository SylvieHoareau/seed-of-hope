using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
{

    public static readonly string[] staticDirections = { "Static N", "Static W", "Static S", "Static E" };
    public static readonly string[] runDirections = { "Run N", "Run W", "Run S", "Run E" };

    Animator animator;
    int lastDirection;

    private void Awake()
    {
        //cache the animator component
        animator = GetComponent<animator>();
    }


    public void SetDirection(Vector2 direction) {

        //use the Run states by default
        string[] directionArray = null;

        //measure the magnitude of the input
        if (direction.magnitude < .01f)
        {
            //if we are basically standing still, we'll use the Static states
            //we won't be able to calculate a direction if the user isn't pressing one
            directionArray = staticStateHashes;
        }
        else
        {
            //we can calculate wich direction we are going in
            //use DirectionToIndex to get the index of the slice from the direction vector
            //save the answer to lastDirection
            directionArray = runStateHashes;
            lastDirection = DirectionToIndex(direction, 8);
        }

        //get the hash using the saved lastDirection
        int stateHash = directionArray[lastDirection];

        //tell the animator to play the requested state
        animator.Play(stateHash);
    }
    

    
    void Update()
    {
        
    }
}
