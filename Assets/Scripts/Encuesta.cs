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

        Debug.Log($"P1 Control: {q1Control} / 5");
        Debug.Log($"P2 Satisfacción: {q2Satisfaction} / 5");
        Debug.Log($"P3 Narrativa: {q3Fantasy} / 5");
        Debug.Log($"P4 Feedback: {q4Feedback}");  
        Debug.Log($"P5 Desafío: {q5Desafio}"); 
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