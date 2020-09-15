using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject winText;
	public GameObject loseText;
	public GameObject deathParticle;
	public Text lives;

	private int numberOfBricks = 18;
	private int numberOfLifes = 3;

	private float resetDelay = 1f;
	private GameObject gamePaddle;

	// Method to set the singleton and call SetupGame
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} 
		else if(instance != this)
		{
			Destroy(gameObject);
		}

		SetupGame ();
	}

	// Method to instantiante bricks, paddle and ball.
	void SetupGame()
	{
		// instantiate all bricks in the position (0, 0, 0), since the game object that contains them
		// are at position (0, 0, 0)
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);

		// instantiate the paddle
		InstantiatePaddle();
	}

	public void HitBrick()
	{
		numberOfBricks--;
		CheckGameState ();
	}

	public void LoseLife()
	{
		// update the number of lives left
		numberOfLifes--;

		lives.text = "Lives: " + numberOfLifes;

		// instantiate particle
		Instantiate(deathParticle, gamePaddle.transform.position, Quaternion.identity);
		Destroy (gamePaddle);

		Invoke ("InstantiatePaddle", resetDelay);

		// check the current state of the game
		CheckGameState ();
	}

	private void InstantiatePaddle()
	{
		gamePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void CheckGameState ()
	{
		// check for win condition
		if(numberOfBricks <= 0) {

			// win condition
			winText.SetActive(true);

			// reset game
			CallResetGame();
		}

		// check for lose condition
		if(numberOfLifes <= 0) 
		{
			loseText.SetActive (true);

			// reset game
			CallResetGame();
		}
	}

	private void CallResetGame()
	{
		Time.timeScale = 0.25f;
		Invoke("ResetGame", resetDelay);
	}

	private void ResetGame()
	{
		Time.timeScale = 1f;

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
