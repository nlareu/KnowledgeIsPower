using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AppController_Class : MonoBehaviour
{
    public List<string> GameObjectsOrder;
    public GameOverPanel_Class GameOverPanel;
    //public PresentatioLevel_Class InitialPresentation;
    public List<Sound> LevelsBackgroundMusic;
    public GameObject PlayZone;
    public PresentationPanel_Class PresentationController;
    public List<PresentatioLevel_Class> Presentations;
    public List<Question_Class> Questions;
    public List<QuestionMusicConfig> QuestionsBackgroundMusic;
    public MostrarPreguntas QuestionsHolder;

    private AudioSource audioSource_QuestionMusic;
    private int currentObjectIndex = -1;
    private object currentObject;
    private string currentObjectType;
    private Dictionary<string, AudioClip> levelBackgroundClips;
    private Dictionary<int, string> questionsBackgroundMusicColl;

    public AppController_Class()
    {
        this.GameObjectsOrder = new List<string>();
        this.Presentations = new List<PresentatioLevel_Class>();
        this.Questions = new List<Question_Class>();

        this.levelBackgroundClips = new Dictionary<string, AudioClip>();
        this.questionsBackgroundMusicColl = new Dictionary<int, string>();
    }

    void Start()
    {
        this.audioSource_QuestionMusic = this.gameObject.AddComponent<AudioSource>();

        this.LevelsBackgroundMusic.ForEach(item =>
        {
            this.levelBackgroundClips.Add(item.name, item.clip);
        });

        this.QuestionsBackgroundMusic.ForEach(item =>
        {
            this.questionsBackgroundMusicColl.Add(item.QuestionIndex, item.ClipName);
        });
    }

    void Update()
    {
    }

    private void DisplayNextObject()
    {
        string objectRef;
        int objectIndex;
        object prevObject = this.currentObject;
        int prevObjectIndex;
        string prevObjectRef = (this.currentObjectIndex > 0) ? this.GameObjectsOrder[this.currentObjectIndex] : "";
        string prevObjectType = this.currentObjectType;

        prevObjectIndex = (string.IsNullOrEmpty(prevObjectRef) == false) ? Convert.ToInt32(prevObjectRef.Remove(0, 1)) : -1;


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
            objectIndex = Convert.ToInt32(objectRef.Remove(0, 1));

            this.currentObjectType = objectRef[0].ToString().ToUpper();


            //Hide, remove or something the previous object.
            if (prevObject != null)
                this.HideCurrentObject(prevObject, prevObjectType, this.currentObjectType);


            switch (this.currentObjectType)
            {
                //Question
                case "Q":
                    Question_Class question = this.Questions[objectIndex];
                    string curQuestionClipName = this.questionsBackgroundMusicColl[objectIndex];

                    //Set current object
                    this.currentObject = question;

                    //Dispaly question
                    this.QuestionsHolder.DisplayQuestion(question);

                    question.gameObject.SetActive(true);


                    //Check if question music must start/still playing or must change clip.
                    if (this.audioSource_QuestionMusic.isPlaying == true)
                    {
                        string prevQuestionClipName = (prevObjectIndex != -1) ? this.questionsBackgroundMusicColl[prevObjectIndex] : "";

                        if (curQuestionClipName.Equals(prevQuestionClipName, StringComparison.OrdinalIgnoreCase) == false)
                        {
                            if (this.audioSource_QuestionMusic.isPlaying == true)
                                this.audioSource_QuestionMusic.Stop();

                            this.audioSource_QuestionMusic.clip = this.levelBackgroundClips[curQuestionClipName];

                            this.audioSource_QuestionMusic.Play();
                        }
                    }
                    else
                    {
                        this.audioSource_QuestionMusic.clip = this.levelBackgroundClips[curQuestionClipName];

                        this.audioSource_QuestionMusic.Play();
                    }

                    break;
                //Presentation
                case "P":
                    //If next object is not question, stop playing question music.
                    if (this.audioSource_QuestionMusic.isPlaying == true)
                        this.audioSource_QuestionMusic.Stop();

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
                if (nextObjectType != "Q")
                    this.PresentationController.gameObject.SetActive(false);

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

