using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] characters;
    private int currentCharacterIndex = 0;

    void Start()
    {
        if (characters.Length > 0)
        {
            ToggleCharacter(currentCharacterIndex);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        ToggleCharacter((currentCharacterIndex + 1) % characters.Length);
    }

    void ToggleCharacter(int index)
    {
        characters[currentCharacterIndex].SetActive(false);
        characters[index].SetActive(true);
        currentCharacterIndex = index;
    }
}
