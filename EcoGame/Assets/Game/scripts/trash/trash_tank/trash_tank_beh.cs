using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_tank_beh : MonoBehaviour
{
    private player_beh _player_beh;
    private Controls _controls;

    private Transform _parent;
    private Transform _player;

    [Header("Tank Propereties")]
    public float _put_in_the_tank_distance = 1.5f;
    public string trash_type;
    [Space]
    public List<Transform> _trash_array = new List<Transform>();
    public int _tank_fill_max;
    public int _tank_fill;
    void Start()
    {
        _parent = transform.root;
        _player = _parent.GetChild(0);

        _player_beh = _player.GetComponent<player_beh>();
        _controls = _player.GetComponent<Controls>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Controls.activity_with_tank))
        {

            Put_trash_in_the_tank();

        }
    }
    void Put_trash_in_the_tank()
    {
        float _distance = Vector2.Distance(transform.position, _player.position);


        if (_distance <= _put_in_the_tank_distance)
        {
            SpringJoint2D _springJoint2D = _player_beh._SpringJoint2D;

            trash_beh _trash_beh = _player_beh._trash_beh;

            _trash_beh._trash_tank = transform;
            _trash_beh._trash_tank_beh = this;

            if (_springJoint2D.enabled)
            {
                _trash_beh.is_move_to_the_trash_tank = true;
            }

            _springJoint2D.enabled = false;
            _springJoint2D.connectedBody = null;

        }
    }

    public void Add_trash_In_the_tank(Transform _trash)
    {
        _trash_array.Add(_trash);
        _tank_fill++;
        _trash.gameObject.SetActive(false);
    }

    public void Tank_is_full_message()
    {
        Debug.Log("Tank is full");
    }


}