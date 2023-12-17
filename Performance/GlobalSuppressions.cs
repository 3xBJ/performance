﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Minor Code Smell", "S6602:\"Find\" method should be used instead of the \"FirstOrDefault\" extension", 
    Justification = "Testing", 
    Scope = "member", 
    Target = "~M:Performance.Analise.Search.NonOrderedSearch.LINQFirstOrDefault")]

[assembly: SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", 
    Justification = "Testing", 
    Scope = "member",
    Target = "~M:Performance.Analise.Strings.Concatenation.ConcatenationWithPlus")]
