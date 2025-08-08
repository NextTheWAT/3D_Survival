using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioSource audioSource; // ������ ����� AudioSource
    public float fadeTime;
    public float maxVolume;
    private float targetVolume;

    private void Start()
    {
        targetVolume = 0f; // �ʱ� ������ 0���� ����
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = targetVolume;
        audioSource.Play();
    }

    private void Update()
    {
        if(!Mathf.Approximately(audioSource.volume, targetVolume))
        {
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, (maxVolume / fadeTime) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            targetVolume = maxVolume; // �÷��̾ ������ ������ �ִ밪���� ����
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            targetVolume = 0f; // �÷��̾ ������ ������ 0���� ����
        }
    }
}
