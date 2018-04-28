using System;
using System.Collections.Generic;
using UnityEngine;

public class Question_Class : MonoBehaviour {

    public string Text;
    public List<string> AnswersText;
    public List<int> AnswersPoint;
    public List<Enemy_Clase> AnswersEnemy;

    private Dictionary<int, int> enemiesCountByAnswer = new Dictionary<int, int>();
    //private Dictionary<int, int> enemiesDestroyed = new Dictionary<int, int>();

    // Use this for initialization
    void Start () {
        //Set enemies count for each answer with data set on AnsersEnemy property.
        this.AnswersEnemy.ForEach(item =>
        {
            if (this.enemiesCountByAnswer.ContainsKey(item.Enemy_Color) == false)
                this.enemiesCountByAnswer.Add(item.Enemy_Color, 1);
            else
                this.enemiesCountByAnswer[item.Enemy_Color]++;
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CheckEnemiesDestroyedCount(Enemy_Clase enemy)
    {
        if (this.enemiesCountByAnswer[enemy.Enemy_Color] <= 0)
        //if (this.enemiesDestroyed[enemy.Enemy_Color] <= 0)
        {
            //this.DestroyAll();

            AppController_Class.Instance.InformQuestionWasAnswered(this.AnswersPoint[enemy.Enemy_Color]);

            //ResetEnemiesStatistics();
        }
    }
    private void DestroyAll()
    {
        this.AnswersEnemy.ForEach(item => Destroy(item.gameObject));
    }
    public void InformEnemyDestroyed(Enemy_Clase enemy)
    {
        //if (this.enemiesDestroyed.ContainsKey(enemy.Enemy_Color) == false)
        //    enemiesDestroyed.Add(enemy.Enemy_Color, 0);

        //enemiesDestroyed[enemy.Enemy_Color]++;

        //Deactive enemy object. Do not destoy it. All enemies will
        //be destroyed when question is answered.
        enemy.gameObject.SetActive(false);

        this.enemiesCountByAnswer[enemy.Enemy_Color]--;

        CheckEnemiesDestroyedCount(enemy);
    }
    //private void ResetEnemiesStatistics()
    //{
    //    enemiesDestroyed = new Dictionary<int, int>();
    //}
}
