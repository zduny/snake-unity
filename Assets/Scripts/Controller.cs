using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class Controller : MonoBehaviour {
    /// <summary>
    /// Last direction that was in the queue.
    /// </summary>
    private IntVector2 lastDirection;

    /// <summary>
    /// Queue of direction change commands.
    /// </summary>
    public Queue<IntVector2> queue;

    /// <summary>
    /// Specyfies snake's current moving direction.
    /// </summary>
    public IntVector2 LastDirection
    {
        get
        {
            if (queue.Count == 0)
                return lastDirection;

            return queue.Last();
        }
    }

	// Use this for initialization
	void Start () {
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up") && LastDirection != Vector2.down)
        {
            queue.Enqueue(Vector2.up);
        }

        if (Input.GetKeyDown("down") && LastDirection != Vector2.up)
        {
            queue.Enqueue(Vector2.down);
        }

        if (Input.GetKeyDown("left") && LastDirection != Vector2.right)
        {
            queue.Enqueue(Vector2.left);
        }

        if (Input.GetKeyDown("right") && LastDirection != Vector2.left)
        {
            queue.Enqueue(Vector2.right);
        }
    }

    /// <summary>
    /// Gets next direction and removes it from the command queue.
    /// </summary>
    /// <returns></returns>
    public IntVector2 NextDirection()
    {
        if (queue.Count == 0)
            return lastDirection;

        lastDirection = queue.Dequeue();
        return lastDirection;
    }

    /// <summary>
    /// Resets the controller.
    /// </summary>
    public void Reset()
    {
        queue = new Queue<IntVector2>();
        queue.Enqueue(Vector2.up);
        lastDirection = Vector2.up;
    }
}
