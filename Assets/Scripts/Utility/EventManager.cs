using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {

    public Image blackImage;

    private bool blinking;
    private float blinkingTime = 5;
    private float timer;
    private bool displayDialog;
    private DialogManager.TextKey textKey;

    public float flickerSpeed = 0.07f;
    private int randomizer = 0;
    private bool _isOff = false;
    private float _timer;
    private bool eventIsActive;
    private Event currentEvent;
	
	void Update ()
    {
        if (blinking)
        {
            Blink();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (!blinking && eventIsActive && !GameManager.Instance.dialogManager.screenDialog.playDialog)
            {
                EndEvent(currentEvent);
            }
        }
	}

    public void StartEvent(Event _event, DialogManager.TextKey textKey)
    {
        blinking = true;
        eventIsActive = true;
        currentEvent = _event;
        GameManager.Instance.dialogManager.HideDialog();

        if(textKey != DialogManager.TextKey.None)
        {
            this.textKey = textKey;
        }
    }

    void Blink()
    {
        if (!_isOff)
        {
            if (randomizer != 0)
                blackImage.gameObject.SetActive(true);
            else
            {
                blackImage.gameObject.SetActive(false);
                _isOff = true;
            }
            randomizer = Random.Range(0, 20);
        }
        else
        {
            if (_timer >= flickerSpeed)
            {
                _isOff = !_isOff;
                _timer = 0;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }

        timer +=Time.deltaTime;

        if (timer >= blinkingTime)
        {
            blinking = false;
            blackImage.gameObject.SetActive(true);

            if(textKey != DialogManager.TextKey.None)
            {
                GameManager.Instance.dialogManager.DisplayScreenDialog(textKey);
            }
        }
    }

    void EndEvent(Event _event)
    {
        switch (_event)
        {
            case Event.Prologue:
                eventIsActive = false;
                currentEvent = Event.None;
                StateManager.Instance.SwitchScene(State.SceneID.LevelOne);
                break;
        }

    }

    public enum Event
    {
        None,
        Prologue
    }
}
