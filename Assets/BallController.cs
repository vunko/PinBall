using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	private GameObject Tokutentext;

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.Tokutentext = GameObject.Find("Tokutentext");
	}

	// Update is called once per frame
	void Update () {
		
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";

		}
	}
	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "SmallStarTag") {
			score += 30;
		} else if (other.gameObject.tag == "LargeStarTag") {
			score += 10;
		} else if (other.gameObject.tag == "smallCloudTag" || other.gameObject.tag == "LargeCloudTag") {
			score += 20;

		}
		this.Tokutentext.GetComponent<Text> ().text = "得点は"+ score;
	}

	int score = 0;
}
