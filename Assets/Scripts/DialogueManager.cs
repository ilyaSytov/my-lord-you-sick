using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform dialogueBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;


    public void OpenDialogue(Message[] messages, Actor[] actors) {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Start dialoge. Loaded message: " + messages.Length);
        DisplayMessage();
    }

    public void NextMessage() {
        activeMessage++;
        if (activeMessage < currentMessages.Length) {
            DisplayMessage();
        }
        else
        {
            isActive = false;
        }
    }

    public void DisplayMessage() {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true) {
            NextMessage();
        }
    }
}
