using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
  public ScoreScript ScoreScriptInstance;// The ScoreScriptInstance field is of type ScoreScript and is used to keep track of the score
    public static bool WasGoal { get; private set; }// The WasGoal property is a static bool that indicates whether a goal was scored.
    private Rigidbody2D rb;//rb field is a private Rigidbody2D that represents the physics body of the puck.
 public float MaxSpeed;//to prevent puck from bouncy too much and get uncontrolably fast

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
	}

     void OnTriggerEnter2D(Collider2D other)//The OnTriggerEnter2D(Collider2D other) method is called when the puck enters a trigger collider. If a goal was not already scored (!WasGoal), it checks the tag of the other collider. If the tag is "AiGoal", it increments the player’s score using the ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore) method, sets the WasGoal property to true, and starts the ResetPuck(false) coroutine. If the tag is "PlayerGoal", it increments the AI’s score using the ScoreScriptInstance.Increment(ScoreScript.Score.AiScore) method, sets the WasGoal property to true, and starts the ResetPuck(true) coroutine
    {
        if (!WasGoal)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    private IEnumerator ResetPuck(bool didAiScore)//The ResetPuck(bool didAiScore) method is a private coroutine that takes a bool argument indicating whether the AI scored. It waits for 1 second using yield return new WaitForSecondsRealtime(1), then sets the WasGoal property to false and resets the position and velocity of the puck using the rb.position = new Vector2(0, 0) and rb.velocity = new Vector2(0, 0) statements. If the AI scored (didAiScore == true), it sets the position of the puck to (0, -1) using the rb.position = new Vector2(0, -1) statement. Otherwise, it sets the position of the puck to (0, 1) using the rb.position = new Vector2(0, 1) statement.
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);

          if (didAiScore)
            rb.position = new Vector2(0, -1);
        else
            rb.position = new Vector2(0, 1);
    }

      private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }

       public void CenterPuck()//The CenterPuck() method is a public method that sets the position of the puck to (0.32f, -0.1f) using the rb.position = new Vector2(0.32f, -0.1f) statement
    {
        rb.position = new Vector2(0.32f, -0.1f);
    }
}
//help from resocoder.com