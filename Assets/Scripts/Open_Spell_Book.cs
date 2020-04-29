using UnityEngine;

public class Open_Spell_Book : MonoBehaviour
{
    bool book_Open = false;

    public void Spell_Book_Open_Close()
    {
        if (!book_Open)
        {
            book_Open = true;
            transform.gameObject.SetActive(true);
        }
        else
        {
            book_Open = false;
            transform.gameObject.SetActive(false);
        }
    }
}
