using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WordNormalization.Containers;

public class RemovableWordsContainer
{
    
    public List<string> RemovableWords { get; set; }
}
