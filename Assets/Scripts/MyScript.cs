using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    private bool isGenerate;
    internal new string name;
    internal int iD;
    internal string column4;
    
    /*Exemple of Variables
    [Header("Data")]
    public StateMobility state;
    private int nCombinaison;
    public CombineWith[] useWith;
    public UnityEvent onLock, onUnlock;

    [Header("Refs")]
    private MeshFilter m_MeshFilter;
    public MeshFilter meshFilter { get => m_MeshFilter; set => m_MeshFilter = value; }

    private MeshRenderer m_MeshRenderer;
    public MeshRenderer meshRenderer { get => m_MeshRenderer; set => m_MeshRenderer = value; }

    private MeshCollider m_MeshCollider;
    public MeshCollider meshCollider { get => m_MeshCollider; set => m_MeshCollider = value; }

    private SphereCollider m_Spherecollider;
    public SphereCollider sphereCollider { get => m_Spherecollider; set => m_Spherecollider = value; }

    private DissolveEffect m_DissolveEffect;
    public DissolveEffect dissolveEffect { get => m_DissolveEffect; set => m_DissolveEffect = value; }

    private AudioSource m_AudioSource;
    public AudioSource audioSource { get => m_AudioSource; set => m_AudioSource = value; }

    [Header("Outline Properties")]
    public Outline outline;
    public Material selectOutline;
    public Color defaultOutlineColor;*/

    internal bool component_1;
    internal bool component_2;
    internal bool component_3;
    internal bool component_4;
    internal bool component_5;
    internal bool component_6;

    internal void Init(string[] entry)
    {
        //Initialize GO data from entry
        /*this.name = entry[1];

        iD = int.Parse(entry[2]);

        if (entry[3].Contains("STATIQUE"))
        {
            state = StateMobility.Static;
        }
        else if (entry[3].Contains("DYNAMIQUE"))
        {
            state = StateMobility.Dynamic;
        }

        nCombinaison = int.Parse(entry[4]);

        useWith = new CombineWith[nCombinaison];

        if (nCombinaison <= 1)
        {
            useWith[0] = new CombineWith
            {
                objectName = entry[5],
                influence = int.Parse(entry[6]),
                outcome = entry[7]

            };
        }
        else if (nCombinaison == 2)
        {
            useWith[0] = new CombineWith
            {
                objectName = entry[5],
                influence = int.Parse(entry[6]),
                outcome = entry[7]
            };

            useWith[1] = new CombineWith
            {
                objectName = entry[8],
                influence = int.Parse(entry[9]),
                outcome = entry[10]
            };
        }
        else if (nCombinaison == 3)
        {
            useWith[0] = new CombineWith
            {
                objectName = entry[5],
                influence = int.Parse(entry[6]),
                outcome = entry[7]
            };

            useWith[1] = new CombineWith
            {
                objectName = entry[8],
                influence = int.Parse(entry[9]),
                outcome = entry[10]
            };

            useWith[2] = new CombineWith
            {
                objectName = entry[11],
                influence = int.Parse(entry[12]),
                outcome = entry[13]
            };
        }
        else
        {
            useWith[0] = new CombineWith
            {
                objectName = entry[5],
                influence = int.Parse(entry[6]),
                outcome = entry[7]
            };


            useWith[1] = new CombineWith
            {
                objectName = entry[8],
                influence = int.Parse(entry[9]),
                outcome = entry[10]
            };

            useWith[2] = new CombineWith
            {
                objectName = entry[11],
                influence = int.Parse(entry[12]),
                outcome = entry[13]
            };

            useWith[3] = new CombineWith
            {
                objectName = entry[14],
                influence = int.Parse(entry[15]),
                outcome = entry[16]
            };
        }

        for (var i = 0; i < useWith.Length; i++)
        {
            Debug.Log(useWith.Length);
            Debug.Log(useWith[i].objectName + ", " + i); //to remove
            useWith[i].doAction = new UnityEvent();
#if UNITY_EDITOR
            UnityEventTools.AddIntPersistentListener(useWith[i].doAction, SendIdWithOutcome, i);
#endif
        }

        LoadFromRessources();
        SetOutline();
        SetCollider();
        InitAudioSource();*/

    }

    internal void GetComponent()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
