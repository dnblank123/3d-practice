using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour {

	public Text text;
	public float fallSpeed = 2f;
	

	private void Start() 
	{
		gameObject.AddComponent<BoxCollider>().isTrigger = true;
		gameObject.tag = "Killzone";
		

	}
	public void SetWord (string word)
	{
		text.text = word;
	}

	public void RemoveLetter ()
	{
		text.text = text.text.Remove(0, 1);
		text.color = Color.red;
	}

	public void RemoveWord ()
	{
		Destroy(gameObject);
		ScoreTextScript.textAmount += 1;
	}
	private void OnTriggerEnter(Collider other) 
	{
	
	}

	private void Update()
	{

		transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);

		if (ScoreTextScript.textAmount == 15)
        {
			Debug.Log("complete");
        }
	}

}
