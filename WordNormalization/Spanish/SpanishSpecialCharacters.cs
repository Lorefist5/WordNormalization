using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordNormalization.Spanish;

internal class SpanishSpecialCharacters
{
    public static readonly Dictionary<char, string> SpecialCharacters = new()
    {
        { 'á', "a" },
        { 'é', "e" },
        { 'í', "i" },
        { 'ó', "o" },
        { 'ú', "u" },
        { 'ü', "u" },
        { 'ñ', "n" },
        { 'Á', "A" },
        { 'É', "E" },
        { 'Í', "I" },
        { 'Ó', "O" },
        { 'Ú', "U" },
        { 'Ü', "U" },
        { 'Ñ', "N" }
    };
}
