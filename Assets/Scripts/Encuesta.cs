using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Encuesta : MonoBehaviour
{
    [Header("Paneles y UI")]
    [SerializeField] private GameObject surveyPanel;
    [SerializeField] private Slider controlSlider;       
    [SerializeField] private Slider satisfactionSlider;  
    [SerializeField] private Slider fantasySlider;      
    [SerializeField] private TMP_InputField feedbackInput; 
    [SerializeField] private TMP_InputField DesafioInput;
    [SerializeField] private Button submitButton;
    

    private void Start()
    {
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(SubmitSurvey);
        }
    }

    public void SubmitSurvey()
    {
        int q1Control = controlSlider != null ? Mathf.RoundToInt(controlSlider.value) : 0;
        int q2Satisfaction = satisfactionSlider != null ? Mathf.RoundToInt(satisfactionSlider.value) : 0;
        int q3Fantasy = fantasySlider != null ? Mathf.RoundToInt(fantasySlider.value) : 0;
        string q4Feedback = feedbackInput != null ? feedbackInput.text : "";
        string q5Desafio = DesafioInput != null ? DesafioInput.text : "";

        Debug.Log($"¿Cuánta tensión te generó este juego?: {q1Control} / 5");
        Debug.Log($"¿Los checkpoints te ayudan a snetir alivio?: {q2Satisfaction} / 5");
        Debug.Log($"¿Sientes que este juego es competitivo?: {q3Fantasy} / 5");
        Debug.Log($"Describe que sentiste al pasar el nivel y si sientes desafiante al pasarlo: {q4Feedback}");  
        Debug.Log($"¿Qué mejorarías en el juego?: {q5Desafio}"); 
        if (surveyPanel != null)
        {
            surveyPanel.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}