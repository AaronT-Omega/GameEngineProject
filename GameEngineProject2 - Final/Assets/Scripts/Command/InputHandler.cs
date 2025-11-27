using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private PlayerController _playerController;
    [SerializeField] private KeyRebind _keyBinds;

    private Command _buttonLeft, _buttonRight, _buttonUp, _buttonDown, _noButtonH, _noButtonV, _buttonAttack;
    private KeyCode _keyLeft, _keyRight, _keyUp, _keyDown, _keyAttack;
    //private bool _isMoving = false;
    void Start()
    {

        if (!_keyBinds)
        {
            _keyBinds = (KeyRebind)FindObjectOfType(typeof(KeyRebind));
        }
        _keyLeft = _keyBinds.leftKey;
        _keyRight = _keyBinds.rightKey;
        _keyUp = _keyBinds.upKey;
        _keyDown = _keyBinds.downKey;
        _keyAttack = _keyBinds.attackKey;

        _invoker = gameObject.AddComponent<Invoker>();
        _playerController = FindObjectOfType<PlayerController>();

        _buttonLeft = new MoveLeft(_playerController);
        _buttonRight = new MoveRight(_playerController);
        _buttonUp = new MoveUp(_playerController);
        _buttonDown = new MoveDown(_playerController);

        _noButtonH = new StopMoveH(_playerController);
        _noButtonV = new StopMoveV(_playerController);

        _buttonAttack = new Attack(_playerController);

    }
    void Update()
    {
        if (!_isReplaying)
        {
            
            if (Input.GetKeyDown(_keyLeft))
                _invoker.ExecuteCommand(_buttonLeft);
            else if(Input.GetKeyUp(_keyLeft))
                _invoker.ExecuteCommand(_noButtonH);

            if (Input.GetKeyDown(_keyRight))
                _invoker.ExecuteCommand(_buttonRight);
            else if (Input.GetKeyUp(_keyRight))
                _invoker.ExecuteCommand(_noButtonH);

            if (Input.GetKeyDown(_keyUp))
                _invoker.ExecuteCommand(_buttonUp);
            else if (Input.GetKeyUp(_keyUp))
                _invoker.ExecuteCommand(_noButtonV);

            if (Input.GetKeyDown(_keyDown))
                _invoker.ExecuteCommand(_buttonDown);
            else if (Input.GetKeyUp(_keyDown))
                _invoker.ExecuteCommand(_noButtonV);




            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(_keyAttack)) // Left mouse button click
            {
                _invoker.ExecuteCommand(_buttonAttack);
                
            }


            //if (!Input.GetKeyDown(_keyLeft) || !Input.GetKeyDown(_keyRight))
            //_invoker.ExecuteCommand(_noButton);


        }
    }
    
    void Remap()
    {

    }
    
    
    
    
    
    
    
    //void OnGUI()
    //{
    //    if (GUILayout.Button("Start Recording"))
    //    {
    //        //_bikeController.ResetPosition();
    //        _isReplaying = false;
    //        _isRecording = true;
    //        _invoker.Record();
    //    }
    //    if (GUILayout.Button("Stop Recording"))
    //    {
    //        //_bikeController.ResetPosition();
    //        _isRecording = false;
    //    }
    //    if (!_isRecording)
    //    {
    //        if (GUILayout.Button("Start Replay"))
    //        {
    //            //_bikeController.ResetPosition();
    //            _isRecording = false;
    //            _isReplaying = true;
    //            _invoker.Replay();
    //        }
    //    }
    //}
}
