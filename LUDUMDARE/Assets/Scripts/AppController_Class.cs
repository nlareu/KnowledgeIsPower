using System;
using System.Collections.Generic;
using UnityEngine;

public class AppController_Class : MonoBehaviour
{
    public List<string> GameObjectsOrder;
    public GameOverPanel_Class GameOverPanel;
    //public PresentatioLevel_Class InitialPresentation;
    public GameObject PlayZone;
    public PresentationPanel_Class PresentationController;
    public List<PresentatioLevel_Class> Presentations;
    public List<Question_Class> Questions;
    public MostrarPreguntas QuestionsHolder;

    private int currentObjectIndex = -1;
    private object currentObject;
    private string currentObjectType;

    public AppController_Class()
    {
        this.GameObjectsOrder = new List<string>();
        this.Presentations = new List<PresentatioLevel_Class>();
        this.Questions = new List<Question_Class>();
    }

    void Start()
    {
    }

    void Update()
    {
    }

    private void DisplayNextObject()
    {
        string objectRef;
        int objectIndex;
        object prevObject = this.currentObject;
        string prevObjectType = this.currentObjectType;



        //Increase current object index.
        this.currentObjectIndex++;


        //Check if there is a next object to display.
        if (this.currentObjectIndex < this.GameObjectsOrder.Count)
        //if (this.currentObjectIndex < this.MaxQuestionsCount)
        {
            //Get current object data.
            objectRef = this.GameObjectsOrder[this.currentObjectIndex];

            //IMPORTANT: Stringify char before convert it to int due to
            //convert a char to int means get the int value of the char.
            //What we really want is convert the string number to int.
            //That is why it is necessary first stringify the char.
            objectIndex = Convert.ToInt32(objectRef[1].ToString());

            this.currentObjectType = objectRef[0].ToString().ToUpper();


            //Hide, remove or something the previous object.
            if (prevObject != null)
                this.HideCurrentObject(prevObject, prevObjectType, this.currentObjectType);



            switch (this.currentObjectType)
            {
                //Question
                case "Q":
                    Question_Class question = this.Questions[objectIndex];

                    //Set current object
                    this.currentObject = question;

                    //Dispaly question
                    this.QuestionsHolder.DisplayQuestion(question);

                    question.gameObject.SetActive(true);
                    break;
                //Presentation
                case "P":
                    this.currentObject = this.Presentations[objectIndex];

                    this.PresentationController.DisplayPresentation(
                        (PresentatioLevel_Class)this.currentObject,
                        new Action(delegate ()
                        {
                            this.DisplayNextObject();
                        })
                    );
                    break;
            }
        }
        else
        {
            this.HideCurrentObject(prevObject, prevObjectType, "");

            //game over
            this.GameOverPanel.SetFinalPoints(this.QuestionsHolder.GetPoints());
        }
    }
    private void HideCurrentObject(object currentObject, string currentObjectType, string nextObjectType)
    {
        switch (currentObjectType)
        {
            //Question
            case "Q":
                Destroy(((Question_Class)currentObject).gameObject);
                break;
            //Presentation
            case "P":
                if (nextObjectType != "P")
                    this.PresentationController.gameObject.SetActive(false);
                break;
        }
    }
    public void InformQuestionWasAnswered(int points)
    {
        this.QuestionsHolder.UpdatePoints(points);

        this.DisplayNextObject();
    }
    public void StartGamePlay()
    {
        this.PlayZone.gameObject.SetActive(true);

        this.DisplayNextObject();
    }
}

