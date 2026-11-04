# Kółko i krzyżyk

Prosta gra dla dwóch osób, napisana w C# z interfejsem Windows Forms.
Projekt powstał w ramach ćwiczenia polegającego na analizie i modyfikacji istniejącego programu.

- Autor opracowania: XXX YYY, nr albumu .....
- Uczelnia: Akademia WSB.
- Przedmiot według instrukcji: Podstawy programowania komputerów.
- Data opracowania: 04.11.2026.
- Środowisko: Visual Studio, C#, Windows Forms, .NET Framework 3.5.
- Zakres: zadania obowiązkowe 1–8.

## Uruchomienie

1. Rozpakuj projekt na komputerze z Windows.
2. Otwórz `KolkoKrzyzyk.sln` w Visual Studio z pakietem „Programowanie aplikacji klasycznych dla platformy .NET”.
3. W razie komunikatu o brakujących składnikach doinstaluj obsługę .NET Framework 3.5 wskazaną przez Visual Studio.
4. Naciśnij F5.

Pierwszą partię rozpoczyna O. Opcja „Nowa gra” czyści planszę i zmienia gracza rozpoczynającego. Wyniki pozostają w pamięci do ich wyzerowania lub zamknięcia programu.

## Zadanie 1  Struktura programu

### 1.1 Main, konstruktor Form1 i InitializeComponent

Metoda `Main()` jest punktem wejścia aplikacji. Włącza systemowy wygląd kontrolek, ustawia sposób renderowania tekstu, a następnie tworzy główne okno i uruchamia obsługę zdarzeń aplikacji.

```csharp
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);
Application.Run(new Form1());
```

`static` pozwala wywołać metodę bez tworzenia obiektu klasy `Program`. `void` oznacza, że metoda nie zwraca wyniku.

Konstruktor `Form1()` wykonuje się podczas tworzenia okna. Wywołuje `InitializeComponent()`, tworzy dziewięć przycisków planszy i przypisuje im obsługę kliknięć. W końcowej wersji ustawia też informację o graczu rozpoczynającym oraz odświeża wyniki.

Metoda `InitializeComponent()` zawiera kod generowany przez projektant Windows Forms w pliku `Form1.Designer.cs`. Tworzy kontrolki i ustawia ich właściwości oraz powiązania zdarzeń.

### 1.2 Elementy interfejsu

W wersji początkowej projektant tworzy pasek menu `menuStrip1`, opcję „Nowa gra” (`toolStripMenuItem1`), etykietę `label1` i przycisk `buttonKoniec`. Podczas ćwiczenia dodano w projektancie etykietę `labelWyniki` i przycisk `buttonZerujWyniki`.

Dziewięć przycisków planszy powstaje programowo w konstruktorze:

```csharp
this.Przycisk[i, j] = new Button();
this.Controls.Add(Przycisk[i, j]);
```

### 1.3 Rejestracja kliknięć

Operator `+=` dodaje metodę obsługi do zdarzenia `Click`. Wszystkie pola planszy korzystają z jednej metody:

```csharp
this.Przycisk[i, j].Click += new System.EventHandler(this.Przycisk_Click);
```

Kliknięcia opcji „Nowa gra”, przycisku „koniec” i przycisku „Zeruj wyniki” są przypisane do odpowiednich metod w `InitializeComponent()`.

## Zadanie 2  Tablica i pętle

### 2.1 Tablica przycisków

```csharp
Button[,] Przycisk = new Button[3, 3];
```

Jest to dwuwymiarowa tablica przechowująca dziewięć odwołań do przycisków. Indeksy obu wymiarów mają wartości od 0 do 2. Sama tablica nie tworzy przycisków — powstają one później przez `new Button()`.

W tym programie pierwszy indeks oznacza kolumnę, a drugi wiersz, co wynika z ustawienia położenia przycisków.

### 2.2 Zagnieżdżone pętle

```csharp
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        // Tworzenie i konfiguracja przycisku.
    }
}
```

Pętla zewnętrzna przechodzi przez trzy kolumny, a wewnętrzna przez trzy wiersze. Wnętrze wykonuje się dziewięć razy. Za każdym razem program tworzy przycisk, ustawia jego właściwości, przypisuje obsługę kliknięcia i dodaje go do okna.

### 2.3 Położenie i rozmiar pól

`Location` określa położenie, a `Size` szerokość i wysokość przycisku. Ustawiono:

```csharp
this.Przycisk[i, j].Location = new System.Drawing.Point(39 + (80 * i), 60 + (50 * j));
this.Przycisk[i, j].Size = new System.Drawing.Size(75, 45);
```

Pola mają rozmiar 75 × 45 pikseli i odstępy po 5 pikseli.

## Zadanie 3  Obsługa kliknięcia

### 3.1 Parametr sender

Metoda `Przycisk_Click(object sender, EventArgs e)` obsługuje kliknięcia pól. Parametr `sender` wskazuje kliknięty przycisk. Rzutowanie `(Button)sender` umożliwia dostęp do jego właściwości:

```csharp
((Button)sender).Text = symbol;
```

Program wpisuje symbol, sprawdza zwycięstwo i remis, a jeżeli partia trwa dalej — zmienia gracza. Parametr `e` nie jest wykorzystywany.

### 3.2 Blokada zajętego pola i zmiana gracza

```csharp
if (((Button)sender).Text.Equals(""))
{
    ((Button)sender).Text = symbol;
}
else return;
```

Symbol można wpisać tylko w puste pole. `return` kończy metodę, gdy pole jest zajęte.

```csharp
if (symbol.Equals("O")) symbol = "X";
else symbol = "O";
```

Ten fragment zmienia gracza po poprawnym ruchu, gdy nie ma zwycięstwa ani remisu.

### 3.3 Kolory symboli

```csharp
if (symbol.Equals("X"))
{
    ((Button)sender).ForeColor = Color.Blue;
}
else
{
    ((Button)sender).ForeColor = Color.Red;
}
```

X jest niebieski, a O czerwone. Kolor tekstu ustawia właściwość `ForeColor`. Po wyłączeniu przycisków po zwycięstwie system może wyświetlić symbole na szaro.

## Zadanie 4  Warunki zwycięstwa

### 4.1 Metoda wygrana

Metoda `wygrana(string symbol)` zwraca `bool`: `true`, gdy dany gracz wygrał, lub `false`, gdy nie wygrał. Operator `&&` oznacza logiczne „i” — wszystkie trzy sprawdzane pola muszą zawierać ten sam symbol.

```csharp
if (Przycisk[0, 0].Text.Equals(symbol) &&
    Przycisk[0, 1].Text.Equals(symbol) &&
    Przycisk[0, 2].Text.Equals(symbol)) return true;
```

Osiem warunków sprawdza kolejno trzy kolumny, trzy wiersze i dwie przekątne. Gdy żaden warunek nie jest spełniony, metoda zwraca `false`.

### 4.2 Testy zwycięstwa

Numeracja pól użyta w testach:

```text
1 | 2 | 3
---------
4 | 5 | 6
---------
7 | 8 | 9
```

Każdy test należy rozpocząć na pustej planszy. Wygrywa gracz wykonujący pierwszy ruch w danej partii.

| Test | Kolejność kliknięć | Oczekiwany wynik |
| --- | --- | --- |
| Poziomo | 1 → 4 → 2 → 5 → 3 | Wygrana w górnym wierszu |
| Pionowo | 1 → 2 → 4 → 3 → 7 | Wygrana w lewej kolumnie |
| Po przekątnej | 1 → 2 → 5 → 3 → 9 | Wygrana na przekątnej |

### 4.3 Blokada ruchów po zwycięstwie

Po wykryciu zwycięstwa program wyłącza wszystkie pola:

```csharp
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Przycisk[i, j].Enabled = false;
    }
}
```

Po wybraniu „Nowa gra” pola są ponownie włączane.

## Zadanie 5  Wykrywanie remisu

### 5.1 Metoda PelnaPlansza i licznik

Metoda `PelnaPlansza()` przegląda dziewięć pól. Zmienna `licznik` zaczyna od zera. Każde niepuste pole zwiększa ją o jeden:

```csharp
if (!Przycisk[i, j].Text.Equals("")) licznik++;
```

Operator `!` oznacza zaprzeczenie, a `++` zwiększa wartość o jeden.

### 5.2 Zwracana wartość

```csharp
return (licznik == 9);
```

Metoda zwraca `true`, gdy wszystkie pola są zajęte. Pełna plansza oznacza remis dopiero wtedy, gdy nie ma zwycięzcy. Dlatego zwycięstwo jest sprawdzane wcześniej.

### 5.3 Komunikat o remisie

Przy remisie program aktualizuje etykietę, zwiększa licznik remisów i wyświetla komunikat:

```csharp
label1.Text = "Remis";
remisy++;
AktualizujWyniki();
MessageBox.Show("Mamy remis byku.", "Próbuj ponownie");
```

Przykładowa sekwencja testowa: `1 → 2 → 3 → 5 → 4 → 6 → 8 → 7 → 9`.

## Zadanie 6  Rozpoczęcie nowej gry

### 6.1 ZerujPlansze i opcja Nowa gra

Kliknięcie „Nowa gra” wywołuje `toolStripMenuItem1_Click`, a ta metoda uruchamia `ZerujPlansze()`.

### 6.2 Czyszczenie i odblokowanie planszy

W dwóch pętlach wykonywane są instrukcje:

```csharp
this.Przycisk[i, j].Text = "";
this.Przycisk[i, j].Enabled = true;
```

Usuwają symbole i umożliwiają ponowne klikanie pól. Wyniki poprzednich partii pozostają w pamięci.

### 6.3 Naprzemienne rozpoczynanie

Pole klasy `string startowy = "O";` przechowuje gracza rozpoczynającego. Pierwszą partię zaczyna O. Przy każdej nowej grze program zmienia tę wartość:

```csharp
if (startowy.Equals("O"))
{
    startowy = "X";
}
else
{
    startowy = "O";
}
symbol = startowy;
```

W symbolu O używana jest litera, a nie cyfra zero.

### 6.4 Informacja o graczu rozpoczynającym

Na początku programu i po rozpoczęciu kolejnej partii ustawiany jest tekst:

```csharp
label1.Text = "Rozpoczyna gracz " + symbol;
```

## Zadanie 7  Zamykanie aplikacji

### 7.1 buttonKoniec_Click i Thread.Sleep

Metoda `buttonKoniec_Click()` obsługuje przycisk „koniec”. Polecenie `this.Close()` zamyka okno gry.

W analizowanym kodzie nie było `Thread.Sleep(10000)`. Taka instrukcja wstrzymywałaby bieżący wątek na 10 sekund. W obsłudze kliknięcia blokowałaby interfejs na ten czas.

### 7.2 Zachowanie przed zmianą

Przed dodaniem potwierdzenia przycisk zamykał okno od razu.

### 7.3 Potwierdzenie zamknięcia

```csharp
DialogResult decyzja = MessageBox.Show(
    "Zamykamy grę?",
    "Zamykanie programu...",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

if (decyzja == DialogResult.Yes)
{
    this.Close();
}
```

„Tak” zamyka grę, a „Nie” pozostawia ją otwartą. Potwierdzenie dotyczy przycisku „koniec”.

## Zadanie 8  Licznik wyników

### 8.1 Liczniki

```csharp
int wygraneX = 0;
int wygraneO = 0;
int remisy = 0;
```

Po zwycięstwie zwiększany jest licznik odpowiedniego gracza. Po remisie zwiększany jest licznik `remisy`.

### 8.2 Wyświetlanie i zachowanie wyników

```csharp
private void AktualizujWyniki()
{
    labelWyniki.Text = "X: " + wygraneX
        + " | O: " + wygraneO
        + " | Remisy: " + remisy;
}
```

Metoda jest wywoływana na początku programu, po zakończeniu partii i po zerowaniu wyników. „Nowa gra” nie zeruje liczników. Wyniki nie są zapisywane na dysku.

### 8.3 Zerowanie i sprawdzanie wyników

Przycisk „Zeruj wyniki” wykonuje:

```csharp
wygraneX = 0;
wygraneO = 0;
remisy = 0;
AktualizujWyniki();
```

Zerowanie wyników nie zmienia bieżącej planszy.

| Czynność | Oczekiwane działanie |
| --- | --- |
| Zwycięstwo X | Licznik X rośnie o jeden |
| Zwycięstwo O | Licznik O rośnie o jeden |
| Remis | Licznik remisów rośnie o jeden |
| Nowa gra | Wyniki pozostają bez zmian |
| Zeruj wyniki | Wszystkie trzy liczniki wynoszą zero |

## Zrzuty z ćwiczenia

Poniższe obrazy pochodzą ze sprawozdania i pokazują etapy pracy. Mogą przedstawiać wcześniejsze nazwy przycisków lub wcześniejszy wygląd planszy. Aktualny kod znajduje się w folderze `KolkoKrzyzyk`.

### Kolory symboli

![Różne kolory symboli X i O](docs/screenshots/kolory.png)

### Remis

![Komunikat o remisie](docs/screenshots/remis.png)

### Potwierdzenie zamknięcia

![Pytanie o zamknięcie gry](docs/screenshots/zamykanie.png)

### Zerowanie wyników

![Wyzerowane liczniki wyników](docs/screenshots/zerowanie.png)

## Podsumowanie

### Struktura

- `Program.cs` uruchamia aplikację przez metodę `Main()`.
- `Form1.cs` zawiera logikę gry i obsługę kliknięć.
- `Form1.Designer.cs` zawiera ustawienia okna i kontrolek.
- Plansza składa się z dziewięciu przycisków zapisanych w tablicy dwuwymiarowej.

### Modyfikacje

- Dodano odstępy między polami i różne kolory symboli.
- Zablokowano ruchy po zwycięstwie i dodano komunikat o remisie.
- Nowa gra czyści i odblokowuje planszę.
- X i O rozpoczynają kolejne partie naprzemiennie.
- Dodano informację o graczu rozpoczynającym.
- Dodano potwierdzenie zamknięcia gry.
- Dodano liczniki zwycięstw i remisów oraz przycisk „Zeruj wyniki”.

### Wnioski

- Poznano budowę aplikacji Windows Forms.
- Przećwiczono tablice, pętle i warunki.
- Poznano obsługę kliknięć przycisków.
- Rozbudowano grę i sprawdzano działanie zmian podczas ćwiczenia.

## Pochodzenie projektu

Kod źródłowy oryginalnego programu należy do Akademii WSB i został udostępniony do celów dydaktycznych. 

## Oryginał i wersja po modyfikacjach

Oryginalny program (baza do ćwiczenia) jest również dostępny w tym repozytorium, w folderze `oryginal`. Wersja po zmianach znajduje się w folderze `po-modyfikacjach`. Aby uruchomić wybraną wersję, otwórz znajdujący się w jej folderze plik `KolkoKrzyzyk.sln`. Powyższe sprawozdanie opisuje wersję po modyfikacjach.
