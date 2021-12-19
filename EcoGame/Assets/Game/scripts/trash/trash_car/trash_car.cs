using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class trash_car : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private float _activity_distance = 5;

    public List<trash_tank_beh> trash_tanks = new List<trash_tank_beh>();

    private void Start()
    {
        _player = scene_manager.player;   
    }


    public void onActivity(InputAction.CallbackContext context)
    {

        Try_pass_trash();

    }

    private void Try_pass_trash()
    {
        float _player_distance = Vector2.Distance(_player.transform.position, transform.position);

        if (trash_tanks.Count > 0 && _player_distance <= _activity_distance)
        {

            Debug.Log($"there is {trash_tanks.Count} trash tanks");


            foreach (trash_tank_beh item in trash_tanks)
            {
                if (!item.start_pass_trash)
                {
                    item.StartCoroutine(item.Start_pass_trash_to_the_car(transform));
                    item.start_pass_trash = true;
                }

            }

        }
    }
}