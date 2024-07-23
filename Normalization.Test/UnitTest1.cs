using WordNormalization;

namespace Normalization.Test;
public class Tests
{
    private string _projectFolderPath = Path.Combine(Environment.CurrentDirectory, "../../../");

    private const string JsonPath = "RemovableWords.json";
    [Test]
    public void TestReplaceSpanishSpecialCharacters()
    {
        var word = "·ÈÌÛ˙¸Ò¡…Õ”⁄‹—";
        var normalizedWord = Normalize.ReplaceSpanishSpecialCharacters(word);
        var expectedResults = "aeiouunAEIOUUN";

        Assert.That(normalizedWord, Is.EqualTo(expectedResults));
    }

    [Test]
    public void TestRemoveSpecialCharacters()
    {
        var word = "·ÈÌÛ˙¸Ò¡…Õ”⁄‹—";
        var normalizedWord = Normalize.RemoveSpanishSpecialCharacters(word);
        var expectedResults = string.Empty;

        Assert.That(normalizedWord, Is.EqualTo(expectedResults));
    }

    [Test]
    public void TestRemoveExtraWhitespace()
    {
        var word = "   This has extra spaces   ";
        var normalizedWord = Normalize.RemoveExtraWhitespace(word);
        var expectedResults = "This has extra spaces";

        Assert.That(normalizedWord, Is.EqualTo(expectedResults));
    }

    [Test]
    public void TestRemoveRemovableWords()
    {
        var word = "Hola como estas los dÌas est·n buenos";
        var normalizedWord = Normalize.RemoveRemovableWords(word);
        var expectedResults = "Hola como estas dÌas est·n buenos";

        Assert.That(normalizedWord, Is.EqualTo(expectedResults));
    }

    [Test]
    public void TestToTitleCase()
    {
        var word = "this is a sentence";
        var normalizedWord = Normalize.ToTitleCase(word);
        var expectedResults = "This Is A Sentence";

        Assert.That(normalizedWord, Is.EqualTo(expectedResults));
    }
    [Test]
    public void TestToRemoveDynamicallyAddedWords()
    {
        var word = "Hola como estas los dÌas est·n buenos";
        Normalize.RemovableWords.Add("dÌas");
        var normalizedWord = Normalize.RemoveRemovableWords(word);
        var expectedResults = "Hola como estas est·n buenos";

        Assert.That(normalizedWord, Is.EqualTo(expectedResults));
    }
    [Test]
    public void TestToRemoveDynamicallyAddedWordsByJson()
    {
        var word = "Hola como estas en el dia de hoy?";
        var expectedResults = "Hola como estas en el dia de hoy?";
        Normalize.ClearDefaultWords();
        Assert.That(Normalize.RemoveRemovableWords(word), Is.EqualTo(expectedResults));

        // Read JSON file
        var jsonString = File.ReadAllText(Path.Combine(_projectFolderPath, JsonPath));

        // Add words from JSON
        Normalize.AddDynamicRemovableWordsFromJson(jsonString);

        var expectedFilteredResults = "Hola como estas dia hoy?";
        word = Normalize.RemoveRemovableWords(word);
        Assert.That(word, Is.EqualTo(expectedFilteredResults));



    }
}
