using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroll : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private float scroll_speed;
    private MeshRenderer mesh_render;
	void Awake () {
        scroll_speed = 0.1f;
        mesh_render = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        ScrollBG();
	}
    void ScrollBG() {
        float x_sroll = scroll_speed * Time.time;
        Vector2 offset = new Vector2(x_sroll, 0f);
        mesh_render.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
