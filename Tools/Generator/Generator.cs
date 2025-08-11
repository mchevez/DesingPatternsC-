﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class Generator
    {
        public List<string> Content { get; set; }
        public string Path { get; set; }
        public TypeFormat Format { get; set; }
        public TypeCharacter Character { get; set; }

        public void Save() {
            string result = "";

            result = Format == TypeFormat.Json ? GetJson(): GetPipes();

            if(Character == TypeCharacter.UpperCase) result = result.ToUpper();
            if(Character == TypeCharacter.LowerCase) result = result.ToLower();

            File.WriteAllText(Path, result);
        }
        private string GetJson() => JsonSerializer.Serialize(Content);
        private string GetPipes() => Content.Aggregate((accum, current) => accum +"|"+current);
    }
}
