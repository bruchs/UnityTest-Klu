using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
    public Question[] questions;
    public float timeToNextQuestion = 2.0F;
    private Question currentQuestion;
    private Animator mAnimator;

    public GameObject lightIndicator;
    private Material indicatorMaterial;

    private void Start()
    {
        mAnimator = GetComponentInChildren<Animator>();

        if(lightIndicator != null)
        {
            indicatorMaterial = lightIndicator.GetComponent<MeshRenderer>().material;
            indicatorMaterial.color = Color.cyan;
        }

        SetNewQuestion();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetNewQuestion();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckForAnwser();
        }
    }

    private void SetNewQuestion()
    {
        int questionIndex = Random.Range(0, questions.Length);

        if (currentQuestion != null && currentQuestion == questions[questionIndex])
        {
            SetNewQuestion();
            return;
        }

        currentQuestion = questions[questionIndex];
        currentQuestion.GenerateQuestion();
        Debug.Log(currentQuestion.GetAnwser());

        UIQuestions.instance.ClearUserInput();
        UIQuestions.instance.SetDescription(currentQuestion.GetDescription());
    }

    public void CheckForAnwser()
    {
        bool anwserResult;
        string currentInput = UIQuestions.instance.GetUserInput();
        currentInput = currentInput.ToLower();

        if (currentQuestion.CheckForAnwser(currentInput))
        {
            mAnimator.SetTrigger("Correct");
            UIQuestions.instance.SetDescription("Correcto!");

            indicatorMaterial.color = Color.green;
            anwserResult = true;
        }
        else
        {
            mAnimator.SetTrigger("Incorrect");
            UIQuestions.instance.SetDescription("Incorrecto!, intenta denuevo");

            indicatorMaterial.color = Color.yellow;
            anwserResult = false;
        }

        StartCoroutine(WaitForNextQuestion(anwserResult));
    }

    private IEnumerator WaitForNextQuestion(bool result)
    {
        yield return new WaitForSeconds(timeToNextQuestion);

        if(result != false)
        {
            SetNewQuestion();
        }
        else
        {
            UIQuestions.instance.ClearUserInput();
            UIQuestions.instance.SetDescription(currentQuestion.GetDescription());
        }

        indicatorMaterial.color = Color.cyan;
    }
}
