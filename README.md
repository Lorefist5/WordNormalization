  WordNormalization Library

WordNormalization Library
=========================

This library provides utilities for normalizing Spanish words by removing specific words, replacing special characters, and more.

Features
--------

*   Normalize words by converting to lowercase, removing extra whitespace, and more.
*   Replace Spanish special characters with their ASCII equivalents.
*   Remove Spanish special characters.
*   Remove specific words from a given text.
*   Convert text to title case.
*   Dynamically add or remove words to be excluded from text.
*   Load removable words from a JSON file.

Installation
------------

    dotnet add package WordNormalization

Usage
-----

    using WordNormalization;
    
    // Normalize a word
    string normalizedWord = Normalize.NormalizeWord("·ÈÌÛ˙¸Ò¡…Õ”⁄‹— Hola como estas los dÌas est·n buenos");
    Console.WriteLine(normalizedWord); // Output: "Aeiouun AEIOUUN Hola Como Estas DÌas Est·n Buenos"
    
    // Replace Spanish special characters
    string replacedWord = Normalize.ReplaceSpanishSpecialCharacters("·ÈÌÛ˙¸Ò¡…Õ”⁄‹—");
    Console.WriteLine(replacedWord); // Output: "aeiouunAEIOUUN"
    
    // Remove Spanish special characters
    string removedSpecialCharsWord = Normalize.RemoveSpanishSpecialCharacters("·ÈÌÛ˙¸Ò¡…Õ”⁄‹—");
    Console.WriteLine(removedSpecialCharsWord); // Output: ""
    
    // Remove specific words
    string cleanedWord = Normalize.RemoveRemovableWords("Hola como estas los dÌas est·n buenos");
    Console.WriteLine(cleanedWord); // Output: "Hola como estas dÌas est·n buenos"
    
    // Convert to title case
    string titleCaseWord = Normalize.ToTitleCase("this is a sentence");
    Console.WriteLine(titleCaseWord); // Output: "This Is A Sentence"
    
    // Add dynamic removable words
    Normalize.AddDynamicRemovableWords(new List { "dÌas" });
    cleanedWord = Normalize.RemoveRemovableWords("Hola como estas los dÌas est·n buenos");
    Console.WriteLine(cleanedWord); // Output: "Hola como estas est·n buenos"
    
    // Load removable words from JSON
    string json = File.ReadAllText("RemovableWords.json");
    Normalize.AddDynamicRemovableWordsFromJson(json);
    cleanedWord = Normalize.RemoveRemovableWords("Hola como estas en el dia de hoy?");
    Console.WriteLine(cleanedWord); // Output: "Hola como estas dia hoy?"
    

Contributing
------------

Contributions are welcome! Please fork this repository and submit pull requests.