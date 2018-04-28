using System;
using System.Collections.Generic;
using UnityEngine;

public class AppController_Class : MonoBehaviour
{
    public static AppController_Class Instance;

    public List<Question_Class> Questions;
    public MostrarPreguntas QuestionsHolder;
    public GameOverPanel_Class GameOverPanel;

    private int currentQuestionIndex = 0;
    //private bool started = false;

    public AppController_Class()
    {
        if (Instance == null)
            Instance = this;

        this.Questions = new List<Question_Class>();
    }

    void Start()
    {
        //Display initial question.
        this.DisplayCurrentQuestionQuestion();
    }

    void Update()
    {
        //if (this.started == false)
        //{
            ////Display initial question.
            //this.QuestionsHolder.DisplayQuestion(this.Questions[this.currentQuestionIndex]);

        //    this.started = true;
        //}
    }


    private void DisplayCurrentQuestionQuestion()
    {
        this.QuestionsHolder.DisplayQuestion(this.Questions[this.currentQuestionIndex]);

        this.Questions[this.currentQuestionIndex].gameObject.SetActive(true);
    }
    public void InformQuestionWasAnswered(int points)
    {
        //Destroy entire question and all its objects.
        Destroy(this.Questions[this.currentQuestionIndex].gameObject);

        this.QuestionsHolder.UpdatePoints(points);

        this.currentQuestionIndex++;

        if (this.Questions.Count > this.currentQuestionIndex)
        {
            this.DisplayCurrentQuestionQuestion();
        }
        else
        {
            //    game over
            this.GameOverPanel.SetFinalPoints(this.QuestionsHolder.GetPoints());
        }
    }
}

