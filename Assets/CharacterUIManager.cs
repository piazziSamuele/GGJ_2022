using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CharacterUIManager : MonoBehaviour
{
    [SerializeField] ControllableCharacter character;
    [SerializeField] ControllableCharacter opponent;

    [SerializeField] List<WorldUIButton> buttons;
    private List<WorldUIButton> activeButtons = new List<WorldUIButton>();

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
        int count = Mathf.Max(0, activeButtons.Count);

        buttons[count].gameObject.SetActive(true);
        buttons[count].powerUpUIElement.gameObject.SetActive(true);
        buttons[count].SetPowerUPImage(powerUp.icon);
        activeButtons.Add(buttons[count]);
    }

    private void Update()
    {
        this.transform.position = character.transform.position;
        UpdateRotation();
        ButtonsDistribution();

    }

    private void ButtonsDistribution()
    {
        if (activeButtons == null || activeButtons.Count == 0) { return; }
        minAngle = minRange * 360 * Mathf.PI / 180;
        maxAngle = maxRange * 360 * Mathf.PI / 180;
        angle = 360 * maxRange;
        for (int i = 0; i < activeButtons.Count; i++)
        {
            angle = activeButtons.Count == 1 ? -((maxAngle - minAngle) / 2) - (Mathf.PI / 2)
                : ((maxAngle - minAngle) / (activeButtons.Count - 1) * i) -
                ((maxAngle - minAngle) / (activeButtons.Count / 2)) - (Mathf.PI / 2);

            activeButtons[i].transform.localPosition =  GetPosition(radius);
            activeButtons[i].powerUpUIElement.transform.localPosition = GetPosition(radius + 1.5f);

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
   Mathf.Max(0,1 - (distance/5))));

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 9f * Time.deltaTime);

    }
}
