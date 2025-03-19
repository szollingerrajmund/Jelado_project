# 4. Jeladó

Az állatok mozgását ma már rutinszerűen figyelik a rájuk rögzített jeladók segítségével. Ebben a feladatban egy ilyen jeladó által továbbított adatokat kell feldolgoznia.

Az itt használt jeladó úgy működik, hogy helyének x és y koordinátáját továbbítja. Jelet küld, ha a legutolsó küldés óta bármely koordináta változása elérte a 10 egységet. Ha nem történt ekkora elmozdulás, 5 perc elteltével akkor is mindenképpen jelenti helyét. A vevőegység egy fájlban rögzíti a jel érkezési idejét és a pozíciót. Előfordulhat, hogy a vétel meghiúsul, ezért lehetnek egymást követő adatsorok, amelyek között 5 percnél több idő telik el, vagy a koordináták változása 10 egységnél nagyobb.

Rendelkezésére áll a _jel.json_ nevű adatfájl, amely egy napról tartalmaz adatokat időrendben. Soraiban öt adat található, melyeknek típusa szám. Az első három szám a jeladás időpontját (óra, perc, másodperc) adja meg, a negyedik szám az x, az ötödik az y koordináta. A sorok száma legfeljebb 1000, a koordináták -10 000 és 10 000 közötti értékek lehetnek.

```
Például:
{
        "ora": 3,
        "perc": 21,
        "masodperc": 19,
        "x": 126,
        "y": 639
    },
    {
        "ora": 3,
        "perc": 26,
        "masodperc": 19,
        "x": 131,
        "y": 641
    },
    {
        "ora": 3,
        "perc": 27,
        "masodperc": 55,
        "x": 124,
        "y": 651
    },
    {
        "ora": 3,
        "perc": 31,
        "masodperc": 50,
        "x": 134,
        "y": 649
    },
...
{
        "ora": 4,
        "perc": 30,
        "masodperc": 33,
        "x": 83,
        "y": 680
    },
    {
        "ora": 4,
        "perc": 35,
        "masodperc": 33,
        "x": 80,
        "y": 677
    },
    {
        "ora": 4,
        "perc": 40,
        "masodperc": 33,
        "x": 88,
        "y": 686
    },
...
```

A példa első csoportjában a második sor megmutatja, hogy a jeladó 5 egységnyit mozdult x, 2 egységnyit pedig y irányban 5 perc alatt. A harmadik bejegyzés azért született, mert y irányban 10 egységnyit mozdult el a jeladó, a negyedik bejegyzés pedig egy x irányú 10 egységnyi elmozdulást jelez.

A példa második csoportjában a második sor adataiból látszik, hogy legalább egyszer nem jutott el a jel a vevőhöz, mert 5 percnél több idő telt el az előző vételtől, de az eltelt idő a 10 percet nem haladja meg. A második és harmadik vétel által jelzett pozíciók y koordinátája 29 egységnyivel eltér, ezért legalább két vétel nem került rögzítésre.

Készítsen programot, amely az állomány adatait felhasználva az alábbi kérdésekre válaszol! A program forráskódját mentse *jelado* néven! A program megírásakor a felhasználó által megadott adatok helyességét, érvényességét nem kell ellenőriznie, és feltételezheti, hogy a rendelkezésre álló adatok a leírtaknak megfelelnek.

A képernyőre írást igénylő részfeladatok esetén – a mintához tartalmában hasonlóan – írja ki a képernyőre a feladat sorszámát (például: 5. feladat), és utaljon a kiírt tartalomra is! Ha a felhasználótól kér be adatot, jelenítse meg, hogy milyen értéket vár! Mindkét esetben az ékezetmentes kiírás is elfogadott.

1. Olvassa be a _jel.json_ állomány tartalmát, tárolja el a rögzített jelek adatait, és azok
    felhasználásával oldja meg a következő feladatokat!

2. Kérje be a felhasználótól egy jel sorszámát (a sorszámozás 1-től indul), és írja a képernyőre
    az adott jeladáshoz tartozó **_x_** és **_y_** koordinátát!

3. Készítsen függvényt _eltelt_ néven, amely megadja, hogy a paraméterként átadott két
    időpont között hány másodperc telik el! A két időpontot, mint paramétert tetszőleges módon
    átadhatja. Használhat három-három számértéket, két tömböt vagy listát, de más, a célnak
    megfelelő típusú változót is. Ezt a függvényt később használja fel legalább egy feladat
    megoldása során!

4. Adja meg, mennyi idő telt el az első és az utolsó észlelés között! Az időt _óra:perc:mperc_
    alakban írja a képernyőre!

5. Határozza meg azt a legkisebb, a koordináta-rendszer tengelyeivel párhuzamos oldalú
    téglalapot, amelyből nem lépett ki a jeladó! Adja meg a téglalap bal alsó és jobb felső
    sarkának koordinátáit!

6. Írja a képernyőre, hogy mennyi volt a jeladó elmozdulásainak összege! Úgy tekintjük, hogy
    a jeladó két pozíciója közötti elmozdulása a pozíciókat összekötő egyenes mentén történt.
    Az összeget három tizedes pontossággal jelenítse meg! A kiírásnál a tizedesvessző és
    tizedespont kiírása is elfogadott. Az i-edik és az i+1-edik pontok távolságát a
    √((x~i~ - x ~(i+1)~)^2^ + (y~i~ - y ~(i+1)~)^2^)

7. Írja a _kimaradt.json_ fájlba a kimaradt észlelésekkel kapcsolatos adatokat! A kimeneti
    fájlban azok a bemeneti állományban rögzített vételi időpontok jelenjenek meg, amelyek
    előtt közvetlenül egy vagy több észlelés kimaradt! Az időpont mellett – a mintának
    megfelelően – jelenjen meg, hogy legalább hány jel maradt ki, és az is, hogy miből
    következtet a hiányra! Ha idő- és koordináta-eltérésből is adódik jelkimaradás, akkor a
    nagyobb értéket írja ki! Ha az időeltérés és a koordináták eltérése alapján is ugyanannyi
    jelkimaradásra következtetünk, akkor bármelyiket kiírhatja.

Példa a szöveges kimenetek kialakításához:

```
2. feladat
Adja meg a jel sorszámát! 3
x=126 y=636

4. feladat
Időtartam: 18:52:40

5. feladat
Bal alsó: 4 639, jobb felső: 147 727

6. feladat
Elmozdulás: 2007.677 egység
```

Minta a _kimaradt.json_ fájl tartalmára
    ```
    {
      "óra": 4,
      "perc": 55,
      "másodperc": 33,
      "kimaradtJelek": 2,
      "kimaradasOka": "koordináta-eltérés"
    },
    {
      "óra": 5,
      "perc": 5,
      "másodperc": 33,
      "kimaradtJelek": 2,
      "kimaradasOka": "időeltérés"
    },
    {
      "óra": 6,
      "perc": 22,
      "másodperc": 42,
      "kimaradtJelek": 3,
      "kimaradasOka": "időeltérés"
    },
    {
      "óra": 6,
      "perc": 32,
      "másodperc": 42,
      "kimaradtJelek": 3,
      "kimaradasOka": "koordináta-eltérés"
    },

```