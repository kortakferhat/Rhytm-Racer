using System;
using Photon.Deterministic;
using Quantum;
using UnityEngine;
using Input = Quantum.Input;

public class LocalInput : MonoBehaviour {
    
  private void OnEnable() {
    QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
  }

  public void PollInput(CallbackPollInput callback) {
    var input = new Input(); 
    input.Jump = UnityEngine.Input.GetButton("Jump");
    var x = UnityEngine.Input.GetAxis("Horizontal");
    var y = UnityEngine.Input.GetAxis("Vertical");
    
    input.Directon = new Vector2(x, y).ToFPVector2();
    callback.SetInput(input, DeterministicInputFlags.Repeatable);
  }
}
