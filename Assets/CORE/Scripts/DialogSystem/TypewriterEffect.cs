using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float writingSpeed = 50F;

    public bool IsRunning { get; private set; }

    private readonly List<Punctuation> punctuactions = new List<Punctuation>(){
        new Punctuation(new HashSet<char>() {'.', '!', '?'}, 0.8f),
        new Punctuation(new HashSet<char>() {',', ';', ':'}, 0.6f)
    };
    private Coroutine typingCoroutine;

    public void Run(string textToType, TMP_Text textLabel){
        typingCoroutine = StartCoroutine(TypeText(textToType, textLabel));
    }

    public void Stop(){
       StopCoroutine(typingCoroutine);
       IsRunning = false;
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel){
        IsRunning = true;
        textLabel.text = "";
        
        yield return new WaitForSeconds(1f);
        float time = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length){
            int lastCharIndex = charIndex;

            time += Time.deltaTime * writingSpeed;
            charIndex = Mathf.FloorToInt(time);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            
            for (int i = lastCharIndex; i <charIndex; i ++){
                bool isLast = i >= textToType.Length -1;
                textLabel.text = textToType.Substring(0, charIndex);

                if (IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i +1], out _)){
                    yield return new WaitForSeconds(waitTime);
                }
            }
            yield return null;
        }
        IsRunning = false;
    }

    private bool IsPunctuation(char character, out float waitTime){
        foreach (Punctuation punctuationCategory in punctuactions){
            if (punctuationCategory.Punctuations.Contains(character)){
                waitTime = punctuationCategory.WaitTime;
                return true;
            }
        }
        waitTime = default;
        return false;
    }

    private readonly struct Punctuation
    {
        public readonly HashSet<char> Punctuations;
        public readonly float WaitTime;
        public Punctuation(HashSet<char> punctuations,float waitTime){
            Punctuations = punctuations;
            WaitTime = waitTime;
        }
    }
}

