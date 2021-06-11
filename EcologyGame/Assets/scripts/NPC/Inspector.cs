using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector : MonoBehaviour
{
    private Animator anim;
    private GameObject player; // ������� ���������� � ������� "GameObject", � �������� ���� ������, � �������� ��� ����� ����� ��������.

    public float activity_distance; // ������� ���������� ����������� ���������, ��� ������� ��������� ����� ��������.

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); // ��������� �� ������� ����� unity, �������� ����� ������ ������ "GameObject". � ������ ������ �� ����� ������� ����� ���, ������� ��� ����� �� ���������.
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position); // ������� ���������� ������� ��������� ����� ������� � �����������

        if (distance < activity_distance) // � ���������� ���� ��������
        {
            anim.SetBool("Down", false);
            anim.SetBool("UP", true);

        } else
        {
            anim.SetBool("UP", false);
            anim.SetBool("Down", true);
        }
    }

    // ��� �� � ���� ��������� � ����� ���� ������� �������� - stay, � ����� ������� �� ���������� ��� �� �� ������ ����.
}
