# V320_MineSweeper 💣🚩
<br>

## Produktvision
Unser Ziel ist es ein Minesweeper Spiel zu entwickeln, welches klar und einfach zu bedienen ist und trotzdem alle wichtigen Features enthält. Verschiedene Schwierigkeiten sind zur Auswahl, so dass sich jeder Spieler mit kniffeligen Runden testen kann. Look und Feel dieser Version von Minesweeper bringt den User zurück in die Zeiten von frühen Konsolen Anwendungen. Nostalgische Äesthetik auf neuester Software und Hardware für ein Minesweeper Erlebnis wie noch nie. 
<br><br>

## User Stories
User Stories für den Minesweeper, sind im [Issues Tab](https://github.com/DeltaGamingCH/V320_MineSweeper/issues) ersichtlich.
<br><br>

## Reflektion
### Wie haben Sie das Lösens des Auftrags erlebt?
- Am Anfang hatten wir etwas Schwierigkeiten ein passendes Klassendiagram zu erstellen, welches eine logische Lösung für die Anforderungen darstellt. Ich habe mich in einer Pause zusammen mit anderen beraten lassen, was sie machen würden, und vorauf ich achten sollte. Dies hat mir etwas mehr Überblick über das Diagram verschafft, kam so jedoch nicht zu einer passenden Lösung. Als wir im Unterricht noch einmal Zeit bekamen, überarbeiteten wir das Klassendiagram von Grund auf, und überlegten uns, welche Klassen und Methoden wir denn wirklich benötigen. Anschliessend modellierten wir eine Lösung, um Model und View klar voneinander zu trennen, welches wir hinbekamen. Dazu möchte ich klar stellen: Wir haben keine Lösungen von anderen gesehen oder übernommen. 
- Die Implementation des Codes war dadurch relativ simpel. Als erstes fokusierten wir uns die Klassen richtig zu implementieren, ohne Funktionalität. Alle Funktionen und Ausgaben haben wir direkt in `Program.cs` erstellt, um es so einfach wie möglich für uns zu machen. Wir stiessen immer wieder auf kleinere Probleme in Funktionen konnten diese aber immer wieder beheben. Wenn einer von uns nicht weiterkam, haben wir auch zu zweit ein Problem angeschaut, und kamen so auf die Lösung.
- Am Ende versuchten wir alle Funktionalitäten in GameModel zu verschieben. Dazu erstellten wir einen neuen Branch. Dies hat am Anfang zu Schwierigkeiten geführt, da wir nicht alle Funktionalität in separaten Methoden hatten, sondern nur grob, und mussten dazu neue Methoden erstellen und entsprechend den Code verändern. Schlussendlich bekamen wir es doch hin, die ganze Logik zu verschieben, und neue passende Methoden zu bilden, welche wir beim Erstellen des Klassendiagrams gar nicht brücksichtigt haben.
- CLAUDE TESTING
### Inwieweit haben Ihnen die vermittelten Methoden bei der Lösung des Auftrags geholfen? Wo haben Sie die Methoden behindert? Begründen Sie. 
- Ich gehe davon aus, dass damit Model/View, etc. gemeint ist. Anfangs konnten wir nicht ausmachen, wie wir was miteinander verbinden, damit es die Anforderungen entspricht und auch logisch ist. Wie bereits angemerkt, als wir an einem Montag zusammensassen, löschten wir alles was wir nicht brauchen, und versuchten uns strikt an das Model/View System zu halten. Dies hat uns relativ schnell eine logische Lösung gegeben, welche wir bis jetzt brauchen.
- Memento-Pattern versuchten wir anfangs ohne Memento-Class zu machen, um es so simpel wie möglich zu halten. Diese Lösung haben wir aber geändert, als wir beim Programmieren waren, da wir mit einer Memento-Class das Ganze einfacher und übersichtlicher fanden. 
### Was nehmen Sie aus dem Modul mit für die Zukunft
- Patterns, welche wir angeschaut haben, sind ein guter Weg, um Probleme zu Lösen, welche andere Programmierer bereits hatten.
- Unser Zeitmanagement war sehr gut, die Arbeitsaufteilung auch. Ich hoffe dies so in zukunft in anderen Modulen auch anwenden zu können. Ein Task-Planner kommt auch sehr zunutze, wenn man gerade bei der Initialisierung eines Projekts dran ist, damit man im Überblick hat, was noch alles zu tun ist.
