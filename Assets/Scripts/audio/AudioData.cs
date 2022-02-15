using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioData : MonoBehaviour
{
    AudioClip audioClip;
    public bool useMic;
    public string selectedDevice;

    AudioSource audioSource;
    public static float[] samplesLeft = new float[512];
    public static float[] samplesRight = new float[512];
    public static float[] frequencyBand = new float[8];
    public static float[] bandBuffer = new float[8];
    float[] bufferDecrease = new float[8];

    [SerializeField] float[] frequencyBandMax = new float[8];
    public static float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];

    public static float amplitude;
    public static float amplitudeBuffer;
    float amplitudeMax;
    public float audioProfile;
    public enum channel { Stereo, Left, Right};
    public channel chosenChannel = new channel();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioProfile(audioProfile);

        //microphone
        if (useMic)
        {
            if(Microphone.devices.Length > 0)
            {
                selectedDevice = Microphone.devices[0].ToString();
                Debug.Log(selectedDevice);
               // StartMic(10);

            }
            else
            {
                Debug.Log("No mics");
                useMic = false;
            }
        }
        else
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
       
    }

    private void Update()
    {
        Debug.Log(amplitude);
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }
    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samplesLeft, 0, FFTWindow.Blackman);
        audioSource.GetSpectrumData(samplesRight, 1, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        /*
         * 22050/512 = 43hertz per sample
         * 
         * channels:
         * 20-60 hz
         * 250 - 500 hz
         * 500 - 2000 hz
         * 2000 - 4000 hz
         * 4000 - 6000 hz
         * 6000 - 20000 hz
         * 
         * 0 : 2  =  86hz
         * 1 : 4  =  172hz ---> 87   - 258
         * 2 : 8  =  344hz ---> 259  - 602
         * 3 : 16  = 688hz ---> 603  - 1290
         * 4 : 32  = 1376hz --> 1291 - 2666
         * 5 : 64  = 2752hz --> 2667 - 5418
         * 6 : 128 = 5504hz --> 5419 - 10922
         * 7 : 256 = 11008hz -> 10923- 21930 (+2 samples)
         * 510 (+2)
         */

        int count = 0;

        for (int i = 0; i<8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i+1);
            if (i == 7)
            {
                sampleCount += 2;
            }

            for(int j = 0; j<sampleCount; j++)
            {
                switch (chosenChannel)
                {
                    case channel.Left:
                        average += samplesLeft[count] * (count + 1);
                        break;
                    case channel.Stereo:
                        average += (samplesLeft[count] + samplesRight[count]) * (count + 1);
                        break;
                    case channel.Right:
                        average += + samplesRight[count] * (count + 1);
                        break;
                }
               
                count++;
            }
            average /= count;
            frequencyBand[i] = average*10;
        }
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if (frequencyBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = frequencyBand[i];
                bufferDecrease[i] = 0.005f;
            }
            if (frequencyBand[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }/**/
            /*
            if (frequencyBand[i] < bandBuffer[i])
            {
                bufferDecrease[i] = (bandBuffer[i] - frequencyBand[i]) / 8;
                bandBuffer[i] -= bufferDecrease[i];

            }/**/
        }
    }

    void CreateAudioBands()
    {
        for (int i = 0; i< 8; i++)
        {
            if(frequencyBand[i] > frequencyBandMax[i])
            {
                frequencyBandMax[i] = frequencyBand[i];
            }

            audioBand[i] = frequencyBand[i] / frequencyBandMax[i];
            audioBandBuffer[i] = bandBuffer[i] / frequencyBandMax[i];
        }
    }

    void GetAmplitude()
    {
        float currentAmplitude = 0;
        float currentAmplitudeBuffer = 0;
        for (int i = 0; i<8; i++)
        {
            currentAmplitude += audioBand[i];
            currentAmplitudeBuffer += audioBandBuffer[i];
        }
        if (currentAmplitude > amplitudeMax)
        {
            amplitudeMax = currentAmplitude;
        }
        amplitude = currentAmplitude / amplitudeMax;
        amplitudeBuffer = currentAmplitudeBuffer / amplitudeMax;
    }

    void AudioProfile(float profile)
    {
        for (int i = 0; i <8; i++)
        {
            frequencyBandMax[i] = profile;
        }
    }

    public void StartMic(int seconds)
    {
        audioSource.clip = Microphone.Start(selectedDevice, false, seconds, AudioSettings.outputSampleRate);
        CallAfterDelay.Create(0.5f,
            () => {
                audioSource.Play();
            }
        );
    }
}
