using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {

    public Image blackImage;

    private bool blinking;
    private float blinkingTime = 3f;
    private float timer;
    private bool displayDialog;
    private DialogManager.TextKey textKey;

    public float flickerSpeed = 0.07f;
    private int randomizer = 0;
    private bool _isOff = false;
    private float _timer;
    private bool eventIsActive;
    private Event currentEvent;
    private IEnumerator coroutine;
	
	void Update ()
    {
        if (blinking)
        {
            Blink();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (!blinking && eventIsActive && !GameManager.Instance.dialogManager.screenDialog.playDialog && !GameManager.Instance.dialogManager.anyDialogsOnHold)
            {
                EndEvent(currentEvent);
            }
        }
	}

    public void StartEvent(Event _event, DialogManager.TextKey textKey)
    {
        if (_event == Event.Prologue)
        {
            blinking = true;
            eventIsActive = true;
            currentEvent = _event;
            GameManager.Instance.dialogManager.HideDialog();

            if (textKey != DialogManager.TextKey.None)
            {
                this.textKey = textKey;
            }
        }
        else if (_event == Event.End)
        {
            coroutine = WaitAndEndGame(3);
            StartCoroutine(coroutine);
        }
        else if (_event == Event.Hallucination)
        {
            GameManager.Instance.dialogManager.DisplayDialog(DialogManager.TextKey.Tutorial9);
            coroutine = WaitAndStartPrologue(3);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator WaitAndEndGame(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GameManager.Instance.ingameMenu.OpenMenu(IngameMenu.MenuState.RestartLevel, true);
            GameManager.Instance.ingameMenu.DisplayHeader(DialogManager.TextKey.OnEndHeader);
            break;
        }
    }

    private IEnumerator WaitAndStartHallucination(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GameManager.Instance.dialogManager.dialogBox.gameObject.SetActive(false);
            Camera.main.GetComponent<CameraPostEffect>().enabled = true;
            GameManager.Instance.inventory.actionBar.gameObject.SetActive(false);

            //Remove this if both blinking and hallucination is enabled.
            blinkingTime = 0;

            coroutine = WaitAndStartPrologue(4);
            StartCoroutine(coroutine);
            break;
        }
    }

    private IEnumerator WaitAndStartPrologue(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            StartEvent(Event.Prologue, DialogManager.TextKey.Dialog1_0);
            GameManager.Instance.dialogManager.dialogBox.gameObject.SetActive(false);
            blackImage.gameObject.SetActive(true);
            break;
        }
    }

    void Blink()
    {
        if (!_isOff && blinking)
        {
            if (randomizer != 0)
                blackImage.gameObject.SetActive(true);
            else
            {
                blackImage.gameObject.SetActive(false);
                _isOff = true;
            }
            randomizer = Random.Range(0, 10);
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
            Camera.main.GetComponent<CameraPostEffect>().enabled = false;

            if (textKey != DialogManager.TextKey.None)
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
        Prologue,
        Hallucination,
        End
    }
}
