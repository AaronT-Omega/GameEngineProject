using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private PlayerMovement _playerMove;
    private Command _buttonA, _buttonD, _buttonW, _buttonS, _noButtonH, _noButtonV;
    //private bool _isMoving = false;
    void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _playerMove = FindObjectOfType<PlayerMovement>();

        _buttonA = new MoveLeft(_playerMove);
        _buttonD = new MoveRight(_playerMove);
        _buttonW = new MoveUp(_playerMove);
        _buttonS = new MoveDown(_playerMove);
        _noButtonH = new StopMoveH(_playerMove);
        _noButtonV = new StopMoveV(_playerMove);

    }
    void Update()
    {
        if (!_isReplaying)
        {
            
            if (Input.GetKeyDown(KeyCode.A))
                _invoker.ExecuteCommand(_buttonA);
            else if(Input.GetKeyUp(KeyCode.A) && !Input.anyKeyDown)
                _invoker.ExecuteCommand(_noButtonH);

            if (Input.GetKeyDown(KeyCode.D))
                _invoker.ExecuteCommand(_buttonD);
            else if (Input.GetKeyUp(KeyCode.D))
                _invoker.ExecuteCommand(_noButtonH);

            if (Input.GetKeyDown(KeyCode.W))
                _invoker.ExecuteCommand(_buttonW);
            else if (Input.GetKeyUp(KeyCode.W))
                _invoker.ExecuteCommand(_noButtonV);

            if (Input.GetKeyDown(KeyCode.S))
                _invoker.ExecuteCommand(_buttonS);
            else if (Input.GetKeyUp(KeyCode.S))
                _invoker.ExecuteCommand(_noButtonV);


            //if (!Input.GetKeyDown(KeyCode.A) || !Input.GetKeyDown(KeyCode.D))
            //_invoker.ExecuteCommand(_noButton);


        }
    }
    void OnGUI()
    {
        if (GUILayout.Button("Start Recording"))
        {
            //_bikeController.ResetPosition();
            _isReplaying = false;
            _isRecording = true;
            _invoker.Record();
        }
        if (GUILayout.Button("Stop Recording"))
        {
            //_bikeController.ResetPosition();
            _isRecording = false;
        }
        if (!_isRecording)
        {
            if (GUILayout.Button("Start Replay"))
            {
                //_bikeController.ResetPosition();
                _isRecording = false;
                _isReplaying = true;
                _invoker.Replay();
            }
        }
    }
}
