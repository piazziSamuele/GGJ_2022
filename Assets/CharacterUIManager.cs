using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CharacterUIManager : MonoBehaviour
{
    [SerializeField] ControllableCharacter character;
    [SerializeField] ControllableCharacter opponent;

    [SerializeField] List<WorldUIButton> buttons;
    public WorldUIButton[] _activeButtons = new WorldUIButton[4];

    [SerializeField] Quaternion defaultRotation;
    [SerializeField] float radius;
    [Range(0f,1f)][SerializeField] float maxRange;
    public CurrentPowerUps currentPowerUps => character.currentPowerUps;

    // Local Variables
    float distance, minAngle, maxAngle, angle;
    float minRange = 0f;
    Vector3 characterPosition, opponentPosition, direction,  offset;



    private void OnEnable()
    {
        currentPowerUps.onPowerUpPickUp += OnPowerUpPickUp;
    }
    private void OnDisable()
    {
        currentPowerUps.onPowerUpPickUp -= OnPowerUpPickUp;

    }

    private void OnPowerUpPickUp(PowerUpSO powerUp)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if(_activeButtons[i] == null)
            {

                buttons[i].powerUpUI.gameObject.SetActive(true);
                buttons[i].powerUpUI.powerUp = powerUp;
                buttons[i].SetPowerUPImage(powerUp.icon);
                _activeButtons[i] = buttons[i];
                break;

            }
        }
    }

    private void Update()
    {
        this.transform.position = character.transform.position;
        UpdateRotation();
        ButtonsDistribution();
        UpdatePowerUpLifetimes();

    }
    private void UpdatePowerUpLifetimes()
    {
        for (int i = 0; i < _activeButtons.Length; i++)
        {
            if (_activeButtons[i] == null) continue;
            _activeButtons[i].powerUpUI.lifeTime =
    Mathf.Lerp(1, 0, character.currentPowerUps.GetPowerUpLifePercentage(_activeButtons[i].powerUpUI.powerUp) / 100);
            if (currentPowerUps.GetPowerUpLifePercentage(_activeButtons[i].powerUpUI.powerUp) <= 0f)
            {
                _activeButtons[i].SetPowerUPImage(null);
                _activeButtons[i].powerUpUI.powerUp = null;
                _activeButtons[i].powerUpUI.gameObject.SetActive(false);
                _activeButtons[i] = null;
                print("bobby");
            }

        }
    }

    private void ButtonsDistribution()
    {
        minAngle = minRange * 360 * Mathf.PI / 180;
        maxAngle = maxRange * 360 * Mathf.PI / 180;
        angle = 360 * maxRange;
        for (int i = 0; i < buttons.Count; i++)
        {
            angle = 
                //buttons.Count == 1 ? -((maxAngle - minAngle) / 2) - (Mathf.PI / 2) :
                 ((maxAngle - minAngle) / (buttons.Count - 1) * i) -
                ((maxAngle - minAngle) / (buttons.Count / 2)) - (Mathf.PI / 2);

            buttons[i].transform.localPosition =  GetPosition(radius);
        }
    }

    private Vector3 GetPosition(float radius)
    {
        offset = new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius);
        offset.y = (-character.GetComponent<CapsuleCollider>().bounds.size.y / 2) + 0.01f;
        return offset;
    }

    private void UpdateRotation()
    {
        distance = Vector3.Distance(opponent.transform.position, character.transform.position);

        characterPosition = character.transform.position;
        characterPosition.y = 0;
        opponentPosition = opponent.transform.position;
        opponentPosition.y = 0;

        direction = Vector3.Normalize(opponentPosition - characterPosition);
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        Quaternion targetRotation = Quaternion.Lerp(defaultRotation, lookRotation,
    Mathf.Lerp(0, 1,
   Mathf.Max(0,1 - (distance/10))));

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 9f * Time.deltaTime);

    }
}
