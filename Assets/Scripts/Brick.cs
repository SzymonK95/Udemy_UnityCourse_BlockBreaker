using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] HitSprites;
    public static int BreakableCount = 0;

    private int _maxHits;
    private int _timesHit;
    private LevelManager _levelManager;
    private bool _isBreakable;

    // Use this for initialization
    void Start ()
	{
	    _timesHit = 0;
	    _maxHits = HitSprites.Length + 1;

	    _isBreakable = (this.tag == "Breakable");
	    if (_isBreakable)
	    {
	        BreakableCount++;
	    }

        _levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision2D)
    { 
        AudioSource.PlayClipAtPoint(crack,transform.position);
        if (_isBreakable)
        {
            HandleHits();
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }

    private void HandleHits()
    {
        _timesHit++;

        if (_timesHit >= _maxHits)
        {
            BreakableCount--;
            _levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = _timesHit - 1;

        if (HitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
        }
    }
}
