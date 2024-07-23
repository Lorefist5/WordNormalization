using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using WordNormalization.Containers;
using WordNormalization.Spanish;

namespace WordNormalization;

public class Normalize
{
    public static List<string> RemovableWords = SpanishRemovers.SpanishRemovableWords;
    public static string NormalizeWord(string word)
    {
        var normalizedWord = word.ToLower();
        normalizedWord = RemoveExtraWhitespace(normalizedWord);
        normalizedWord = RemoveRemovableWords(normalizedWord);
        normalizedWord = ReplaceSpanishSpecialCharacters(normalizedWord);
        normalizedWord = RemoveSpanishSpecialCharacters(normalizedWord);
        normalizedWord = ToTitleCase(normalizedWord);
        return normalizedWord;
    }
    public static string ReplaceSpanishSpecialCharacters(string word)
    {
        var normalizedWord = new StringBuilder();
        foreach (var character in word)
        {
            if (Spanish.SpanishSpecialCharacters.SpecialCharacters.ContainsKey(character))
            {
                normalizedWord.Append(Spanish.SpanishSpecialCharacters.SpecialCharacters[character]);
            }
            else
            {
                normalizedWord.Append(character);
            }
        }
        return normalizedWord.ToString();
    }
    public static string RemoveSpanishSpecialCharacters(string word)
    {
        var normalizedWord = new StringBuilder();
        foreach (var character in word)
        {
            if (Spanish.SpanishSpecialCharacters.SpecialCharacters.ContainsKey(character))
            {
                continue;
            }
            normalizedWord.Append(character);
        }
        return normalizedWord.ToString();
    }
    public static string RemoveRemovableWords(string word)
    {
        var normalizedWord = new StringBuilder();
        var words = word.Split(' ');
        var removableWordsLower = RemovableWords.Select(w => w.ToLower()).ToList();

        foreach (var w in words)
        {
            if (!removableWordsLower.Contains(w.ToLower()))
            {
                normalizedWord.Append(w);
                normalizedWord.Append(" ");
            }
        }
        return normalizedWord.ToString().Trim();
    }
    public static string RemoveExtraWhitespace(string input)
    {
        // Remove leading and trailing spaces
        var trimmedInput = input.Trim();

        // Remove extra spaces within the string
        return Regex.Replace(trimmedInput, @"\s+", " ");
    }
    public static string ToTitleCase(string input)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
    }
    public static void AddDynamicRemovableWords(List<string> words)
    {
        RemovableWords.AddRange(words);
    }
    public static void RemoveDynamicRemovableWords(List<string> words)
    {
        foreach (var word in words)
        {
            RemovableWords.Remove(word);
        }
    }
    public static void AddDynamicRemovableWordsFromJson(string json)
    {
        var container = JsonSerializer.Deserialize<RemovableWordsContainer>(json);
        if (container != null && container.RemovableWords != null)
        {
            RemovableWords.AddRange(container.RemovableWords);
        }
    }

    public static void ClearDefaultWords()
    {
        for (int i = RemovableWords.Count - 1; i >= 0; i--)
        {
            var word = RemovableWords[i];
            if (SpanishRemovers.SpanishRemovableWords.Contains(word))
            {
                RemovableWords.RemoveAt(i);
            }
        }
    }
}
