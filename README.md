# POSE 5ABIF/5ACIF

## GenericSortedList

Lernziele

- Die Bedeutung von generischen Datentypen verstehen und Wiedergeben (einfach)
- Die Bedeutung von Schnittstellen verstehen und Wiedergeben (einfach)
- Lesen und Verstehen von UnitTests
- Implementierung der generiaschen linearen Datenstrukturen SortedList&lt;T&gt;

### Aufgabenstellung

In der vorliegenden Aufgabe befinden sich der UnitTest für die generische linearen Datenstruktur *SortedList&lt;T&gt;*. Analysieren sie die einzelnen Tests und implementieren sie anschließend die einzelnen Methoden und Eigenschaften in der Klasse *SortedList&lt;T&gt;*. Die Umsetzung führen sie mit einer dynamischen Datenstrucktur (einfach verkettete Liste oder mehrfach verkettete Liste) durch. 

### Hinweise zur Benennung der Tests

Die Tests sind nach dem Schema ``` ItShould[ExpectedResult]_Given[Condition]() ``` benannt worden. Dieses Schema ist sehr nützlich, um Testmethoden verständlicher und aussagekräftiger zu gestalten.

Überblick der Benennungsstruktur:

- **ItShould[ExpectedResult]:** Beschreibt, was als Ergebnis erwartet wird, z.B. "ReturnZeroCount", "IncreaseCount", "ThrowOutOfRangeException".
- **Given[Condition]:** Gibt die Bedingung an, unter der der Test durchgeführt wird, z.B. "AnEmptyList", "AnItemIsAdded", "AnItemIsRemoved".

Vorteile dieser Benennungsstruktur:

- **Lesbarkeit:** Die Benennung macht klar, was genau in jeder Testmethode getestet wird.
- **Wartbarkeit:** Es ist leichter zu erkennen, welche Tests welchen Zustand abdecken.
- **Klarheit bei Fehlern:** Falls ein Test fehlschlägt, zeigt der Testname genau, welches Verhalten nicht wie erwartet eingetreten ist.

**Viel Spaß**