using UnityEngine;
using TMPro;

public class EconomyManager : Singleton<EconomyManager>
{
    private TMP_Text bookText;
    private int currentBooks = 0;

    const string BOOK_AMOUNT_TEXT = "BookAmountText";

    public void UpdateCurrentBooks() {
        currentBooks += 1;

        if (bookText == null) {
            bookText = GameObject.Find(BOOK_AMOUNT_TEXT).GetComponent<TMP_Text>();
        }

        bookText.text = currentBooks.ToString("D3");
    }
}

