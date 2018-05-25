using System;
using System.Collections.Generic;
using UnityEngine;

public class AppController_Class : MonoBehaviour
{
    //public static AppController_Class Instance;

    public GameOverPanel_Class GameOverPanel;
    //public PresentatioLevel_Class InitialPresentation;
    public int MaxQuestionsCount;
    public PresentationPanel_Class PresentationController;
    public List<Question_Class> Questions;
    public List<PresentatioLevel_Class> Presentations;
    public MostrarPreguntas QuestionsHolder;

    private int currentQuestionIndex = 0;
    //private bool started = false;

    public AppController_Class()
    {
        //if (Instance == null)
        //    Instance = this;

        this.MaxQuestionsCount = 4;
        this.Presentations = new List<PresentatioLevel_Class>();
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
        //Run initial presentation.
        this.PresentationController.DisplayPresentation(
            this.Presentations[this.currentQuestionIndex],
            new Action(delegate ()
            {
                this.PresentationController.gameObject.SetActive(false);

                this.QuestionsHolder.DisplayQuestion(this.Questions[this.currentQuestionIndex]);

                this.Questions[this.currentQuestionIndex].gameObject.SetActive(true);
            })
        );
    }
    public void InformQuestionWasAnswered(int points)
    {
        //Destroy entire question and all its objects.
        Destroy(this.Questions[this.currentQuestionIndex].gameObject);

        this.QuestionsHolder.UpdatePoints(points);

        this.currentQuestionIndex++;

        if (this.currentQuestionIndex < this.MaxQuestionsCount)
        {
            this.DisplayCurrentQuestionQuestion();
        }
        else
        {
            this.PresentationController.DisplayPresentation(
                this.Presentations[this.currentQuestionIndex],
                new Action(delegate ()
                {
                    this.PresentationController.gameObject.SetActive(false);

                    //game over
                    this.GameOverPanel.SetFinalPoints(this.QuestionsHolder.GetPoints());
                })
            );
        }
    }
}

