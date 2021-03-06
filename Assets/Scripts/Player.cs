﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed;
    public int Health;
    public GameObject Torch;

    private Rigidbody2D rb2d;
    private static bool isInstantiated;

    public void Awake()
    {
        if (!isInstantiated)
        {
            isInstantiated = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

	// Use this for initialization
	public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}

    public void FixedUpdate()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var vert = Input.GetAxisRaw("Vertical");
        var x = hor * Time.fixedDeltaTime * Speed;
        var y = vert * Time.fixedDeltaTime * Speed;

        rb2d.velocity = new Vector2(x, y);

        HandleInput();
    }

    public void OnEnterCollision2D(BoxCollider2D other)
    {

    }

    private void HandleInput()
    {
        // torch placement
        if (Input.GetKeyDown(KeyCode.E))
        {
            var pos = new Vector3(transform.position.x, transform.position.y, Torch.transform.position.z);
            Instantiate(Torch, pos, Quaternion.identity);
        }

        // restart level
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
