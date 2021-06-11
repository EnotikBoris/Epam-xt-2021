let startingPoint = ("у попа была собака, он ее любил!");  // стартовая строка 
console.log(startingPoint);

function deleting(str, repeated)                 // детектор поворяющихся символов
{

    let rezult = [];

    for ( let i = 0; i < str.length; i++)
    {
        if (repeated.indexOF(str[i])) 
        {
            rezult.push(str[i]);
        }
    }

    let rezultString = ("");
    console.log(rezultString);
}

function changingString(str)        //  изменение строки
{

    let arrWords = str.split(" ");
    let repeated = [];

    for (let i = 0; arrWords< arrarrWords.length; i++) 
    {
        for (let j = 0; j < arrWords.length; j++)
        {
            if (arrWords[i].indexOF(arrWords[i][j])!== arrWords[i]lastIndexOf(arrWords[i][j])) 
            {
                repeated.push(arrWords[i][j])
            }
        }
    }

    deleting(str, repeated);
}

changingString(startingPoint);