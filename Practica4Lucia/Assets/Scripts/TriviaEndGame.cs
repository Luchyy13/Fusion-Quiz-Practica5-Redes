using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//compruebo que funciona el flujo de la primera rama creada
/// <summary>
/// Handles displaying the winners of the game
/// </summary>
public class TriviaEndGame : MonoBehaviour
{
    [Tooltip("Displays the top three winners.")]
    public TriviaEndGamePlayer[] winnerDisplays;
    public TextMeshProUGUI fullRankingText; //añado esto para mostrar el ranking completo

    /// <summary>
    /// Shows the list of winners.
    /// </summary>
    /// <param name="winners">The list of winning players</param>

    //Añado nuevo metodo para mostrar el ranking completo de jugadores
    public void SetFullRanking(List<TriviaPlayer> players)
    {
        string ranking = "RANKING FINAL\n\n";

        for (int i = 0; i < players.Count; i++)
        {
            ranking +=
                (i + 1) + "º "
                + players[i].PlayerName.Value
                + " ("
                + players[i].Score
                + "pts)"
                + "\n";
        }

        fullRankingText.text = ranking;
    }
    public void Show(List<TriviaPlayer> winners)
    {
        // Iterates through the winner displayers and shows them if a winner is available.
        for (int i =0, len = winnerDisplays.Length; i < len;  i++)
        {
            if (i < winners.Count)
            {
                winnerDisplays[i].Show(winners[i]);
            }
            else
            {
                winnerDisplays[i].Hide();
            }
        }

        gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the end game display.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}