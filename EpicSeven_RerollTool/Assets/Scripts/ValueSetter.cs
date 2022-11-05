using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueSetter : MonoBehaviour
{
    public GameObject rerollStage;
    public TMP_InputField skystonesInputField;
    public TMP_InputField goldInputField;
    public TMP_InputField covenantsInputField;
    public TMP_InputField mysticsInputField;
    private OperationsScript operationsScript;

    void Awake()
    {
        operationsScript = GameObject.Find("Canvas").GetComponent<OperationsScript>();
    }

    void Start()
    {
        rerollStage.SetActive(false);
    }

    public void SetValuesButton()
    {
        operationsScript.SetValues(int.Parse(skystonesInputField.text), int.Parse(goldInputField.text), int.Parse(covenantsInputField.text), int.Parse(mysticsInputField.text));

        this.gameObject.SetActive(false);
        rerollStage.SetActive(true);
    }
}
