//TODO::: mondjam majd el mi az a 'var'
//TODO::: megbeszélni a type? -> potenciális null retur & 'nullable types' témát
//TODO::: exception handling
//value és ref type-ok közti különbség gyakorlat/elmélet

using CSHARP25031903;

List<Dog> dogs = 
[
    new() // 001
    {
        Name = "Thomas Edison",
        Breed = "mixed breed",
        Weight = 22.5F,
        Sex = true,
        Birth = DateTime.Parse("2006-05-15"),
    },
    new() // 002
    {
        Name = "Frakk",
        Breed = "vizsla",
        Weight = 30F,
        Sex = true,
        Birth = DateTime.Parse("1972-12-23"),
    },
    new() // 003
    {
        Name = "Rex",
        Breed = "german sepherd",
        Weight = 35F,
        Sex = true,
        Birth = DateTime.Parse("1994-11-10"),
    },
    new() // 004
    {
        Name = "Szotyi",
        Breed = "tibetian terrier",
        Weight = 15.5F,
        Sex = false,
        Birth = DateTime.Parse("2021-04-02"),
    },
    new() // 005
    {
        Name = "Tappancs",
        Breed = "mixed breed",
        Weight = 18.75F,
        Sex = true,
        Birth = DateTime.Parse("1992-07-21"),
    },
    new() // 006
    {
        Name = "Buksi",
        Breed = "dachshund",
        Weight = 4F,
        Sex = false,
        Birth = DateTime.Parse("2024-12-24"),
    },
    new() // 007
    {
        Name = "Mr. Wick",
        Breed = "winter white dwarf hamster",
        Weight = 0.1F,
        Sex = true,
        Birth = DateTime.Parse("2023-06-12"),
    },
];

#region NEVEZETES ALGORITMUSOK
/*["egyszerű" programozási tételek]*/
// - sorozatszámítás (összegzés => átlag-számítás)
// - megszámlálás
// - szélsőérték-meghatározás (min/max - !hely! -> érték)
// - eldöntés
// - kiválasztás
// - lineáris keresés

/*["összetett" programozási tételek]*/
// - kiválogatás
// - szétválogatás
// > 'halmaztételek' (unió, metszet, különbség)

// további nevezetes algoritmusok:
// - rendezés(ek)
// - egyéb kereső algoritmusok...
// ...
#endregion

#region sum / avg
//a listában lévő kutyusok átlagsúlya:::

// változó név "refactorálása": Ctrl + R + R
float sumOfWeight = 0F;
foreach (var dog in dogs)
{
    sumOfWeight += dog.Weight;
}
float avgWeight = sumOfWeight / dogs.Count;
Console.WriteLine($"average weight: {avgWeight} kg");

var wSum = dogs.Sum(d => d.Weight);
Console.WriteLine($"sum of dog's weight: {wSum} kg");

var wAvg = dogs.Average(d => d.Weight);
Console.WriteLine($"avg of dog's weight: {wAvg} kg");

var aAvg = dogs.Average(d => d.Age);
Console.WriteLine($"avg of dog's age: {aAvg:0.00} year");
#endregion

Console.WriteLine("-----------------------");

# region cnt
int cMixedMale = 0;
foreach (var dog in dogs) 
    if (dog.Sex && dog.Breed == "mixed breed")
        cMixedMale++;
Console.WriteLine($"count of mixed breed male: {cMixedMale}");

var cMM = dogs.Count(d => d.Sex && d.Breed == "mixed breed");
Console.WriteLine($"count of mixed breed male: {cMM}");
#endregion

Console.WriteLine("-----------------------");

#region min/max
int mini = 0;
for (int i = 1; i < dogs.Count; i++)
    if (dogs[i].Birth < dogs[mini].Birth)
        mini = i;
Console.WriteLine($"the oldest dog's name is {dogs[mini].Name} ({dogs[mini].Age} years old)");

//value
var lBd = dogs.Min(d => d.Birth); // vagy a .Max(x => ...)
Console.WriteLine($"the earlyest date in the dog's bd's: {lBd:yyyy. MMMM dd.}");

//obj
var lBdDog = dogs.MinBy(d => d.Birth); // vagy a .MaxBy(x => ...)
Console.WriteLine($"the oldest dog: {lBdDog}");
#endregion

Console.WriteLine("-----------------------");

#region search, decision, selection
Console.Write("type here a pet's name: ");
var nameForSearch = Console.ReadLine();

int ifs = 0;
while (ifs < dogs.Count && nameForSearch != dogs[ifs].Name) ifs++;
if (ifs < dogs.Count) Console.WriteLine($"{nameForSearch}'s weight: {dogs[ifs].Weight}Kg");
else Console.WriteLine($"there are no {nameForSearch} here...");

// First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault
// Find, Contains
// Any, All



//FIRST
//var frstLINQ = dogs.First(d => d.Name == nameForSearch);
// HA van a => pred.-nek megfelelő találat
// AKKOR visszaadja a megfelelő találatok közül a legkisebb indexűt
// KÜLÖNBEN 'sequence contains no matching element' exceptiont dob.

//LAST
//var lstLINQ = dogs.Last(d => d.Name == nameForSearch);
// HA van a => pred.-nek megfelelő találat
// AKKOR visszaadja a megfelelő találatok közül a leg nagyobb indexűt
// KÜLÖNBEN 'sequence contains no matching element' exceptiont dob.

//FIRST OR DEFAULT
var frstOrDefLINQ = dogs.FirstOrDefault(d => d.Name == nameForSearch);
// HA van a => pred.-nek megfelelő találat
// AKKOR visszaadja a megfelelő találatok közül a legkisebb indexűt
//KÜLÖNBEN ún 'default' értékkel tér vissza, ami
//VALUE type-ok esetében ÁLTALÁBAN (vagy ha nincs felüldeffiniálva) a 'zéró' érték
//REFERENCE type-ok esetében NULL

Console.WriteLine(frstOrDefLINQ is null 
    ? $"there is no {nameForSearch} here..." 
    : frstOrDefLINQ);

//FIRST OR DEFAULT (== .Find(x => ...))
//var lstOrDefLINQ = dogs.LastOrDefault(d => d.Name == nameForSearch);
// HA van a => pred.-nek megfelelő találat
// AKKOR visszaadja a megfelelő találatok közül a legnagyobb indexűt
// KÜLÖNBEN ún 'default' értékkel tér vissza, ami
// VALUE type-ok esetében ÁLTALÁBAN (vagy ha nincs felüldeffiniálva) a 'zéró' érték
// REFERENCE type-ok esetében NULL

//SINGLE
//var snglLINQ = dogs.Single(d => d.Name == nameForSearch);
// HA EGYETLEN a pred.-nek megfelelő találat van
// AKKOR visszaadja azt
// HA TÖBB a pred.-nek megfelelő találat van
// AKKOR 'sequence contains more than one matching element' exceptiont dob
// HA NINCS a pred.-nek megfelelő találat
// AKKOR 'sequence contains no matching element' exceptiont dob.

//SINGLE OR DEFAULT
// var snglOrDefLINQ = dogs.SingleOrDefault(d => d.Name == nameForSearch);
// HA EGYETLEN a pred.-nek megfelelő találat van
// AKKOR visszaadja azt
// HA TÖBB a pred.-nek megfelelő találat van
// AKKOR 'sequence contains more than one matching element' exceptiont dob
// HA NINCS a pred.-nek megfelelő találat
// AKKOR ún 'default' értékkel tér vissza, ami
// VALUE type-ok esetében ÁLTALÁBAN (vagy ha nincs felüldeffiniálva) a 'zéró' érték
// REFERENCE type-ok esetében NULL

// <collection>.Contains(<element>) -> bool
// -visszadja, hogy a <collection> tartalmazza-e az <element>-et vagy sem

// .Any(x => ...) -> bool
// visszadja, hogy VAN-E legalább egy olyan eleme a kollekciónak, ami megfelel a pred.-nek

// .All(x => ...) -> bool
// visszadja, hogy a kollekció MINDEN EGYES elemére igaz-e a pred.?

//tl;dr:
// C# 'class' -> REFERENCE
// C# 'struct' -> VALUE

#endregion
