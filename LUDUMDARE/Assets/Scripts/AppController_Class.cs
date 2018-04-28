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
        this.QuestionsHolder.DisplayQuestion(this.Questions[this.currentQuestionIndex]);
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


    public void InformQuestionWasAnswered(int points)
    {
        this.currentQuestionIndex++;

        this.QuestionsHolder.UpdatePoints(points);

        if (this.Questions.Count > this.currentQuestionIndex)
        {
            this.QuestionsHolder.DisplayQuestion(this.Questions[this.currentQuestionIndex]);
        }
        else
        {
            //    game over
            this.GameOverPanel.SetFinalPoints(this.QuestionsHolder.GetPoints());
        }
    }
}

