using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
	public bool alive = false;
	public bool nextAlive;
	bool prevAlive;
	public int x = -1;
	public int y = -1;
    public Texture[] textures;
    public Renderer renderer;

	// Start is called before the first frame update
	void Start()
    {
		prevAlive = alive;
	}

    // Update is called once per frame
    void Update()
    {
		if (prevAlive != alive) {
			updateColor();
		}

		prevAlive = alive;
	}

	public void updateColor()
	{
		if (renderer == null) {
			renderer = gameObject.GetComponent<Renderer>();
		}

		if (this.alive) {
			renderer.material.color = Color.magenta;
            gameObject.transform.localScale = new Vector3(3.3f, 7.3f, 3.3f);
        } else {
			renderer.material.color = Color.yellow;
            gameObject.transform.localScale = new Vector3(3.3f, 3.3f, 3.3f);
        }
	}


	private void OnMouseDown()
	{
		alive = !alive;
	}
}
