using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inspector : MonoBehaviour
{
    private Animator anim;
    private GameObject player; // ������� ���������� � ������� "GameObject", � �������� ���� ������, � �������� ��� ����� ����� ��������.

    public float activity_distance; // ������� ���������� ����������� ���������, ��� ������� ��������� ����� ��������.

    [Header("reviever")]
    public bool is_create;
    public bool on_close;
    public GameObject reviever_prefab;
    private GameObject reviever_obj;
    public Transform inst_point;
    public Transform stop_point;
    public Transform destr_point;
    public TextMeshPro inspector_text;
    public float rev_speed = 5;
    public float stop_time = 30;
    public float reviever_distance = 100;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); // ��������� �� ������� ����� unity, �������� ����� ������ ������ "GameObject". � ������ ������ �� ����� ������� ����� ���, ������� ��� ����� �� ���������.
        inspector_text.text = "������� '�', ����� ������� ��������";
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

        //reviever

        if (distance < activity_distance && Input.GetKeyUp(KeyCode.E))
        {
            inspector_text.text = (is_create) ? "�������� ��� �� �����" : "�������� ������";

            if (!is_create)
            {
                reviever_obj = Instantiate(reviever_prefab, inst_point);
                reviever_obj.AddComponent<reviever>();
                reviever_obj.GetComponent<reviever>().stop_point = stop_point;
                reviever_obj.GetComponent<reviever>().dest_point = destr_point;
                reviever_obj.GetComponent<reviever>().stop_time = stop_time;
                reviever_obj.GetComponent<reviever>().inspector_script = this;

                inspector_text.text = "�������� ������";

            }

            is_create = true;
        }

        // �������� ��������� ����� ���������� � �����������
        if (reviever_obj != null)
        {
            reviever_distance = Vector2.Distance(reviever_obj.transform.position, transform.position);
        }
        on_close = (reviever_distance < 0.8f);

    }
    // ��� �� � ���� ��������� � ����� ���� ������� �������� - stay, � ����� ������� �� ���������� ��� �� �� ������ ����.
}
