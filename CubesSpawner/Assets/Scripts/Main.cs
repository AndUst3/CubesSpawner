using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _finish;
    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject _mainMenu;

    [SerializeField] private Text _instruction;
    [SerializeField] private Button _playButton;

    [SerializeField] public InputField spawnTimeField;
    [SerializeField] public InputField spawnCountField;
    [SerializeField] public InputField wayLengthField;

    private Vector3 _finishSpawnPoint;

    private int _spawnCount;
    private bool _isExecute;

    public float timeSpawn;
    public int lastSpawnNumber;
    public float wayLength;

    private void Awake()
    {
        _mainMenu.gameObject.SetActive(true);
        _playButton.gameObject.SetActive(false);
        _playButton.onClick.AddListener(StartGame);
        _spawnCount = 0;
        _isExecute = true;
    }

    private void Update()
    {
        if (spawnTimeField != null)
        {
            timeSpawn = float.Parse(spawnTimeField.text);
        }

        if (spawnCountField != null)
        {
            lastSpawnNumber = int.Parse(spawnCountField.text);
        }

        if (wayLengthField != null)
        {
            wayLength = float.Parse(wayLengthField.text);
            _finishSpawnPoint = new Vector3(wayLength, -0.4f, 0);
        }

        if (spawnTimeField != null & spawnCountField != null & wayLengthField != null & _isExecute == true & Input.GetKey(KeyCode.Return))
        {
            _playButton.gameObject.SetActive(true);
            spawnTimeField.gameObject.SetActive(false);
            spawnCountField.gameObject.SetActive(false);
            wayLengthField.gameObject.SetActive(false);
            _instruction.gameObject.SetActive(false);

            _isExecute = false;
            Instantiate(_finish, _finishSpawnPoint, Quaternion.identity);
        }
    }

    private void StartGame()
    {
        _mainMenu.gameObject.SetActive(false);
        Repeat();
    }

    private void Repeat()
    {
        StartCoroutine(Spawn());
        
        if (_spawnCount == lastSpawnNumber)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeSpawn);

        _spawnCount++;
        Instantiate(_cube, _spawnPoint.position, Quaternion.identity);
        Repeat();
    }
}
