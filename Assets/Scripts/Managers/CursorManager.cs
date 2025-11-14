using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance { get; private set; }

    [SerializeField] Texture2D cursorTextureDefault;
    [SerializeField] Texture2D cursorTextureActive;

    [SerializeField] Vector2 clickPositionDefault = Vector2.zero;
    [SerializeField] Vector2 clickPositionActive;

    public enum ModeOfCursor
    {
        Default,
        Active
    }

    void Start()
    {
        clickPositionActive = new Vector2(cursorTextureActive.width / 2, cursorTextureActive.height / 2);
        Cursor.SetCursor(cursorTextureDefault, clickPositionDefault, CursorMode.Auto);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetToMode(ModeOfCursor modeOfCursor)
    {
        switch (modeOfCursor)
        {
            case ModeOfCursor.Default:
                Cursor.SetCursor(cursorTextureDefault, clickPositionDefault, CursorMode.Auto);
                break;
            case ModeOfCursor.Active:
                Cursor.SetCursor(cursorTextureActive, clickPositionActive, CursorMode.Auto);
                break;
        }
    }
}
