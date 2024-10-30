using UnityEngine;
using UnityEngine.UI;
public class ButtonAudio : MonoBehaviour
{
public AudioClip soundClip; // Reference to the audio clip you want to play
private Button button;
private AudioSource audioSource;
private void Start()
{
// Get references to the button and audio source components
button = GetComponent<Button>();
audioSource = GetComponent<AudioSource>();
// Attach the audio clip to the audio source
audioSource.clip = soundClip;
// Add a listener to the button's click event
button.onClick.AddListener(PlaySound);
}
private void PlaySound()
{
// Play the attached audio clip when the button is clicked
audioSource.Play();
}
}