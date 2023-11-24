// See https://aka.ms/new-console-template for more information

using Bool_Logic;
Dictionary<char, bool> keys = new() 
{
    {'x', false},
    {'y', true},
    {'z', false}
};

Console.WriteLine(BoolExtra.BoolExpressionProcessing("-(x↔-y&z)", keys));

// название обозначение обозначение_в_счётчике
// НЕ ¬ -
// И ∧ &
// ИЛИ ∨ |
// XOR ⊕ ^
// XNOR ↔ ↔
// Импликация → →
// Обратная импликация ← ←


// Источники:
// 1. Материал к заданию (презентаця, задание, примеры)
// 2. https://habr.com/ru/articles/596925/
// 3. Моя фантазия