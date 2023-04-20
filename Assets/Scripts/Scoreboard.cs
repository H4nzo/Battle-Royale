using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform container;
    [SerializeField] GameObject scoreboardItemPrefab;
    Dictionary<Player, ScoreboardItem> scoreboardItems = new Dictionary<Player, ScoreboardItem>();

     private void Start() {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddScoreboardItem(player);
        }
     }

     void AddScoreboardItem(Player player){

        ScoreboardItem item = Instantiate(scoreboardItemPrefab, container).GetComponent<ScoreboardItem>();
        item.Initialize(player);
        scoreboardItems[player] = item;
     }

     public override void OnPlayerEnteredRoom(Player newPlayer){
        AddScoreboardItem(newPlayer);
     }

     public override void OnPlayerLeftRoom(Player otherPlayer)
     {
        RemoveScoreboardItem(otherPlayer);
     }

    void RemoveScoreboardItem(Player player){
       Destroy(scoreboardItems[player].gameObject);
       scoreboardItems.Remove(player);
    }

}
